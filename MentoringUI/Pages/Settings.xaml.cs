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
using i18n;

namespace MentoringUI
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        int Index;
        public Settings(int index)
        {
            InitializeComponent();
            Index = index;
        }

        private void appearance_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush? dark = (Brush?)new BrushConverter().ConvertFromString("#505050");
            Brush? light = (Brush?)new BrushConverter().ConvertFromString("#FFFFFF");
            switch(appearance_cbx.SelectedIndex)
            {
                case 1:
                    ((MainWindow)Application.Current.MainWindow).Background = dark;
                    ((MainWindow)Application.Current.MainWindow).Foreground = light;
                    return_btn_img.Source = new BitmapImage(new Uri("/Images/return_button_white.png", UriKind.Relative));
                    break;
                case 2:
                    ((MainWindow)Application.Current.MainWindow).Background = light;
                    ((MainWindow)Application.Current.MainWindow).Foreground = dark;
                    return_btn_img.Source = new BitmapImage(new Uri("/Images/return_button_black.png", UriKind.Relative));
                    break;
            }
        }

        private void language_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            switch(Index)
            {
                case 0:
                    mainWindow.Content = new Startpage();
                    break;
                case 1:
                    mainWindow.Content = new Login();
                    break;
                case 2:
                    mainWindow.Content = new Login();
                    break;
                case 3:
                    mainWindow.Content = new Student();
                    break;
                case 4:
                    mainWindow.Content = new Mentors();
                    break;
                case 5:
                    mainWindow.Content = new Admin();
                    break;
                case 6:
                    mainWindow.Content = new CourseManagment();
                    break;
                case 7:
                    mainWindow.Content = new UserManagement_Students();
                    break;
                case 8:
                    mainWindow.Content = new UserManagement_Mentors();
                    break;


            }
        }
    }
}
