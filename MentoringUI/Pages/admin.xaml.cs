﻿using System;
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

namespace MentoringUI
{
    /// <summary>
    /// Interaktionslogik für admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        SQLiteDataAccess.User user;
        public Admin(SQLiteDataAccess.User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void setting_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Settings(5, user);
        }

        private void course_management_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.Content = new CourseManagment(user);
        }

        private void user_management_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            mainWindow.Content = new UserManagement_Students(user);
        }
    }
}
