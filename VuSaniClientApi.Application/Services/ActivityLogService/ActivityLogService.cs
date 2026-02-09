using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.ActivityLogRepository;

namespace VuSaniClientApi.Application.Services.ActivityLogService
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IActivityLogRepository _activityLogRepository;

        public ActivityLogService(IActivityLogRepository activityLogRepository)
        {
            _activityLogRepository = activityLogRepository;
        }

        public async Task<object> GetActivityLogsAsync(int page, int pageSize, bool all, string search, string filter, int? userId = null)
        {
            return await _activityLogRepository.GetActivityLogsAsync(page, pageSize, all, search, filter, userId);
        }

        public async Task<object> GetActivityLogsByUserIdAsync(int userId, int page, int pageSize)
        {
            return await _activityLogRepository.GetActivityLogsByUserIdAsync(userId, page, pageSize);
        }

        public async Task<object> LogActivityAsync(int createdBy, string status, string module, object id)
        {
            try
            {
                status = status.ToLower();
                string message = GenerateActivityMessage(status, module, id);

                var activityLog = await _activityLogRepository.InsertActivityLogAsync(createdBy, status, module, message);

                return new
                {
                    status = true,
                    message = "Activity logged successfully",
                    data = activityLog
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    status = false,
                    message = $"Failed to log activity: {ex.Message}"
                };
            }
        }

        private string GenerateActivityMessage(string status, string module, object id)
        {
            return status switch
            {
                "create" => $"New {module} created successfully with id {id}",
                "update" => $"{module} updated successfully with id {id}",
                "delete" => $"{module} deleted successfully with id {id}",
                "view" => $"{module} viewed with id {id}",
                "approved" => $"{module} approved successfully with id {id}",
                "reject" => $"{module} rejected successfully with id {id}",
                "login" => $"User logged in successfully",
                "logout" => $"User logged out successfully",
                _ => $"{module} {status} successfully with id {id}"
            };
        }
    }
}
