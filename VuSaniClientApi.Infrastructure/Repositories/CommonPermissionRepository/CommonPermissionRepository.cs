using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;

namespace VuSaniClientApi.Infrastructure.Repositories.CommonPermissionRepository
{
    public class CommonPermissionRepository : ICommonPermissionRepository
    {
        private readonly ApplicationDbContext _db;

        public CommonPermissionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<int>> GetOrganizationsAsync(string tableName, int recordId)
        {
            switch (tableName.ToLower())
            {
                case "roles":
                    var roleOrg = await _db.Roles
                        .Where(x => x.Id == recordId && x.Deleted != true)
                        .Select(x => x.OrganizationId)
                        .FirstOrDefaultAsync();

                    return roleOrg.HasValue
                        ? new List<int> { roleOrg.Value }
                        : new List<int>();


                case "users":
                    var userOrg = await _db.Users
                        .Where(x => x.Id == recordId)
                        .Select(x => x.OrganizationId)
                        .FirstOrDefaultAsync();

                    return userOrg.HasValue
                        ? new List<int> { userOrg.Value }
                        : new List<int>();


                case "departments":
                case "department":
                    return await _db.Department
                        .Where(x => x.Id == recordId)
                        .Select(x => x.OrganizationId)
                        .Where(x => x.HasValue)
                        .Select(x => x.Value)
                        .ToListAsync();

                

                default:
                    return new List<int>();
            }
        }
    }
}
