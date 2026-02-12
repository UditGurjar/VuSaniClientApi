namespace VuSaniClientApi.Application.Services.EmailService
{
    /// <summary>
    /// Application-level email service interface.
    /// Extends the Infrastructure interface so all contracts are available.
    /// </summary>
    public interface IEmailService : Infrastructure.Services.EmailService.IEmailService
    {
        Task SendEmailUsingGmail(string sender, List<string> to, string subject, string body);

    }
}
