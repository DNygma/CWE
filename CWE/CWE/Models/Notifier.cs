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
        CEA_DBContext _context;
        public Notifier(CEA_DBContext context)
        {
            _context = context;
        }

        // This is the email notification sytsem that takes in the users email and pair
            // notifying them when a specific rate has been met
        public static void EmailNotification(string email, string pair)
        {
            // Set email message with Curreny Subject
            MailMessage mail = new MailMessage("cea.notification@gmail.com", email)
            {
                Subject = "Currency Report"
            };
            // Set email body
            string Body = "Your currency request for " + pair + " has reached the target rate";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            // Set up SMTP Client for Gmail Use Only
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587) {
                Credentials = new System.Net.NetworkCredential("cea.notification@gmail.com", "PassWord!@"),
                EnableSsl = true
            };
            // Send email to user
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
