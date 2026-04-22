using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System.Net;
using System.Net.Mail;

namespace AymanFreelance.BLL.Repositories
{
    public class EmailTBLRepository : GenericRepository<EmailTBL>, IEmailTBLRepository
    {
        private readonly AymanFreelanceDbContext _context;
        private readonly IConfiguration configuration;

        public EmailTBLRepository(AymanFreelanceDbContext context, IConfiguration configuration) :base(context)
        {
            _context = context;
            this.configuration = configuration;
        }

        public async Task SendEmail(EmailTBL email)
        {
            var client = new System.Net.Mail.SmtpClient(configuration["AymanFreelance.Pl.SmtpSendingEmail"], 587);

            client.EnableSsl = true;

            client.Credentials = new NetworkCredential(configuration["AymanFreelance.Pl.SendingEmail"], configuration["AymanFreelance.Pl.PWSendingEmail"]);

            client.Send(email.From, email.To, email.Subject, email.Body);

            client.Dispose();
        }

        public async Task SendEmailAsync(EmailTBL emails)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configuration["AymanFreelance.Pl.SendingEmail"]));
            email.To.Add(MailboxAddress.Parse(emails.To));
            email.Subject = emails.Subject;

            // HTML body
            email.Body = new TextPart(TextFormat.Html) { Text = emails.Body };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync(configuration["AymanFreelance.Pl.SmtpSendingEmail"], 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(configuration["AymanFreelance.Pl.SendingEmail"], configuration["AymanFreelance.Pl.PWSendingEmail"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendEmailAsync(EmailTBL emails,int SecondType = 0, List<string>? ccEmails = null)
        {
            var smtp = new System.Net.Mail.SmtpClient(configuration["AymanFreelance.Pl.SmtpSendingEmail"], 587) // or your SMTP server
            {
                Port = 587,
                Credentials = new NetworkCredential(configuration["AymanFreelance.Pl.SendingEmail"], configuration["AymanFreelance.Pl.PWSendingEmail"]),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress(configuration["AymanFreelance.Pl.SendingEmail"], "Freelancer's House"),
                Subject = emails.Subject,
                Body = emails.Body,
                IsBodyHtml = true
            };

            // To
            mail.To.Add(emails.To);

            // CC (optional)
            if (ccEmails != null)
            {
                foreach (var cc in ccEmails)
                {
                    mail.CC.Add(cc);
                }
            }

            await smtp.SendMailAsync(mail);
        }
    }
}
