using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Filters
{
    public interface ISidebarPermissionService
    {
        Task<PermissionCheckResult> CheckPermissionAsync(
            int userId,
            string accessType,
            int moduleId);
    }
    public class PermissionCheckResult
    {
        public bool IsAllowed { get; set; }
        public string Message { get; set; } = "";
        public List<string> AllowedOrganizations { get; set; } = new();
    }

}
