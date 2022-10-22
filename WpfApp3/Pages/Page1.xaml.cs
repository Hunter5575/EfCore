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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private void UpdateData() {
            if (LvUsers == null)
                return;
            IEnumerable<User> UserList = EfModel.Init().Users.Where(u=>u.NickName.Contains(tbSearch.Text)).ToList();
            if (cbSort.SelectedIndex == 0)
            {
                UserList = UserList.OrderByDescending(p => p.NickName);
            }
            else 
            {
                UserList = UserList.OrderBy(p => p.NickName);
            }

            switch (cbFiltr.SelectedIndex) 
            {
                case 0:
                    UserList= UserList.Where(p => p.Post=="Admin");
                    break;
                case 1:
                    UserList = UserList.Where(p => p.Post == "User");
                    break;
            }


            LvUsers.ItemsSource = UserList;
        }
        
        public Page1()
        {
            
            InitializeComponent();
            UpdateData();
            
        }

        private void btUserClick(object sender, RoutedEventArgs e)
        {
            User users = (sender as Button).DataContext as User;
            NavigationService.Navigate(new UsersAdd(users));

        }

        private void btAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsersAdd(new User()));

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
        private void BtClickDel(object sender, RoutedEventArgs e)
        {
            /*if (LvUsers.SelectedItem != null) ;
            EfModel.Init().Users.Remove(users);
            EfModel.Init().SaveChanges();
            Mouse.OverrideCursor = null;*/
            

        }
    }
}
