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
            InitializePasswordBox();
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

        private void InitializePasswordBox()
        {
            // Set the initial visibility of the PasswordBox and placeholder TextBox
            ShowPasswordBox();
            ShowPlaceholderTextBox();

            // Call the PasswordChanged event handler to handle initial state
            PasswordBox_PasswordChanged(null, null);
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Show or hide the placeholder TextBox based on the PasswordBox content
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                ShowPlaceholderTextBox();
            }
            else
            {
                HidePlaceholderTextBox();
            }
        }

        private void PlaceholderTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Switch focus to the PasswordBox when the placeholder TextBox is clicked
            passwordBox.Focus();
        }

        private void PlaceholderTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show or hide the placeholder TextBox based on the PasswordBox content
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                ShowPlaceholderTextBox();
            }
            else
            {
                HidePlaceholderTextBox();
            }
        }

        private void ShowPasswordBox()
        {
            passwordBox.Visibility = Visibility.Visible;
        }

        private void ShowPlaceholderTextBox()
        {
            placeholderPwd_tbx.Visibility = Visibility.Visible;
        }

        private void HidePlaceholderTextBox()
        {
            placeholderPwd_tbx.Visibility = Visibility.Collapsed;
        }
    

        private void hyperlinkToRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Register();
        }
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
           //if(email_txb.Text==*Data from Datenbank*)
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Student();
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholderPwd_tbx.Text = null;
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholderPwd_tbx.Text = "Password";
        }
    }
}
