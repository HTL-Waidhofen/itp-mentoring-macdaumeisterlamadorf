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

namespace MentoringUI
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void email_txb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(email_txb.Text))
            {
                email_txb.Text = "Email";
                email_txb.Foreground = Brushes.Gray;
            }
        }
        private void email_txb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (email_txb.Foreground == Brushes.Gray)
                email_txb.Text = null;
            email_txb.Foreground = Brushes.Black;
        }

        private void pwd_txb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pwd_txb.Text))
            {
                pwd_txb.Text = "Password";
                pwd_txb.Foreground = Brushes.Gray;
            }
        }
        private void pwd_txb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pwd_txb.Foreground == Brushes.Gray)
                pwd_txb.Text = null;
            pwd_txb.Foreground = Brushes.Black;
        }

        private void hyperlinkToRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Register();
        }
    }
}
