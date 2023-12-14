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
        private void register_btn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(pwd_pbx.Password))
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Content = new Student();
            }
        }




    }
}
