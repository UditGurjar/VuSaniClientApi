using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;

namespace VuSaniClientApi.Infrastructure.Repositories.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetRolesAsync(int page, int pageSize, bool all, string search, string filter)
        {
            var query = _context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.Contains(search));

            var total = await query.CountAsync();

            if (!all)
                query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var data = await query.ToListAsync();

            return new
            {
                total,
                page,
                pageSize,
                data
            };
        }
    }

}
