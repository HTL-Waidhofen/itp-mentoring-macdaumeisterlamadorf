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
        SQLiteDataAccess.User user;
        private string lang, appearance;
        string connectionString = @"Data Source=..\..\..\..\Database\itpmentoring.db;Version=3;";
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        private DispatcherTimer timer = new DispatcherTimer();
        public Settings(int index, SQLiteDataAccess.User user)
        {
            InitializeComponent();
            this.user = user;
            lang = user.Language;
            //appearance = user.Appearance.ToString();
            Index = index;
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += ChangeColor;
            timer.Start();
            if(lang == "en")
                language_cbx.SelectedIndex = 0;
            else if(lang == "de")
                language_cbx.SelectedIndex = 1;
            int appIndex = -1;
            if (user.Appearance == 's')
                appIndex = 0;
            else if (user.Appearance == 'd')
                appIndex = 1;
            else if (user.Appearance == 'l')
                appIndex = 2;
                appearance_cbx.SelectedIndex = appIndex;
        }
            Brush? dark = (Brush?)new BrushConverter().ConvertFromString("#505050");
            Brush? light = (Brush?)new BrushConverter().ConvertFromString("#FFFFFF");

        private void ChangeColor(object sender, EventArgs e)
        {
            if (appearance == "s")
                appearance_cbx.SelectedIndex = 0;
            else if(appearance == "d")
                appearance_cbx.SelectedIndex = 1;
            else if(appearance == "l")
                appearance_cbx.SelectedIndex = 2;
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
            if (lang == "en")
            {
                language_cbx.SelectedIndex = -1;
                language_cbx.SelectedIndex = 0;
            }
            else if (lang == "de")
            {
                language_cbx.SelectedIndex = -1;
                language_cbx.SelectedIndex = 1;
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
                            SetColor(light, dark, "/Images/return_button_black.png");
                        break;
                        case 1:
                            SetColor(dark, light, "/Images/return_button_white.png");
                        break;
                    }
                    SQLiteDataAccess.SqliteDataAccess.UpdateUser(connectionString, new SQLiteDataAccess.User(user.ID, 's', user.Language, user.Firstname, user.Lastname, user.Email, user.Password, user.MentorID_FK, user.Class));
                    break;
                case 1:
                    SetColor(Brushes.Black, light, "/Images/return_button_black.png");
                    SQLiteDataAccess.SqliteDataAccess.UpdateUser(connectionString, new SQLiteDataAccess.User(user.ID, 'd', user.Language, user.Firstname, user.Lastname, user.Email, user.Password, user.MentorID_FK, user.Class));
                    break;
                case 2:
                    SetColor(light, dark, "/Images/return_button_white.png");
                    SQLiteDataAccess.SqliteDataAccess.UpdateUser(connectionString, new SQLiteDataAccess.User(user.ID, 'l', user.Language, user.Firstname, user.Lastname, user.Email, user.Password, user.MentorID_FK, user.Class));
                    break;
            }
        }
        private void SetColor(Brush foreground, Brush background, string path = "")
        {
            return_btn_img.Source = new BitmapImage(new Uri(path, UriKind.Relative));
            mainWindow.Foreground = foreground;
            mainWindow.Background = background;
            List<DependencyObject> children = GetAllChildren(mainWindow);
            foreach (DependencyObject child in children)
            {
                if(VisualTreeHelper.GetParent(child) is ContentPresenter) { }
                else
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
            SQLiteDataAccess.SqliteDataAccess.UpdateUser(connectionString, new SQLiteDataAccess.User(user.ID, user.Appearance, lang, user.Firstname, user.Lastname, user.Email, user.Password, user.MentorID_FK, user.Class));
            XElement file = XElement.Load(@$"..\..\..\..\Ressources.{lang}.resx");
            var childrenD = GetAllChildren(mainWindow);
            foreach (var f in file.Elements("data"))
            {
                for(int i = 0; i < childrenD.Count; i++)
                {
                       if (childrenD[i] is TextBlock textBlock)
                        if(textBlock.Name == f.Attribute("name").Value)
                             textBlock.Text = f.Value.Replace("\n", "").Trim();
                       if (childrenD[i] is ComboBox comboBox)
                        if(comboBox.Name == f.Attribute("name").Value)
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
                    mainWindow.Content = new Register();
                    break;
                case 3:
                    mainWindow.Content = new Student(user);
                    break;
                case 4:
                    mainWindow.Content = new Mentors(user);
                    break;
                case 5:
                    mainWindow.Content = new Admin(user);
                    break;
                case 6:
                    mainWindow.Content = new CourseManagment(user);
                    break;
                case 7:
                    mainWindow.Content = new UserManagement_Students(user);
                    break;
                case 8:
                    mainWindow.Content = new UserManagement_Mentors(user);
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
            mainWindow.Content = new Startpage();
        }

        private void gc_switchToMentorpage_btn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Mentors(user);
        }
    }
}
