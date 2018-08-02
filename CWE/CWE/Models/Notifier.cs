using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CWE.Models
{
    public class Notifier
    {
        public Notifier()
        {
        }

        public static void EmailNotification(string email, string pair)
        {
            MailMessage mail = new MailMessage("CEA.Notification@gmail.com", email)
            {
                Subject = "Currency Report"
            };
            string Body = "Your currency request for " + pair + " has reached the target rate";
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", 
                Credentials = new System.Net.NetworkCredential("CEA.Notification@gmail.com", "PassWord!@"),

                EnableSsl = true
            };
            smtp.Send(mail);
            mail = null;
            smtp = null;
        }

        [Key]
        [Display(Name = "ID")]
        public string Notifier_ID { get; set; }
        [Display(Name = "Notification")]
        public string Notifier_NotificationString { get; set; }
    }
}
