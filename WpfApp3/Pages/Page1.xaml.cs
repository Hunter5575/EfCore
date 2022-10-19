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
        public Page1()
        {
            InitializeComponent();
            LvUsers.ItemsSource = EfModel.Init().Users.ToList();
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
    }
}
