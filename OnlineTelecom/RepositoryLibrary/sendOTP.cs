using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace OnlineTelecom.RepositoryLibrary
{
    public class sendOTP
    {
        public string SendMail(string toAddress, string subject, string body)
        {
            string result = "Message Send Successfully...!!";
            string senderId = "swapnil.warke32@gmail.com";
            const string senderPassword = "Swapnil@123";
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential("swapnil.warke32@gmail.com", "Swapnil@123"),
                    Timeout = 30000,
                };
                //MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                MailMessage message = new MailMessage("swapnil.warke32@gmail.com", "swapnil.warke32@gmail.com", "ÖTP Genrate", body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
            }
            return result;
        }
    }
}