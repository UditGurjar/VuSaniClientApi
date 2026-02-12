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
        /// Sends an HSE Appointment confirmation email to the appointer.
        /// </summary>
        Task SendHseAppointmentAppointerEmailAsync(
            string toEmail,
            string appointerName,
            string appointedEmployeeName,
            string companyName,
            string hseAppointmentName,
            string effectiveDate,
            string endDate);

        /// <summary>
        /// Sends an HSE Appointment notification email to the appointed user.
        /// </summary>
        Task SendHseAppointmentAppointedEmailAsync(
            string toEmail,
            string appointerName,
            string appointedEmployeeName,
            string companyName,
            string hseAppointmentName,
            string effectiveDate,
            string endDate);

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
        /// Sends an HSE Appointment status change notification email.
        /// </summary>
        Task SendHseAppointmentStatusChangeEmailAsync(
            string toEmail,
            string recipientName,
            string hseAppointmentName,
            string appointedEmployeeName,
            string newStatus);

        /// <summary>
        /// Sends an HSE Appointment action email to the appointed employee with Accept/Reject buttons.
        /// </summary>
        Task SendHseAppointmentActionEmailAsync(
            string toEmail,
            string appointerName,
            string appointedEmployeeName,
            string companyName,
            string hseAppointmentName,
            string effectiveDate,
            string endDate,
            string actionToken,
            string apiBaseUrl,
            string frontendBaseUrl);
    }
}
