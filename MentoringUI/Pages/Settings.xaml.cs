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
using System.Resources;

namespace MentoringUI
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        int Index;
        private string lang = "";
        private DispatcherTimer timer = new DispatcherTimer();
        public Settings(int index)
        {
            InitializeComponent();

            Index = index;
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += ChangeColor;
            timer.Start();
        }
            Brush? dark = (Brush?)new BrushConverter().ConvertFromString("#505050");
            Brush? light = (Brush?)new BrushConverter().ConvertFromString("#FFFFFF");

        private void ChangeColor(object sender, EventArgs e)
        {
            if(appearance_cbx.SelectedIndex == 0)
            switch (int.Parse(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString()))
            {
                case 0:
                    SetColor(light, dark, "/Images/return_button_white.png");
                    break;
                case 1:
                    SetColor(Brushes.Black, light, "/Images/return_button_black.png");
                    break;
            }
            else if(appearance_cbx.SelectedIndex == 1)
                SetColor(light, dark, "/Images/return_button_white.png");
            else if(appearance_cbx.SelectedIndex == 2)
                SetColor(Brushes.Black, light, "/Images/return_button_black.png");
        }

        private void appearance_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(appearance_cbx.SelectedIndex)
            {
                case 0:
                    switch (int.Parse(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString()))
                    {
                        case 0:
                            SetColor(light, dark, "/Images/return_button_black.png");
                        break;
                        case 1:
                            SetColor(dark, light, "/Images/return_button_white.png");
                        break;
                    }
                    break;
                case 1:
                    SetColor(Brushes.Black, light, "/Images/return_button_black.png");
                    break;
                case 2:
                    SetColor(light, dark, "/Images/return_button_white.png");
                    break;
            }
        }
        private void SetColor(Brush foreground, Brush background, string path = "")
        {
            return_btn_img.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            ((MainWindow)Application.Current.MainWindow).Foreground = foreground;
            ((MainWindow)Application.Current.MainWindow).Background = background;
            List<Control> children = GetAllChildren(((MainWindow)Application.Current.MainWindow));
            foreach (Control child in children)
            {
                if(child != null)
                {
                    if (child.Name.StartsWith("gc"))
                    {
                        if (foreground == light)
                            child.Background = (Brush?)new BrushConverter().ConvertFromString("#999999");
                        else
                            child.Background = (Brush?)new BrushConverter().ConvertFromString("#CCCCCC");
                    }
                else if(!child.Name.StartsWith("nc"))
                {
                        if(child is ComboBox comboBox)
            {
                            foreach (var comboItem in comboBox.Items)
                            {
                                if (comboItem is ComboBoxItem comboBoxItem)
                                {
                                    if (foreground == light)
                                        comboBoxItem.Background = (Brush?)new BrushConverter().ConvertFromString("#999999");
                                    else
                                        comboBoxItem.Background = Brushes.White;
                                }
                            }
                        }

                }
                }
            }
        }
        private void language_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(language_cbx.SelectedIndex)
            {
                case 0:
                    lang = "en";
                    break;
                case 1:
                    lang = "de";
                    break;
            }
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
        private List<Control> GetAllChildren(DependencyObject parent)
        {
            List<Control> children = new List<Control>();
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                children.Add(child as Control);
                children.AddRange(GetAllChildren(child));
            }
            return children; 
        }

        private void nc_logout_btn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Content = new Startpage();
        }

        private void gc_switchToMentorpage_btn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Content = new Mentors();
        }
    }
}
