namespace SQLiteDataAccess
{
    public class SqliteDataAccess
    {

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
    }

}