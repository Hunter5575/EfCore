using System;
using System.Collections.Generic;
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
using WpfApp3.Database;

namespace WpfApp3.Pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private void UpdateData()
        {
            if (dgvUsers == null)
                return;
            IEnumerable<User> UserDGV = EfModel.Init().Users.Where(u => u.NickName.Contains(tbSearch.Text)).ToList();
            if (cbSort.SelectedIndex == 0)
            {
                UserDGV = UserDGV.OrderByDescending(p => p.NickName);
            }
            else
            {
                UserDGV = UserDGV.OrderBy(p => p.NickName);
            }

            switch (cbFiltr.SelectedIndex)
            {
                case 0:
                    UserDGV = UserDGV.Where(p => p.Post == "Admin");
                    break;
                case 1:
                    UserDGV = UserDGV.Where(p => p.Post == "User");
                    break;
            }


            dgvUsers.ItemsSource = UserDGV;
        }
        public Page2()
        {
            InitializeComponent();
            dgvUsers.ItemsSource = EfModel.Init().Users.ToList();
        }

        private void btAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersAdd(new User()));
        }
        private void btUserClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            User users = (sender as Button).DataContext as User;
            UsersAdd usersAdd = new UsersAdd(users);
            NavigationService.Navigate(new UsersAdd(users));
            Grid.SetColumnSpan(mainWindow, 2);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void SortPost(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FiltrPost(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
