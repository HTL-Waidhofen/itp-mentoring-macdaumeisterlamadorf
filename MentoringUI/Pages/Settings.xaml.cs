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
            Brush? dark = (Brush?)new BrushConverter().ConvertFromString("#35363A");
            Brush? light = (Brush?)new BrushConverter().ConvertFromString("#FFFFFF");
            switch(appearance_cbx.SelectedIndex)
            {
                case 0:
                    ((MainWindow)Application.Current.MainWindow).Background = dark;
                    break;
                case 1:
                    ((MainWindow)Application.Current.MainWindow).Background = light;
                    break;
            }
        }

        private void language_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void return_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
