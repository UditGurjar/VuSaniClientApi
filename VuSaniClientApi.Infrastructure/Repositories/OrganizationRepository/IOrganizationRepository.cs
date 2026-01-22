using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Repositories.OrganizationRepository
{
    public interface IOrganizationRepository
    {
        Task<object> GetUsersOrganizationAsync(
           int page,
           int pageSize,
           bool all,
           string? search,
           int? userId
       );
    }
}
