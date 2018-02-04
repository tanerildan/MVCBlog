using BLOG.BLL.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Services.Concretes
{
    public class MessageService : IMessageService
    {
        public string To { get; set; }
        public bool SendMessage(string subject, string message)
        {
            MailMessage ms = new MailMessage();
            ms.From = new MailAddress("tanerblogsifre@gmail.com");
            ms.To.Add(To);
            ms.IsBodyHtml = true;
            ms.Body = message;
            ms.Subject = subject;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("tanerblogsifre@gmail.com", "Okulnumaram");

            try
            {
                smtp.Send(ms);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
