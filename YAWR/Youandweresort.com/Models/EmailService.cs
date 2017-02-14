using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Youandweresort.com.Models
{
    public static class SendEmail
    {
        public static void BookRoomYAW(string SenderName, string SenderEmailAddress, List<ReceiverEmail> ReceiverEmail, string Subject, string Body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(SenderName, SenderEmailAddress));
            foreach (var receiver in ReceiverEmail)
            {
                message.To.Add(new MailboxAddress(receiver.ReceiverFullName, receiver.ReceiverEmailAddress));
            }
            message.Subject = Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = string.Format(Body);
            message.Body = builder.ToMessageBody();
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                //  Setting setting = 
                client.Connect("smtp.gmail.com", 587, false);
                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: only needed if the SMTP server requires authentication
                // Dùng cho noreply
                client.Authenticate("nhan.nguyen@naansolution.com", "nhandaica123456");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
    public class ReceiverEmail
    {
        public string ReceiverFullName { get; set; }
        public string ReceiverEmailAddress { get; set; }
    }
}