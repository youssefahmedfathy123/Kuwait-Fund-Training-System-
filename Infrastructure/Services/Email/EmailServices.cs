using Application.Abstractions.Email.Application.Abstractions.Email;
using Domain.Entities.role;
using Infrastructure.Helper;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Services.Email
{
    public class EmailServices : IEmailServices
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailServices(IOptions<SmtpSettings> smtpOptions)
        {
            _smtpSettings = smtpOptions.Value;
        }

        public async Task SendRoleUpgradeStatusEmailAsync(
            string email,
            string userName,
            string requestedRole,
            RoleUpgradeRequestStatus status,
            CancellationToken cancellationToken)
        {
            var subject = status == RoleUpgradeRequestStatus.Approved
                ? "تم قبول طلب الترقية"
                : "تم رفض طلب الترقية";

             var body = $@" مرحباً   {userName}،
                       تم {(status == RoleUpgradeRequestStatus.Approved ? "قبول" : "رفض")} طلبك للترقية إلى الدور: {requestedRole}.
                           شكراً لك.";


            var message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.From),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            message.To.Add(new MailAddress(email));

            using var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
            {
                EnableSsl = _smtpSettings.EnableSsl,
                Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password)
            };

            await client.SendMailAsync(message, cancellationToken);
        }
    }
}

