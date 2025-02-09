using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using MySandBoxApp.Core.Interfaces;

namespace TeaMarketPlace.EmailService.Services
{
    public class SendingMailService : ISendingMailService
    {
        private readonly ILogger<SendingMailService> _logger;

        public SendingMailService(ILogger<SendingMailService> logger)
        {
            _logger = logger;
        }

        const string FROM = "hrmfivemanagement@gmail.com";
        const string SMTPSERVER = "smtp.gmail.com";
        const int PORT = 465;
        const string PASSWORD = "tupjchwxpcbhwkqt";

        public async Task SendMessageAsync(Stream messageStream, string receiverId, string fileName)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(SMTPSERVER, PORT, true);
                    client.Authenticate(FROM, PASSWORD);

                    var emailMessage = CreateEmailMessage(new EmailMessageDto(receiverId, "Notification", "Here is your file attachment."), messageStream, fileName);
                    await client.SendAsync(emailMessage);
                }
                catch (MailKit.Security.AuthenticationException ex)
                {
                    _logger.LogError(ex, "Authentication failed. Check email credentials.");
                    throw new InvalidOperationException("Failed to authenticate with the SMTP server.", ex);
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    _logger.LogError(ex, "Network error while trying to send email.");
                    throw new InvalidOperationException("Failed to connect to the SMTP server.", ex);
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        private MimeMessage CreateEmailMessage(EmailMessageDto message, Stream fileStream, string fileName)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("HR Management", FROM));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;

            string htmlContent;
            using (var reader = new StreamReader(fileStream))
            {
                htmlContent = reader.ReadToEnd();
            }

            var body = new TextPart("html")
            {
                Text = htmlContent
            };

            emailMessage.Body = body;
            return emailMessage;
        }

        public class EmailMessageDto
        {
            public MailboxAddress To { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }

            public EmailMessageDto(string to, string subject, string content)
            {
                To = new MailboxAddress("Recipient", to);
                Subject = subject;
                Content = content;
            }
        }
    }

}
