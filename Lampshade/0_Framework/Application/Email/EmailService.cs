using MimeKit;
using MailKit.Net.Smtp;

namespace _0_Framework.Application.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("Ethereal", "marielle.macgyver66@ethereal.email");
            message.From.Add(from);

            var to = new MailboxAddress("User", destination);
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
            };

            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            client.Connect("smtp.ethereal.email", 587, false);
            client.Authenticate("marielle.macgyver66@ethereal.email", "GaVuMkvs2YC8nMnq3E");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}