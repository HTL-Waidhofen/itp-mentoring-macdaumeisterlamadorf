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
    /// Interaktionslogik für CourseManagment.xaml
    /// </summary>
    public partial class CourseManagment : Page
    {
        public CourseManagment()
        {
            InitializeComponent();
        }
        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Settings();
        }
        private void delete(object sender, RoutedEventArgs e)
        {
            if (Course_lbx.SelectedItems.Count != 0)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete these Mentors?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    DeleteSelectedItems();
                }
            }
            else
            {
                MessageBox.Show("Select Mentors to delete them", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void DeleteSelectedItems()
        {
            var selectedItems = new List<object>(Course_lbx.SelectedItems.Cast<object>());
            foreach (var item in selectedItems)
            {
                Course_lbx.Items.Remove(item);
            }
        }
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeight = e.NewSize.Height - 180;
            Course_lbx.Height = newHeight;
        }
        private void ListBoxItem_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}



