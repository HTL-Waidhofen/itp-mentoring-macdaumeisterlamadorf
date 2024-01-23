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
    /// Interaktionslogik für Registrierung.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void firstname_txb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (firstname_tbx.Foreground == Brushes.Gray)
                firstname_tbx.Text = null;
            firstname_tbx.Foreground = Brushes.Black;
        }
        private void firstname_txb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(firstname_tbx.Text))
            {
                firstname_tbx.Text = "Vorname";
                firstname_tbx.Foreground = Brushes.Gray;
            }
        }
        private void name_txb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name_tbx.Foreground == Brushes.Gray)
                name_tbx.Text = null;
            name_tbx.Foreground = Brushes.Black;
        }

        private void name_txb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name_tbx.Text))
            {
                name_tbx.Text = "Nachname";
                name_tbx.Foreground = Brushes.Gray;
            }
        }
        private void email_txb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (email_tbx.Foreground == Brushes.Gray)
                email_tbx.Text = null;
            email_tbx.Foreground = Brushes.Black;
        }
        private void email_txb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(email_tbx.Text))
            {
                email_tbx.Text = "Email";
                email_tbx.Foreground = Brushes.Gray;
            }
        }

        private void InitializePasswordBox()
        {
            ShowPasswordBox();
            ShowPlaceholderTextBox();

            PasswordBox_PasswordChanged(null, null);
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pwd_pbx.Password))
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
            pwd_pbx.Focus();
        }

        private void PlaceholderTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pwd_pbx.Password))
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
            pwd_pbx.Visibility = Visibility.Visible;
        }

        private void ShowPlaceholderTextBox()
        {
            placeholderPwd_tbx.Visibility = Visibility.Visible;
        }

        private void HidePlaceholderTextBox()
        {
            placeholderPwd_tbx.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            placeholderPwd_tbx.Text = null;
        }
        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            placeholderPwd_tbx.Text = "Passwort";
        }

        private void InitializeConfirmPasswordBox()
        {
            ShowConfirmPasswordBox();
            ShowConfirmPlaceholderTextBox();

            ConfirmPasswordBox_PasswordChanged(null, null);
        }


        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(confirmpwd_pbx.Password))
            {
                ShowConfirmPlaceholderTextBox();
            }
            else
            {
                HideConfirmPlaceholderTextBox();
            }
        }

        private void ConfirmPlaceholderTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            confirmpwd_pbx.Focus();
        }

        private void ConfirmPlaceholderTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(confirmpwd_pbx.Password))
            {
                ShowConfirmPlaceholderTextBox();
            }
            else
            {
                HideConfirmPlaceholderTextBox();
            }
        }

        private void ShowConfirmPasswordBox()
        {
            confirmpwd_pbx.Visibility = Visibility.Visible;
        }

        private void ShowConfirmPlaceholderTextBox()
        {
            confirmplaceholderPwd_tbx.Visibility = Visibility.Visible;
        }

        private void HideConfirmPlaceholderTextBox()
        {
            confirmplaceholderPwd_tbx.Visibility = Visibility.Collapsed;
        }

        private void ConfirmPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            confirmplaceholderPwd_tbx.Text = null;
        }
        private void ConfirmPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            confirmplaceholderPwd_tbx.Text = "Passwort bestätigen";
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(placeholderPwd_tbx.Text) && !string.IsNullOrEmpty(pwd_pbx.Password))
            {
                placeholderPwd_tbx.Foreground = Brushes.Black;
                placeholderPwd_tbx.Text = pwd_pbx.Password.ToString();
                placeholderPwd_tbx.Visibility = Visibility.Visible;
                pwd_pbx.Visibility = Visibility.Collapsed;
            }
        }
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(placeholderPwd_tbx.Text) && !string.IsNullOrEmpty(pwd_pbx.Password))
            {
                pwd_pbx.Visibility = Visibility.Visible;
                placeholderPwd_tbx.Visibility = Visibility.Collapsed;
            }
        }
        private void ConfirmToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(confirmplaceholderPwd_tbx.Text) && !string.IsNullOrEmpty(confirmpwd_pbx.Password))
            {
                confirmplaceholderPwd_tbx.Foreground = Brushes.Black;
                confirmplaceholderPwd_tbx.Text = confirmpwd_pbx.Password.ToString();
                confirmplaceholderPwd_tbx.Visibility = Visibility.Visible;
                confirmpwd_pbx.Visibility = Visibility.Collapsed;
            }
        }
        private void ConfirmToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(confirmplaceholderPwd_tbx.Text) && !string.IsNullOrEmpty(confirmpwd_pbx.Password))
            {
                confirmpwd_pbx.Visibility = Visibility.Visible;
                confirmplaceholderPwd_tbx.Visibility = Visibility.Collapsed;
            }
        }

        private void register_btn_Click(object sender, RoutedEventArgs e)
        {
            
            
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Email_Verification();

                
            
        }




    }
}
