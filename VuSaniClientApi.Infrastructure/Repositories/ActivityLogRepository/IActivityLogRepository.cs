using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.Repositories.ActivityLogRepository
{
    public interface IActivityLogRepository
    {
        Task<object> GetActivityLogsAsync(int page, int pageSize, bool all, string search, string filter, int? userId = null);
        Task<object> GetActivityLogsByUserIdAsync(int userId, int page, int pageSize);
        Task<ActivityLog> InsertActivityLogAsync(int createdBy, string status, string module, string message);
    }
}
