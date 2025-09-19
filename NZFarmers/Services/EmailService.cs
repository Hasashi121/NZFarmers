using System.Net;
using System.Net.Mail;

namespace NZFarmers.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendContactEmailAsync(string fromEmail, string subject, string message)
        {
            var smtpClient = new SmtpClient(_config["EmailSettings:SmtpServer"])
            {
                Port = int.Parse(_config["EmailSettings:Port"]),
                Credentials = new NetworkCredential(
                    _config["EmailSettings:Username"],
                    _config["EmailSettings:Password"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_config["EmailSettings:SenderEmail"]),
                Subject = $"Contact Form: {subject}",
                Body = $"From: {fromEmail}\n\nMessage:\n{message}",
                IsBodyHtml = false,
            };

            mailMessage.To.Add("harshilprasad@yahoo.com");

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}