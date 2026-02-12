using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
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
                // Connect to the SMTP server
                await smtp.ConnectAsync(host, port, MailKit.Security.SecureSocketOptions.StartTls);
                // Authenticate using App Password
                await smtp.AuthenticateAsync(fromEmail, password);
                // Send the email
                await smtp.SendAsync(emailMessage);
                // Disconnect gracefully
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // Log the exception or throw
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

        public async Task SendHseAppointmentAppointerEmailAsync(
            string toEmail,
            string appointerName,
            string appointedEmployeeName,
            string companyName,
            string hseAppointmentName,
            string effectiveDate,
            string endDate)
        {
            if (string.IsNullOrWhiteSpace(toEmail)) return;

            var subject = $"Confirmation: HSE Appointment - {appointedEmployeeName}";
            var body = BuildHseAppointmentEmailBody(
                "HSE Appointment Confirmation",
                appointerName,
                appointedEmployeeName,
                companyName,
                hseAppointmentName,
                effectiveDate,
                endDate,
                "You have been recorded as the <strong>Appointer</strong> for the following HSE Legal Appointment.");

            //await SendEmailAsync(toEmail, subject, body, isHtml: true);
        }

        public async Task SendHseAppointmentAppointedEmailAsync(
            string toEmail,
            string appointerName,
            string appointedEmployeeName,
            string companyName,
            string hseAppointmentName,
            string effectiveDate,
            string endDate)
        {
            if (string.IsNullOrWhiteSpace(toEmail)) return;

            var subject = $"HSE Appointment Notification - {hseAppointmentName}";
            var body = BuildHseAppointmentEmailBody(
                "HSE Appointment Notification",
                appointerName,
                appointedEmployeeName,
                companyName,
                hseAppointmentName,
                effectiveDate,
                endDate,
                "You have been <strong>appointed</strong> for the following HSE Legal Appointment.");

         //   await SendEmailAsync(toEmail, subject, body, isHtml: true);
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

        public async Task SendHseAppointmentStatusChangeEmailAsync(
            string toEmail,
            string recipientName,
            string hseAppointmentName,
            string appointedEmployeeName,
            string newStatus)
        {
            if (string.IsNullOrWhiteSpace(toEmail)) return;

            var statusColor = newStatus switch
            {
                "Active" => "#28a745",
                "Rejected" => "#dc3545",
                "Terminated" => "#6c757d",
                "Renewed" => "#17a2b8",
                _ => "#333"
            };

            var statusMessage = newStatus switch
            {
                "Active" => "has been <strong>accepted</strong> and is now active",
                "Rejected" => "has been <strong>rejected</strong>",
                "Terminated" => "has been <strong>terminated</strong>",
                "Renewed" => "has been <strong>renewed</strong>. A new appointment record has been created with Pending Acceptance status",
                _ => $"status has been changed to <strong>{newStatus}</strong>"
            };

            var subject = $"HSE Appointment {newStatus}: {hseAppointmentName} - {appointedEmployeeName}";
            var body = $@"
<!DOCTYPE html>
<html>
<head><meta charset='utf-8'></head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
        <div style='background-color: #e2e3e5; border-radius: 8px; padding: 20px; margin-bottom: 20px;'>
            <h2 style='color: #383d41; margin-top: 0;'>HSE Appointment Status Update</h2>
            <span style='display: inline-block; background-color: {statusColor}; color: white; padding: 4px 12px; border-radius: 12px; font-size: 14px;'>{newStatus}</span>
        </div>

        <p>Dear {recipientName},</p>

        <p>The HSE Appointment for <strong>{appointedEmployeeName}</strong> ({hseAppointmentName}) {statusMessage}.</p>

        <p>Please log in to the system to view the details.</p>

        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;' />
        <p style='font-size: 12px; color: #6c757d;'>This is an automated message from VuSani Employee Management.</p>
    </div>
</body>
</html>".Trim();

            //await SendEmailAsync(toEmail, subject, body, isHtml: true);
        }

        public async Task SendHseAppointmentActionEmailAsync(
       string toEmail,
       string appointerName,
       string appointedEmployeeName,
       string companyName,
       string hseAppointmentName,
       string effectiveDate,
       string endDate,
       string actionToken,
       string apiBaseUrl,
       string frontendBaseUrl)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
                return;

            var acceptUrl = $"{apiBaseUrl}/api/HseAppointment/email-accept?token={actionToken}";
            var rejectUrl = $"{apiBaseUrl}/api/HseAppointment/email-reject?token={actionToken}";

            var subject = $"Action Required: HSE Appointment - {hseAppointmentName}";

            // Path to template
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "EmailTextFile", "HseAppointedEmployee.txt");

            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Email template not found.", templatePath);

            var body = await File.ReadAllTextAsync(templatePath);
            string senderName = "VuSani";

            // Replace placeholders
            body = body.Replace("{{AppointedEmployeeName}}", appointedEmployeeName)
                       .Replace("{{AppointerName}}", appointerName)
                       .Replace("{{CompanyName}}", companyName)
                       .Replace("{{HseAppointmentName}}", hseAppointmentName)
                       .Replace("{{EffectiveDate}}", effectiveDate)
                       .Replace("{{EndDate}}", string.IsNullOrEmpty(endDate) ? "N/A" : endDate)
                       .Replace("{{AcceptUrl}}", acceptUrl)
                       .Replace("{{RejectUrl}}", rejectUrl)
                       .Replace("{{SenderName}}", appointerName)
                       .Replace("{{CurrentYear}}", DateTime.UtcNow.Year.ToString());
            List<string> toEmails = new List<string> { toEmail };

            await SendEmailUsingGmail(senderName, toEmails, subject, body);
        }


        #region Private Helpers

 
        private static string BuildHseAppointmentEmailBody(
            string title,
            string appointerName,
            string appointedEmployeeName,
            string companyName,
            string hseAppointmentName,
            string effectiveDate,
            string endDate,
            string introMessage)
        {
            return $@"
<!DOCTYPE html>
<html>
<head><meta charset='utf-8'></head>
<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
    <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
        <div style='background-color: #d4edda; border: 1px solid #c3e6cb; border-radius: 8px; padding: 20px; margin-bottom: 20px;'>
            <h2 style='color: #155724; margin-top: 0;'>{title}</h2>
        </div>

        <p>Dear {appointerName},</p>

        <p>{introMessage}</p>

        <table style='width: 100%; border-collapse: collapse; margin: 20px 0;'>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold; width: 40%;'>Company</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{companyName}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold;'>HSE Appointment Name</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{hseAppointmentName}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold;'>Appointer</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{appointerName}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold;'>Appointed Employee</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{appointedEmployeeName}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold;'>Effective Date</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{effectiveDate}</td>
            </tr>
            <tr>
                <td style='padding: 10px; border: 1px solid #ddd; background: #f8f9fa; font-weight: bold;'>End Date</td>
                <td style='padding: 10px; border: 1px solid #ddd;'>{(string.IsNullOrEmpty(endDate) ? "N/A" : endDate)}</td>
            </tr>
        </table>

        <p>Please log in to the system to view the full appointment details.</p>

        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;' />
        <p style='font-size: 12px; color: #6c757d;'>This is an automated message from VuSani Employee Management.</p>
    </div>
</body>
</html>".Trim();
        }

        #endregion
    }
}
