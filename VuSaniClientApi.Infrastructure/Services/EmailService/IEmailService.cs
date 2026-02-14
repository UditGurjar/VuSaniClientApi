using System;
using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Services.EmailService
{
    /// <summary>
    /// Interface for the application email service.
    /// Defined in Infrastructure so repositories can depend on it without circular references.
    /// Implementation lives in the Application layer.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends a termination reminder email to the creator of the employee record.
        /// </summary>
        Task SendTerminationReminderAsync(string toEmail, string employeeName, DateTime terminationDate, int intervalDays);

        /// <summary>
        /// Sends an HSE Appointment end date reminder email.
        /// </summary>
        Task SendHseAppointmentEndDateReminderAsync(
            string toEmail,
            string appointerName,
            string appointedEmployeeName,
            string hseAppointmentName,
            string endDate,
            int daysRemaining);

        /// <summary>
        /// Unified HSE Appointment notification email.
        /// Uses HseAppointmentNotification.txt for appointed, HseAppointmentAppointerNotification.txt for appointer.
        /// Handles all statuses: Pending Acceptance, Active, Rejected, Expired, Renewed, Terminated.
        /// </summary>
        Task SendHseAppointmentNotificationEmailAsync(
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
            byte[]? pdfAttachment = null);
    }
}
