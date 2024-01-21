﻿using System.Data.SQLite;
namespace SQLiteDataAccess
{
    public class SqliteDataAccess
    {
        static void AddUser(string connectionString, User user)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO User(appearance, language, firstname, lastname, email, phonenumber, password, mentorID_FK, class) VALUES(@appearance, @language, @firstname, @lastname, @email, @phonenumber, @password, @mentorID_FK, @class)";
                    cmd.Parameters.AddWithValue("@appearance", user.Appearance.ToString());
                    cmd.Parameters.AddWithValue("@language", user.Language);
                    cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phonenumber", user.Phonenumber);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@mentorID_FK", user.MentorID_FK);
                    cmd.Parameters.AddWithValue("@class", user.Class);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
    public class User
    {
        public int ID { get; set; }
        public char Appearance { get; set; }
        public string Language { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
        public int MentorID_FK { get; set; }
        public string Class { get; set; }

        public User(char appearance, string language, string firstname, string lastname, string email, string phonenumber, string password, int mentorID_FK, string @class)
        {
            Appearance = appearance;
            Language = language;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Phonenumber = phonenumber;
            Password = password;
            MentorID_FK = mentorID_FK;
            Class = @class;
        }

        public User(int ID, char appearance, string language, string firstname, string lastname, string email, string phonenumber, string password, int mentorID_FK, string @class)
        {
            this.ID = ID;
            Appearance = appearance;
            Language = language;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Phonenumber = phonenumber;
            Password = password;
            MentorID_FK = mentorID_FK;
            Class = @class;
        }
    }
    public class Mentor
    {
        public int MentorID { get; set; }
        public string Courses { get; set; }
        public Mentor(string courses)
        {
            Courses = courses;
        }
        public Mentor(int mentorID, string courses)
        {
            MentorID = mentorID;
            Courses = courses;
        }
    }
    public class Display
    {
        public int DisplayID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Course { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int MentorID_FK { get; set; }
        public Display(int displayID, string startTime, string endTime, string course, string price, string description, int mentorID_FK)
        {
            DisplayID = displayID;
            StartTime = startTime;
            EndTime = endTime;
            Course = course;
            Price = price;
            Description = description;
            MentorID_FK = mentorID_FK;
        }
        public Display(string startTime, string endTime, string course, string price, string description, int mentorID_FK)
        {
            StartTime = startTime;
            EndTime = endTime;
            Course = course;
            Price = price;
            Description = description;
            MentorID_FK = mentorID_FK;
        }
    }
    public class Course
    {
        public string Coursename { get; set; }
        public int CourseID { get; set; }
        public Course(string coursename)
        {
            Coursename = coursename;
        }
        public Course(int courseID, string coursename)
        {
            CourseID = courseID;
            Coursename = coursename;
        }
    }
}