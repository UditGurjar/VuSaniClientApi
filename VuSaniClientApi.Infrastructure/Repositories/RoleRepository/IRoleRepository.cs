using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Repositories.RoleRepository
{
    public interface IRoleRepository
    {
        Task<object> GetRolesAsync(int page, int pageSize, bool all, string search, string filter);
    }

}
