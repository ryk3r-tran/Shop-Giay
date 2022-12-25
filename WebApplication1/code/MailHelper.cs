using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace WebApplication1.code
{
    public class MailHelper
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["fromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["fromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["fromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["smtpHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["smtpPort"].ToString();
            bool enabledSSL = bool.Parse(ConfigurationManager.AppSettings["enabledSSL"].ToString());

            string body = content;
            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enabledSSL;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }
    }
}