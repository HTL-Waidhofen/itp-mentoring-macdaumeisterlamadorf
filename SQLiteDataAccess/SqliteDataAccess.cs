﻿namespace SQLiteDataAccess
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
    }
}