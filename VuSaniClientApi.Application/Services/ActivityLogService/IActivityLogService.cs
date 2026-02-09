using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.ActivityLogService
{
    public interface IActivityLogService
    {
        Task<object> GetActivityLogsAsync(int page, int pageSize, bool all, string search, string filter, int? userId = null);
        Task<object> GetActivityLogsByUserIdAsync(int userId, int page, int pageSize);
        Task<object> LogActivityAsync(int createdBy, string status, string module, object id);
    }
}
