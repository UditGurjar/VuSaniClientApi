using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.EmailService
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends a termination reminder email to the creator of the employee record.
        /// </summary>
        /// <param name="toEmail">Creator's email address.</param>
        /// <param name="employeeName">Employee's full name.</param>
        /// <param name="terminationDate">Date of termination.</param>
        /// <param name="intervalDays">90, 60, 30, 7, or 0 (on the day).</param>
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
    }
}
