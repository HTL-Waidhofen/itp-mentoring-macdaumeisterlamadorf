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
    /// Interaktionslogik für Student.xaml
    /// </summary>
    public partial class Student : Page
    {
        public Student()
        {
            InitializeComponent();
             
        }

        private void setting_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Settings();
        }

        private void mentorFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(mentorFilter.Text))
            {
                mentorFilter.Text = "Suche";
                mentorFilter.Foreground = Brushes.Gray;
            }
        }

        private void mentorFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (mentorFilter.Foreground == Brushes.Gray)
                mentorFilter.Text = null;
            mentorFilter.Foreground = Brushes.Black;
        }
    }
}
