using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.OrganizationService
{
    public interface IOrganizationService
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
