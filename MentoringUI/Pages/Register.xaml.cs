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

    }
}
