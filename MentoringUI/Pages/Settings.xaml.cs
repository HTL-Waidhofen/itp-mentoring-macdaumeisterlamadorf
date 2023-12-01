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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using i18n;
using Microsoft.Win32;

namespace MentoringUI
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        int Index;
        private DispatcherTimer timer = new DispatcherTimer();
        public Settings(int index)
        {
            InitializeComponent();
            Index = index;
        }
            Brush? dark = (Brush?)new BrushConverter().ConvertFromString("#505050");
            Brush? light = (Brush?)new BrushConverter().ConvertFromString("#FFFFFF");

        private void ChangeColor(object sender, EventArgs e)
        {
            if(appearance_cbx.SelectedIndex == 0)
            switch (int.Parse(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString()))
            {
                case 0:
                    SetColor(light, dark);
                    return_btn_img.Source = new BitmapImage(new Uri("/Images/return_button_dark.png", UriKind.Relative));
                    break;
                case 1:
                    SetColor(dark, light);
                    return_btn_img.Source = new BitmapImage(new Uri("/Images/return_button_white.png", UriKind.Relative));
                    break;
            }
        }

        private void appearance_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(appearance_cbx.SelectedIndex)
            {
                case 0:
                    switch (int.Parse(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString()))
                    {
                        case 0:
                            SetColor(light, dark);
                    return_btn_img.Source = new BitmapImage(new Uri("/Images/return_button_dark.png", UriKind.Relative));
                        break;
                        case 1:
                            SetColor(dark, light);
                    return_btn_img.Source = new BitmapImage(new Uri("/Images/return_button_white.png", UriKind.Relative));
                        break;
                    }
                    break;
                case 1:
                    SetColor(light, dark);
                    return_btn_img.Source = new BitmapImage(new Uri("/Images/return_button_white.png", UriKind.Relative));
                    break;
                case 2:
                    SetColor(dark, light);
                    return_btn_img.Source = new BitmapImage(new Uri("/Images/return_button_black.png", UriKind.Relative));
                    break;
            }
        }
        private void SetColor(Brush foreground, Brush background)
        {
            ((MainWindow)Application.Current.MainWindow).Background = background;
            ((MainWindow)Application.Current.MainWindow).Foreground = foreground;
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
