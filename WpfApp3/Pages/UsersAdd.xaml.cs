using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Core;
using WpfApp3.Database;

namespace WpfApp3.Pages
{
    /// <summary>
    /// Interaction logic for UsersAdd.xaml
    /// </summary>
    public partial class UsersAdd : Page
    {
        User users;
        public UsersAdd(User users)
        {
            this.users = users;
            InitializeComponent();
            
            if (AuthClass.user.Post == "Admin")
            {
                btEdit.Visibility = Visibility.Visible;
                btSave.Visibility = Visibility.Visible;
               
            }
            btSave.Visibility=Visibility.Collapsed;
            tbNikcName.Background = new SolidColorBrush(Colors.Black);
            tbLoginU.Background = new SolidColorBrush(Colors.Black);
            tbPassU.Background = new SolidColorBrush(Colors.Black);
            tbPostU.Background = new SolidColorBrush(Colors.Black);
            tbNikcName.Foreground = new SolidColorBrush(Colors.Red);
            tbLoginU.Foreground = new SolidColorBrush(Colors.Red);
            tbPassU.Foreground = new SolidColorBrush(Colors.Red);
            tbPostU.Foreground = new SolidColorBrush(Colors.Red);
            
           
            DataContext = users;
        }

        private void BtClickSave(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            if (users.IdUsers == 0)
                EfModel.Init().Users.Add(users);
            EfModel.Init().SaveChanges();
            btSave.Visibility = Visibility.Collapsed;
            btEdit.Visibility = Visibility.Visible;
            btBack.Visibility = Visibility.Visible;
            tbLoginU.IsEnabled = false;
            tbNikcName.IsEnabled = false;
            tbPassU.IsEnabled = false;
            tbPostU.IsEnabled = false;
            Image.IsEnabled=false;
            tbNikcName.Background = new SolidColorBrush(Colors.Black);
            tbLoginU.Background = new SolidColorBrush(Colors.Black);
            tbPassU.Background = new SolidColorBrush(Colors.Black);
            tbPostU.Background = new SolidColorBrush(Colors.Black);
            tbNikcName.Foreground = new SolidColorBrush(Colors.Red);
            tbLoginU.Foreground = new SolidColorBrush(Colors.Red);
            tbPassU.Foreground = new SolidColorBrush(Colors.Red);
            tbPostU.Foreground = new SolidColorBrush(Colors.Red);
            mainWindow.btPage1.Visibility = Visibility.Visible;
            mainWindow.btPage2.Visibility = Visibility.Visible;
        }

        private void BtClickEdit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            btEdit.Visibility=Visibility.Collapsed;
            btSave.Visibility=Visibility.Visible;
            btBack.Visibility=Visibility.Collapsed;
            tbLoginU.IsEnabled = true;
            tbNikcName.IsEnabled = true;
            tbPassU.IsEnabled = true;
            tbPostU.IsEnabled = true;
            Image.IsEnabled=true;
            tbNikcName.Background = new SolidColorBrush(Colors.White);
            tbLoginU.Background = new SolidColorBrush(Colors.White);
            tbPassU.Background = new SolidColorBrush(Colors.White);
            tbPostU.Background = new SolidColorBrush(Colors.White);
            tbNikcName.Foreground = new SolidColorBrush(Colors.Black);
            tbLoginU.Foreground = new SolidColorBrush(Colors.Black);
            tbPassU.Foreground = new SolidColorBrush(Colors.Black);
            tbPostU.Foreground = new SolidColorBrush(Colors.Black);
            mainWindow.btPage1.Visibility = Visibility.Collapsed;
            mainWindow.btPage2.Visibility = Visibility.Collapsed;
        }

        private void BtClickBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
        private void ImageClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "*Jpeg images|*.jpg|All files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                users.ImagePreview = File.ReadAllBytes(openFile.FileName);
            }
        }

        /* private void BtClickDel(object sender, RoutedEventArgs e)
         {
             if (users.IdUsers == 0)
             {
                 MessageBox.Show("Пользователь не существует");
                 btDel.IsEnabled = false;
             }
             else
             {

                 btDel.IsEnabled = true;
                 if (MessageBox.Show("Вы действительно хотите удалить: " + users.NickName, "Удаление", MessageBoxButton.YesNo)
                     == MessageBoxResult.Yes)
                 {
                     Mouse.OverrideCursor = Cursors.Wait;
                     EfModel.Init().Users.Remove(users);
                     EfModel.Init().SaveChanges();
                     Mouse.OverrideCursor = null;
                     NavigationService.Navigate(new Page1());
                 }
             }

         }*/
    }
}
