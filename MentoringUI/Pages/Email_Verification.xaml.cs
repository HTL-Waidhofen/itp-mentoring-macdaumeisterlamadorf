using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class Email_Verification : Page
    {
        SQLiteDataAccess.User user;
        static Random random = new Random();
        int randomNumber = random.Next(10000, 100000);
        public Email_Verification(string email, SQLiteDataAccess.User user)
        {
            InitializeComponent();
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("mentor.htlwy.verify@outlook.com", "HTL.2024.Mentoring!"),
                EnableSsl = true,
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("mentor.htlwy.verify@outlook.com"),
                Subject = "Code zur Authentifizierung ihres Kontos",
                Body = "Ihr 2FA-Code:" + randomNumber,
                IsBodyHtml = false,
            };

            mailMessage.To.Add(email);
            smtpClient.Send(mailMessage);
            this.user = user;
        }
        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(TestNumbers.Text) == randomNumber)
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Content = new Student(user);
            }
            else
            {
                MessageBox.Show("Falscher Code");
            }
        }
    }
}