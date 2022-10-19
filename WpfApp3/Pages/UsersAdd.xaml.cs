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
    /// Interaction logic for UsersAdd.xaml
    /// </summary>
    public partial class UsersAdd : Page
    {
        User users;
        public UsersAdd(User users)
        {
            this.users = users;
            InitializeComponent();
            DataContext = users;
        }

        private void BtClickSave(object sender, RoutedEventArgs e)
        {
            if (users.IdUsers == 0)
                EfModel.Init().Users.Add(users);
            EfModel.Init().SaveChanges();
            
            NavigationService.Navigate(new Page1());

        }

        private void BtClickDel(object sender, RoutedEventArgs e)
        {
            EfModel.Init().Users.Remove(users);
            EfModel.Init().SaveChanges();
            Mouse.OverrideCursor = null;
            NavigationService.Navigate(new Page1());

        }
    }
}
