﻿using System;
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
            //
            //Variable Username aus der Datenbank#
            //
            Random random = new Random();
            int randomNumber = random.Next(10000, 100000);
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("verify.htlwy.mentoring@outlook.com", "HTL.2023.daurer!"),
                EnableSsl = true,
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("verify.htlwy.mentoring@outlook.com"),
                Subject = "Code zur Authentifizierung ihres Kontos",
                Body = "Sehr geehrte/r [Empfängername],\r\n\r\n Um die Sicherheit Ihres Kontos weiter zu stärken, haben wir die Zwei-Faktor-Authentifizierung (2FA) aktiviert. Bitte verwenden Sie den folgenden Code, um sich anzumelden:\r\n\r\nIhr 2FA-Code:" + randomNumber + "\r\n\r\nBitte geben Sie diesen Code innerhalb der nächsten 10 Minuten ein, um Ihre Identität zu bestätigen und auf Ihr Konto zuzugreifen. Sollten Sie Schwierigkeiten haben oder diese Anmeldung nicht initiieren, kontaktieren Sie bitte umgehend unseren Kundenservice.\r\n\r\nWir schätzen Ihr Vertrauen und stehen Ihnen für eventuelle Fragen gerne zur Verfügung. Vielen Dank für Ihr Verständnis und Ihre Mitarbeit.\r\n\r\nMit freundlichen Grüßen,\r\n\r\n[Ihr Unternehmen/Organisation]\r\n[Kontaktinformationen]",
                IsBodyHtml = false,
            };

            mailMessage.To.Add("richard.daurer@gmail.com");
                smtpClient.Send(mailMessage);

            if (int.Parse(TestNumbers.Text) == randomNumber)
            {
                MessageBox.Show("Ihr Konto wurde verifizert");
            }
        }
    }

}
