using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.EmailService
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
                _configuration=configuration;
        }
        public async Task SendTerminationReminderAsync(string toEmail, string employeeName, DateTime terminationDate, int intervalDays)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
            {
               
                return;
            }

            var smtpHost = _configuration["Smtp:Host"];
            var smtpPort = 587;
            var smtpUser = _configuration["Smtp:Username"];
            var smtpPassword = _configuration["Smtp:Password"];
            var fromEmail = _configuration["Smtp:FromEmail"] ?? smtpUser;
            var fromName = _configuration["Smtp:FromName"] ?? "VuSani Employee Management";

            if (string.IsNullOrWhiteSpace(smtpHost) || string.IsNullOrWhiteSpace(smtpUser))
            {
                return;
            }

            var intervalText = intervalDays == 0
                ? "today (day of termination)"
                : $"{intervalDays} days before termination";
            var subject = $"Employee Termination Reminder: {employeeName} - {intervalText}";
            var body = $@"
Hello,

This is to inform you that the following employee's termination date is approaching:

Employee: {employeeName}
Termination Date: {terminationDate:yyyy-MM-dd}
Reminder: {intervalText}

Please ensure all handover and exit formalities are completed.

This is an automated message from VuSani Employee Management.
".Trim();

            try
            {
                using var client = new SmtpClient(smtpHost, smtpPort)
                {
                    EnableSsl = true,
                    Credentials = string.IsNullOrEmpty(smtpPassword) ? null : new NetworkCredential(smtpUser, smtpPassword)
                };

                var mail = new MailMessage
                {
                    From = new MailAddress(fromEmail, fromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                mail.To.Add(toEmail);

                await client.SendMailAsync(mail);

            }
            catch (Exception ex)
            {
            }
        }

    }
}
