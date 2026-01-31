using Microsoft.EntityFrameworkCore;
using VuSaniClientApi.Application.Services.EmailService;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Services
{
    /// <summary>
    /// Runs daily and sends email notifications to the creator of the employee record
    /// at 90, 60, 30, 7 days before termination and on the day of termination.
    /// </summary>
    public class TerminationNotificationHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<TerminationNotificationHostedService> _logger;
        private static readonly int[] Intervals = { 90, 60, 30, 7, 0 };

        public TerminationNotificationHostedService(IServiceScopeFactory scopeFactory, ILogger<TerminationNotificationHostedService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Termination Notification Hosted Service started. Will run daily at 08:00.");
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.UtcNow;
                var nextRun = now.Date.AddDays(1).AddHours(8); // 08:00 next day
                if (now.Hour < 8)
                    nextRun = now.Date.AddHours(8);
                var delay = nextRun - now;
                await Task.Delay(delay, stoppingToken);
                if (stoppingToken.IsCancellationRequested) break;

                try
                {
                    await ProcessTerminationRemindersAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in termination notification job");
                }
            }
        }

        private async Task ProcessTerminationRemindersAsync(CancellationToken ct)
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

            var today = DateTime.UtcNow.Date;

            foreach (var intervalDays in Intervals)
            {
                DateTime targetTerminationDate;
                if (intervalDays == 0)
                    targetTerminationDate = today;
                else
                    targetTerminationDate = today.AddDays(intervalDays);

                var employees = await db.Users
                    .AsNoTracking()
                    .Where(u => (u.Deleted != true)
                        && u.DateOfTermination.HasValue
                        && u.DateOfTermination.Value.Date == targetTerminationDate
                        && u.CreatedBy.HasValue)
                    .Select(u => new { u.Id, u.Name, u.Surname, u.DateOfTermination, u.CreatedBy })
                    .ToListAsync(ct);

                foreach (var emp in employees)
                {
                    if (!emp.CreatedBy.HasValue) continue;

                    var alreadySent = await db.TerminationNotificationLogs
                        .AnyAsync(t => t.UserId == emp.Id && t.IntervalDays == intervalDays, ct);
                    if (alreadySent) continue;

                    var creator = await db.Users
                        .AsNoTracking()
                        .Where(u => u.Id == emp.CreatedBy.Value)
                        .Select(u => u.Email)
                        .FirstOrDefaultAsync(ct);

                    if (string.IsNullOrWhiteSpace(creator)) continue;

                    var employeeName = $"{emp.Name} {emp.Surname}".Trim();
                    await emailService.SendTerminationReminderAsync(
                        creator,
                        employeeName,
                        emp.DateOfTermination!.Value,
                        intervalDays);

                    db.TerminationNotificationLogs.Add(new TerminationNotificationLog
                    {
                        UserId = emp.Id,
                        IntervalDays = intervalDays,
                        SentAt = DateTime.UtcNow
                    });
                }

                await db.SaveChangesAsync(ct);
            }
        }
    }
}
