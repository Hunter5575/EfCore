using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp3.Core;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if (EfModel.Init().Users.Any(u => u.Login == tbLogin.Text && (u.Pass == tbPass.Password || u.Pass == tb1Pass.Text)))
            {

                MainWindow mainWindow = new MainWindow();
                Hide();
                mainWindow.ShowDialog();
                btLogin.Visibility = Visibility.Collapsed;
                btAuthEnter.Visibility = Visibility.Visible;
                btDeauth.Visibility = Visibility.Collapsed;
                tbLogin.IsEnabled = true;
                tbPass.IsEnabled = true;
                tb1Pass.IsEnabled = true;
                tbLogin.Clear();
                tbPass.Clear();
                tb1Pass.Clear();
                Show();
                Mouse.OverrideCursor = null;
                
            }
        }
        private void btAuthEnter_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            if (AuthClass.Auth(tbLogin.Text, tbPass.Password))
            {
                Mouse.OverrideCursor = null;
                MessageBox.Show("Добро пожаловать " + AuthClass.user.NickName);
                btAuthEnter.Visibility = Visibility.Collapsed;
                btLogin.Visibility = Visibility.Visible;
                btDeauth.Visibility = Visibility.Visible;
                tbLogin.IsEnabled = false;
                tbPass.IsEnabled = false;
                tb1Pass.IsEnabled = false;
            }
            else
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Проверьте правильность введенных данных");
                Mouse.OverrideCursor = null;
            }
        }

        private void btDeauth_Click(object sender, RoutedEventArgs e)
        {
            btDeauth.Visibility = Visibility.Collapsed;
            btLogin.Visibility = Visibility.Collapsed;
            btAuthEnter.Visibility = Visibility.Visible;
            tbLogin.Clear();
            tbPass.Clear();
            tbLogin.IsEnabled = true;
            tbPass.IsEnabled = true;
        }

        private void cbPassView_Checked(object sender, RoutedEventArgs e)
        {
            tb1Pass.Text = tbPass.Password;
            tbPass.Visibility = Visibility.Collapsed;
            tb1Pass.Visibility = Visibility.Visible;

            tb1Pass.Focus();
        }

        private void cbPassView_Unchecked(object sender, RoutedEventArgs e)
        {
            tbPass.Visibility = Visibility.Visible;
            tb1Pass.Visibility = Visibility.Collapsed;
            tbPass.Focus();
        }

        private void Switch_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
