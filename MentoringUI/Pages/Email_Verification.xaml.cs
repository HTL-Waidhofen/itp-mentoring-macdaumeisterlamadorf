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
        public Email_Verification()
        {
            InitializeComponent();
            SmtpClient smtpClient = new SmtpClient("smtp-relay.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("sener.mail", "pw"),
                EnableSsl = true, 
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("mentoring.mail.at"),
                Subject = "Code Bestätigung",
                Body = "1234",
                IsBodyHtml = false,
            };

            mailMessage.To.Add("user.mail");
            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }

        }
    }

}
