using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für Mentors.xaml
    /// </summary>
    public partial class Mentors : Page
    {
        private ObservableCollection<string> allMentors;
        SQLiteDataAccess.User user;
        public Mentors(SQLiteDataAccess.User user)
        {
            InitializeComponent();

            filterTextBox.TextChanged += FilterTextBox_TextChanged;
            this.user = user;
        }
        private void FilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string filterText = filterTextBox.Text.ToLower();

            var filteredMentors = allMentors.Where(mentor => mentor.ToLower().Contains(filterText)).ToList();

            mentorslbx.ItemsSource = filteredMentors;
        }

        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Settings(4, user);
        }
    }
}
