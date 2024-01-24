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
    /// Interaktionslogik für Student.xaml
    /// </summary>
    public partial class Student : Page
    {
        SQLiteDataAccess.User user;
        string connectionString = @"Data Source=..\..\..\..\Database\itpmentoring.db;Version=3;";
        public Student(SQLiteDataAccess.User user)
        {
            InitializeComponent();
            this.user = user;
            List<Course> courses = SQLiteDataAccess.SqliteDataAccess.LoadCourses(connectionString);
            allCourses_lbx.Items.Clear();
            for (int i = 0; i < courses.Count; i++) allCourses_lbx.Items.Add(courses[i]);
        }

        private void setting_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Settings(3, user);
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

        private void allCourses_lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Mentor> mentors = SqliteDataAccess.LoadMentors(connectionString);
            List<User> users = SqliteDataAccess.LoadUsers(connectionString);
            List<Mentor> mentorsWithCourse = new List<Mentor>();
            foreach(Mentor mentor in mentors)
            {
                if (mentor.Courses.Contains(allCourses_lbx.SelectedItem.ToString()))
                    mentorsWithCourse.Add(mentor);
            }
            mentorSelection_lbx.Items.Clear();
            foreach(Mentor mentor in mentorsWithCourse)
            {
                    for(int i = 0; i < users.Count; i++)
                    {
                        if(mentor.MentorID == users[i].MentorID_FK)
                               mentorSelection_lbx.Items.Add($"Name: {users[i].Firstname} {users[i].Lastname};Class: {users[i].Class};Email: {users[i].Email};Courses: {mentor.Courses}");
                    }
            }
        }
    }
}
