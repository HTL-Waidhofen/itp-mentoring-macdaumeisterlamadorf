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
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class Email_Verification : Page
    {
        public Email_Verification()
        {
            InitializeComponent();
        }
        private void TestNumbers_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TestNumbers..Foreground == Brushes.Gray)
                email_txb.Text = null;
            email_txb.Foreground = Brushes.Black;
        }

        private void email_txb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(email_txb.Text))
            {
                email_txb.Text = "Enter Email here";
                email_txb.Foreground = Brushes.Gray;
            }
        }
    }
}
