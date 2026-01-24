using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Repositories.CommonPermissionRepository
{
    public interface ICommonPermissionRepository
    {
        Task<List<int>> GetOrganizationsAsync(string tableName, int recordId);

    }
}
