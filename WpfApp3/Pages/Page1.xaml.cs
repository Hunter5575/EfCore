﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        EfModel efModel = new EfModel();
        private void UpdateData()
        {
            
            if (LvUsers == null)
                return;

            
                IEnumerable<User> UserList = EfModel.Init().Users.Where(u => u.NickName.Contains(tbSearch.Text)).ToList();
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
                        UserList = UserList.Where(p => p.Post == "Admin");
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
            if (AuthClass.user.Post == "Admin")
            {
                btAdd.Visibility = Visibility.Visible;

            }
            UpdateData();

        }

        //public class UsersRepository
        //{
        //    Page1 page1 = new Page1();
        //    private ObservableCollection<User> users;
        //    public UsersRepository()
        //    {
        //        users = new ObservableCollection<User>()
        //        {
        //            new User{NickName="Анатолий Рогатая крыса", Post="Admin"}
        //            //new User{NickName="Анатолий Рогатая крыса", Post="Admin" }
        //        };
        //    }
        //    public ObservableCollection<User> GetUsers()
        //    {
        //        return users;
        //    }
        //}


        private void btUserClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            
            User users = (sender as Button).DataContext as User;
            UsersAdd usersAdd = new UsersAdd(users);
            NavigationService.Navigate(new UsersAdd(users));
            Grid.SetColumnSpan(mainWindow, 2);



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
            if (LvUsers.SelectedItems.Count >0)
            {
                User users = LvUsers.SelectedItems[0] as User; 
                if (MessageBox.Show("Вы удаляете пользователя: " + users.NickName + "?", "Удалить пользователь", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    EfModel.Init().Users.Remove(users);
                    EfModel.Init().SaveChanges();
                }
                UpdateData();
            }
        }

        private void BtClickEdit(object sender, RoutedEventArgs e)
        {

        }

        private void btBackClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void addVisChan(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateData();
        }
    }
}

