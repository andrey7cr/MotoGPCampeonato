using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace MotoGPCampeonato.Services
{
    public class EmailService
    {
        private readonly string _emailUser;
        private readonly string _emailPassword;

        public EmailService(IConfiguration configuration)
        {
            _emailUser = configuration["EmailSettings:User"];
            _emailPassword = configuration["EmailSettings:Password"];
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("MotoGP Championship", _emailUser));
            emailMessage.To.Add(MailboxAddress.Parse(email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.ucr.ac.cr", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailUser, _emailPassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
                client.MessageSent += (sender, args) =>
                {
                    Console.WriteLine("Correo enviado.");
                };

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            }
        }
    }
}
