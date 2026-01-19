using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.RoleService
{
    public interface IRoleService
    {
        Task<object> GetRolesAsync(int page, int pageSize, bool all, string search, string filter);

    }
}
