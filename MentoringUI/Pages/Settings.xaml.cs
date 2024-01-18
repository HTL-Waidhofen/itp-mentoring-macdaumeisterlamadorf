using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
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
using System.Xml.Linq;
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
        private string lang = "de";
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
            language_cbx_SelectionChanged(null, null);
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
            List<DependencyObject> children = GetAllChildren(((MainWindow)Application.Current.MainWindow));
            foreach (DependencyObject child in children)
            {
                 if (child is TextBlock textBlock)
                 {
                    if (!textBlock.Name.StartsWith("nc"))
                    {
                        if (foreground == light)
                        {
                            textBlock.Background = dark;
                            textBlock.Foreground = light;
                        }
                        else
                        {
                            textBlock.Background = light;
                            textBlock.Foreground = dark;
                        }
                    }
                 }
                 else if (child is Button button)
                 {
                    if (!button.Name.StartsWith("nc"))
                    {
                        if (foreground == light)
                        {
                            button.Background = dark;
                            button.Foreground = light;
                        }
                        else
                        {
                            button.Background = light;
                            button.Foreground = dark;
                        }
                    }
                 }
                 else if(child is ComboBox comboBox)
                foreach (var comboItem in comboBox.Items)
                {
                    if (comboItem is ComboBoxItem comboBoxItem)
                    {
                        if (foreground == light)
                            {
                            comboBoxItem.Background = dark;
                            comboBoxItem.Foreground = light;

                            }
                            else
                            {
                            comboBoxItem.Background = light;
                            comboBoxItem.Foreground = dark;
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
            XElement file = XElement.Load(@$"..\..\..\..\Ressources.{lang}.resx");
            var childrenD = GetAllChildren((MainWindow)Application.Current.MainWindow);
            foreach (var f in file.Elements("data"))
            {
                for(int i = 0; i < childrenD.Count; i++)
                {
                       if (childrenD[i] is TextBlock textBlock)
                        if(textBlock.Name == f.Attribute("name").Value)
                             textBlock.Text = f.Value.Replace("\n", "").Trim();
                       if (childrenD[i] is ComboBox comboBox)
                        if(comboBox.Name == f.Attribute("name").Value && comboBox.Name != "language_cbx")
                                 comboBox.Text = f.Value.Replace("\n", "").Trim();
                       if (childrenD[i] is Button button)
                        if(button.Name == f.Attribute("name").Value)
                                 button.Content = f.Value.Replace("\n", "").Trim();
                       if (childrenD[i] is GroupBox groupBox)
                        if(groupBox.Name == f.Attribute("name").Value)
                                 groupBox.Header = f.Value.Replace("\n", "").Trim();
                       
                }
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
        private List<DependencyObject> GetAllChildren(DependencyObject parent)
        {
            List<DependencyObject> children = new List<DependencyObject>();
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if(child!= null)
                {
                children.Add(child);
                children.AddRange(GetAllChildren(child));
                }
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
