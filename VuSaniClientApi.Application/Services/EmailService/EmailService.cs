using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using ContentType = MimeKit.ContentType;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace VuSaniClientApi.Application.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailUsingGmail(string sender, List<string> to, string subject, string body)
        {
            try
            {
                string fromEmail = _configuration["SettingsSection:EmailAddress"] ?? "";
                string password = _configuration["SettingsSection:password"] ?? "";
                string host = _configuration["SettingsSection:Host"] ?? "";
                int port = Convert.ToInt32(_configuration["SettingsSection:Port"] ?? "587");

                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(sender, fromEmail));

                foreach (var emailAddress in to)
                {
                    emailMessage.To.Add(MailboxAddress.Parse(emailAddress));
                }

                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("html") { Text = body };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(host, port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, password);
                await smtp.SendAsync(emailMessage);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }

        public async Task SendTerminationReminderAsync(string toEmail, string employeeName, DateTime terminationDate, int intervalDays)
        {
            if (string.IsNullOrWhiteSpace(toEmail)) return;

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

           // await SendEmailUsingGmail(toEmail, subject, body);
        }

        public async Task SendHseAppointmentEndDateReminderAsync(
            string toEmail,
            string appointerName,
            string appointedEmployeeName,
            string hseAppointmentName,
            string endDate,
            int daysRemaining)
        {
            if (string.IsNullOrWhiteSpace(toEmail)) return;

            var urgencyText = daysRemaining <= 7
                ? "<span style='color:#dc3545;font-weight:bold;'>URGENT</span> - "
                : "";

            var subject = $"Upcoming Expiry: HSE Appointment - {hseAppointmentName}";
            var body = $@"
<!DOCTYPE html>
<html>
<head><meta charset='utf-8'></head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
        <div style='background-color: #f8d7da; border: 1px solid #f5c6cb; border-radius: 8px; padding: 20px; margin-bottom: 20px;'>
            <h2 style='color: #721c24; margin-top: 0;'>{urgencyText}HSE Appointment Expiry Reminder</h2>
        </div>

        <p>Dear {appointerName},</p>

        <p>This is a reminder that the following HSE Appointment is approaching its end date:</p>

        <table style='width: 100%; border-collapse: collapse; margin: 20px 0;'>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold; width: 40%;'>Appointed Employee</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{appointedEmployeeName}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold;'>HSE Appointment Name</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{hseAppointmentName}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold;'>End Date</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{endDate}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold;'>Days Remaining</td>
                <td style='padding: 10px; border: 1px solid #ddd; color: {(daysRemaining <= 7 ? "#dc3545" : "#856404")}; font-weight: bold;'>{daysRemaining} day(s)</td>
            </tr>
        </table>

        <p>Please take appropriate action to renew or close this appointment before the end date.</p>

        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;' />
        <p style='font-size: 12px; color: #6c757d;'>This is an automated message from VuSani Employee Management.</p>
    </div>
</body>
</html>".Trim();

            //await SendEmailAsync(toEmail, subject, body, isHtml: true);
        }

        /// <summary>
        /// Unified HSE Appointment notification email.
        /// Uses the appointed template by default, or the appointer template when isAppointer = true.
        /// Handles all statuses and optionally attaches a PDF.
        /// </summary>
        public async Task SendHseAppointmentNotificationEmailAsync(
            string toEmail,
            string appointedName,
            string appointerName,
            string hseAppointmentName,
            string status,
            string effectiveDate,
            string endDate,
            string locationName,
            bool isAppointer = false,
            string? appointmentUrl = null,
            string? rejectionReason = null,
            string? terminationReason = null,
            string? brandColor = null,
            string? fontFamily = null,
            byte[]? pdfAttachment = null)
        {
            if (string.IsNullOrWhiteSpace(toEmail)) return;

            // Select template based on recipient type
            var templateFileName = isAppointer
                ? "HseAppointmentAppointerNotification.txt"
                : "HseAppointmentNotification.txt";

            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "EmailTextFile", templateFileName);
            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Email template not found.", templatePath);

            var body = await File.ReadAllTextAsync(templatePath);

            // Defaults for branding
            var color = string.IsNullOrWhiteSpace(brandColor) ? "#6C1D45" : brandColor;
            var font = string.IsNullOrWhiteSpace(fontFamily) ? "Arial" : fontFamily;
            var applicationName = _configuration["App:ApplicationName"] ?? "VuSani";

            // Status color mapping
            var statusColor = status switch
            {
                "Pending Acceptance" => "#f57c00",
                "Active" => "#28a745",
                "Rejected" => "#dc3545",
                "Expired" => "#856404",
                "Renewed" => "#17a2b8",
                "Terminated" => "#6c757d",
                _ => "#333"
            };

            // Replace all placeholders
            body = body.Replace("{{AppointedName}}", appointedName)
                       .Replace("{{AppointerName}}", appointerName)
                       .Replace("{{HseAppointmentName}}", hseAppointmentName)
                       .Replace("{{HseAppointmentStatus}}", status)
                       .Replace("{{EffectiveDate}}", string.IsNullOrEmpty(effectiveDate) ? "N/A" : effectiveDate)
                       .Replace("{{EndDate}}", string.IsNullOrEmpty(endDate) ? "N/A" : endDate)
                       .Replace("{{LocationName}}", string.IsNullOrEmpty(locationName) ? "N/A" : locationName)
                       .Replace("{{AppointmentUrl}}", appointmentUrl ?? "#")
                       .Replace("{{RejectionReason}}", rejectionReason ?? "N/A")
                       .Replace("{{TerminationReason}}", terminationReason ?? "N/A")
                       .Replace("{{BrandColor}}", color)
                       .Replace("{{FontFamily}}", font)
                       .Replace("{{StatusColor}}", statusColor)
                       .Replace("{{ApplicationName}}", applicationName)
                       .Replace("{{CurrentYear}}", DateTime.UtcNow.Year.ToString());

            // Process conditional blocks - keep matching status, remove others
            var allStatuses = new[] { "Pending Acceptance", "Active", "Rejected", "Expired", "Renewed", "Terminated" };
            foreach (var s in allStatuses)
            {
                if (s == status)
                {
                    // Keep the content, remove the markers
                    body = body.Replace($"<!--IF:{s}-->", "").Replace($"<!--ENDIF:{s}-->", "");
                }
                else
                {
                    // Remove the entire block including markers
                    var pattern = $"<!--IF:{Regex.Escape(s)}-->.*?<!--ENDIF:{Regex.Escape(s)}-->";
                    body = Regex.Replace(body, pattern, "", RegexOptions.Singleline);
                }
            }

            var subject = $"HSE Appointment {status}: {hseAppointmentName}";

            string fromEmail = _configuration["SettingsSection:EmailAddress"] ?? "";
            string password = _configuration["SettingsSection:password"] ?? "";
            string host = _configuration["SettingsSection:Host"] ?? "";
            int port = Convert.ToInt32(_configuration["SettingsSection:Port"] ?? "587");

            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(applicationName, fromEmail));
                emailMessage.To.Add(MailboxAddress.Parse(toEmail));
                emailMessage.Subject = subject;

                if (pdfAttachment != null && pdfAttachment.Length > 0)
                {
                    // Build body with PDF attachment
                    var builder = new BodyBuilder { HtmlBody = body };
                    builder.Attachments.Add("HSE_Appointment_Letter.pdf", pdfAttachment, new ContentType("application", "pdf"));
                    emailMessage.Body = builder.ToMessageBody();
                }
                else
                {
                    emailMessage.Body = new TextPart("html") { Text = body };
                }

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(host, port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, password);
                await smtp.SendAsync(emailMessage);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending HSE notification email: {ex.Message}");
                throw;
            }
        }
    }
}
