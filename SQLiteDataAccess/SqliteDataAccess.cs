using System.Data.SQLite;
namespace SQLiteDataAccess
{
    public class SqliteDataAccess
    {
        public static void AddUser(string connectionString, User user)
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
        public static void UpdateUser(string connectionString, User updatedUser)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string stm = "UPDATE User SET appearance = @appearance, language = @language, firstname = @firstname, " +
                             "lastname = @lastname, email = @email, phonenumber = @phonenumber, password = @password, " +
                             "mentorID_FK = @mentorID_FK, class = @class WHERE ID = @userID";

                using (var cmd = new SQLiteCommand(stm, connection))
                {
                    cmd.Parameters.AddWithValue("@appearance", updatedUser.Appearance.ToString());
                    cmd.Parameters.AddWithValue("@language", updatedUser.Language);
                    cmd.Parameters.AddWithValue("@firstname", updatedUser.Firstname);
                    cmd.Parameters.AddWithValue("@lastname", updatedUser.Lastname);
                    cmd.Parameters.AddWithValue("@email", updatedUser.Email);
                    cmd.Parameters.AddWithValue("@phonenumber", updatedUser.Phonenumber);
                    cmd.Parameters.AddWithValue("@password", updatedUser.Password);
                    cmd.Parameters.AddWithValue("@mentorID_FK", updatedUser.MentorID_FK);
                    cmd.Parameters.AddWithValue("@class", updatedUser.Class);
                    cmd.Parameters.AddWithValue("@userID", updatedUser.ID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteUser(string connectionString, int userID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string stm = "DELETE FROM User WHERE ID = @userID";

                using (var cmd = new SQLiteCommand(stm, connection))
                {
                    cmd.Parameters.AddWithValue("@userID", userID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<User> LoadUsers(string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                List<User> userList = new List<User>();
                string stm = "SELECT * FROM User";

                using (var cmd = new SQLiteCommand(stm, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = rdr.GetInt32(0);
                            char appearance = char.Parse(rdr.GetString(1));
                            string language = rdr.GetString(2);
                            string firstname = rdr.GetString(3);
                            string lastname = rdr.GetString(4);
                            string email = rdr.GetString(5);
                            string phoneNumber = rdr.GetString(6);
                            string password = rdr.GetString(7);
                            int mentorID = rdr.GetInt32(8);
                            string userClass = rdr.GetString(9);

                            userList.Add(new User(id, appearance, language, firstname, lastname, email, phoneNumber, password, mentorID, userClass));
                        }
                        return userList;
                    }
                }
            }
        }
        public static void AddMentor(string connectionString, Mentor mentor)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Mentor(courses) VALUES(@courses)";
                    cmd.Parameters.AddWithValue("@courses", mentor.Courses);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateMentor(string connectionString, Mentor updatedMentor)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string stm = "UPDATE Mentor SET courses = @courses WHERE mentorID = @mentorID";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    cmd.Parameters.AddWithValue("@courses", updatedMentor.Courses);
                    cmd.Parameters.AddWithValue("@mentorID", updatedMentor.MentorID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteMentor(string connectionString, int mentorID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string stm = "DELETE FROM Mentor WHERE mentorID = @mentorID";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    cmd.Parameters.AddWithValue("@mentorID", mentorID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Mentor> LoadMentors(string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                List<Mentor> mentorList = new List<Mentor>();
                string stm = "SELECT * FROM Mentor";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int mentorID = rdr.GetInt32(0);
                            string courses = rdr.GetString(1);

                            mentorList.Add(new Mentor(mentorID, courses));
                        }
                        return mentorList;
                    }
                }
            }
        }
        public static void AddDisplay(string connectionString, Display display)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Display(startTime, endTime, course, price, description, mentorID_FK) " +
                                      "VALUES(@startTime, @endTime, @course, @price, @description, @mentorID_FK)";
                    cmd.Parameters.AddWithValue("@startTime", display.StartTime);
                    cmd.Parameters.AddWithValue("@endTime", display.EndTime);
                    cmd.Parameters.AddWithValue("@course", display.Course);
                    cmd.Parameters.AddWithValue("@price", display.Price);
                    cmd.Parameters.AddWithValue("@description", display.Description);
                    cmd.Parameters.AddWithValue("@mentorID_FK", display.MentorID_FK);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateDisplay(string connectionString, Display updatedDisplay)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string stm = "UPDATE Display SET startTime = @startTime, endTime = @endTime, course = @course, " +
                             "price = @price, description = @description, mentorID_FK = @mentorID_FK WHERE displayID = @displayID";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    cmd.Parameters.AddWithValue("@startTime", updatedDisplay.StartTime);
                    cmd.Parameters.AddWithValue("@endTime", updatedDisplay.EndTime);
                    cmd.Parameters.AddWithValue("@course", updatedDisplay.Course);
                    cmd.Parameters.AddWithValue("@price", updatedDisplay.Price);
                    cmd.Parameters.AddWithValue("@description", updatedDisplay.Description);
                    cmd.Parameters.AddWithValue("@mentorID_FK", updatedDisplay.MentorID_FK);
                    cmd.Parameters.AddWithValue("@displayID", updatedDisplay.DisplayID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteDisplay(string connectionString, int displayID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string stm = "DELETE FROM Display WHERE displayID = @displayID";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    cmd.Parameters.AddWithValue("@displayID", displayID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Display> LoadDisplays(string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                List<Display> displayList = new List<Display>();
                string stm = "SELECT * FROM Display";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int displayID = rdr.GetInt32(0);
                            string startTime = rdr.GetString(1);
                            string endTime = rdr.GetString(2);
                            string course = rdr.GetString(3);
                            string price = rdr.GetString(4);
                            string description = rdr.GetString(5);
                            int mentorID_FK = rdr.GetInt32(6);

                            displayList.Add(new Display(displayID, startTime, endTime, course, price, description, mentorID_FK));
                        }
                        return displayList;
                    }
                }
            }
        }
        public static void AddCourse(string connectionString, Course course)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Course(Coursename) VALUES(@coursename)";
                    cmd.Parameters.AddWithValue("@coursename", course.Coursename);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateCourse(string connectionString, Course updatedCourse)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string stm = "UPDATE Course SET Coursename = @coursename WHERE CourseID = @courseID";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    cmd.Parameters.AddWithValue("@coursename", updatedCourse.Coursename);
                    cmd.Parameters.AddWithValue("@courseID", updatedCourse.CourseID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteCourse(string connectionString, int courseID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string stm = "DELETE FROM Course WHERE CourseID = @courseID";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    cmd.Parameters.AddWithValue("@courseID", courseID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Course> LoadCourses(string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                List<Course> courseList = new List<Course>();
                string stm = "SELECT * FROM Course";

                using (SQLiteCommand cmd = new SQLiteCommand(stm, connection))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string coursename = rdr.GetString(0);
                            int courseID = rdr.GetInt32(1);

                            courseList.Add(new Course(courseID, coursename));
                        }
                        return courseList;
                    }
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
        public override string ToString()
        {
            return $"{ID}-{Appearance}-{Language}-{Firstname}-{Lastname}-{Email}-{Phonenumber}-{Password}-{MentorID_FK}-{Class}";
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
        public override string ToString()
        {
            return $"{MentorID}-{Courses}";
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