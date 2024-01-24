using SQLiteDataAccess;
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
        SQLiteDataAccess.User user;
        string connectionString = @"Data Source=..\..\..\..\Database\itpmentoring.db;Version=3;";
        public CourseManagment(SQLiteDataAccess.User user)
        {
            InitializeComponent();
            this.user = user;
            List<Course> courses = SQLiteDataAccess.SqliteDataAccess.LoadCourses(connectionString);
            Course_lbx.Items.Clear();
            for (int i = 0; i < courses.Count; i++) Course_lbx.Items.Add(courses[i].ToString());
        }
        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Settings(6, user);
        }
        public void edit_btn_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(Course_lbx.SelectedItem.ToString()))
            {
                var dialog = new InputDialog(Course_lbx.SelectedItem.ToString());

                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    MessageBoxResult mResult = MessageBox.Show("Sind Sie sicher, dass Sie diesen Kurs bearbeiten wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (mResult == MessageBoxResult.Yes)
                    {
                        List<Course> allCourses = SqliteDataAccess.LoadCourses(connectionString);
                        int courseID = -1;
                        for(int i = 0; i < allCourses.Count; i++)
                            if(allCourses[i].Coursename == Course_lbx.SelectedItem.ToString()) courseID = allCourses[i].CourseID;
                        Course_lbx.SelectedItem = dialog.InputText;
                        SqliteDataAccess.UpdateCourse(connectionString, new Course(courseID, dialog.InputText));
                        List<Course> courses = SQLiteDataAccess.SqliteDataAccess.LoadCourses(connectionString);
                        Course_lbx.Items.Clear();
                        for (int i = 0; i < courses.Count; i++) Course_lbx.Items.Add(courses[i].ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Kurs aus, um ihn zu bearbeiten.");
            }
        }

        public void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Course_lbx.SelectedItems.Count == 1)
            {
                MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie diesen Kurs löschen wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    DeleteSelectedItems();
                }
            }
            else
            {
                MessageBox.Show("Wählen Sie einen Kurs aus, um diesen zu löschen", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void DeleteSelectedItems()
        {
            var selectedItems = new List<object>(Course_lbx.SelectedItems.Cast<object>());

            foreach (var item in selectedItems)
            {
                List<Course> allCourses = SqliteDataAccess.LoadCourses(connectionString);
                Course_lbx.Items.Remove(item);
                int courseID = -1;
                for (int i = 0; i < allCourses.Count; i++)
                    if (allCourses[i].Coursename == item.ToString()) courseID = allCourses[i].CourseID;
                SqliteDataAccess.DeleteCourse(connectionString, courseID);
            }
        }
    }
}



