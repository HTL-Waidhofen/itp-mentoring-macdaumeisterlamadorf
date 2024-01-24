using SQLiteDataAccess;
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
        string connectionString = @"Data Source=..\..\..\..\Database\itpmentoring.db;Version=3;";

        SQLiteDataAccess.User user;
        public Mentors(SQLiteDataAccess.User user)
        {
            InitializeComponent();

            this.user = user;
            List<Course> courses = SQLiteDataAccess.SqliteDataAccess.LoadCourses(connectionString);
            courses_lbx.Items.Clear();
            for (int i = 0; i < courses.Count; i++) courses_lbx.Items.Add(courses[i]);
        }
        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Settings(4, user);
        }

        private void saveCourses_btn_Click(object sender, RoutedEventArgs e)
        {
            string courses = "";
            for(int i = 0; i < courses_lbx.SelectedItems.Count; i++)
            {
                courses += courses_lbx.SelectedItems[i].ToString() + ",";
            }
            courses = courses.Substring(0, courses.Length - 1);
            List<Mentor> mentors = SqliteDataAccess.LoadMentors(connectionString);
            Mentor mentor = null;
            for (int i = 0; i < mentors.Count; i++)
            {
                if (mentors[i].MentorID == user.MentorID_FK) mentor = mentors[i];
            }
            SqliteDataAccess.UpdateMentor(connectionString, new Mentor(mentor.MentorID, courses));
        }
    }
}
