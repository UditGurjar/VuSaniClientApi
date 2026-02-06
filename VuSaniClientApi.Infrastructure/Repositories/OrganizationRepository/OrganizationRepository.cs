using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.OrganizationRepository
{
    public class OrganizationRepository:IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<object> GetUsersOrganizationAsync(
         int page,
         int pageSize,
         bool all,
         string? search,
         int? userId
     )
        {
            try
            {
                var query =
                from org in _context.Organizations
                join user in _context.Users
                    on org.CreatedBy equals user.Id into users
                from createdUser in users.DefaultIfEmpty()
                where org.Deleted == false
                select new { org, createdUser };

                // 🔍 searchConditionRecord equivalent
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(x =>
                        (x.org.Name != null && x.org.Name.Contains(search)) ||
                        (x.org.Description != null && x.org.Description.Contains(search)) ||
                        (x.createdUser != null && x.createdUser.Name.Contains(search))
                    );
                }

                var total = await query.CountAsync();

                if (!all)
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);

                var rawData = await query.ToListAsync();

                // 📦 Load departments in one go
                var orgIds = rawData.Select(x => x.org.Id).ToList();

                var departments = await _context.Department
                    .Where(d => !d.Deleted && orgIds.Contains((int)d.OrganizationId))
                    .ToListAsync();

                // 🎯 Final Node-style shaping
                var data = rawData.Select(x => new OrganizationListDto
                {
                    Id = x.org.Id,
                    Parent_Id = x.org.ParentId,
                    Name = x.org.Name,
                    Description = x.org.Description,
                    Level = x.org.Level,
                    Deleted = x.org.Deleted,

                    Created_At = x.org.CreatedAt,
                    Updated_At = x.org.UpdatedAt,

                    Created_By_Id = x.createdUser?.Id,
                    Created_By = x.createdUser?.Name,
                    Created_By_Name = x.createdUser?.Name,
                    Created_By_Surname = x.createdUser?.Surname,
                    Created_By_Profile = x.createdUser?.Profile,

                    Business_Logo = x.org.BusinessLogo,
                    Background_Image = x.org.BackgroundImage,
                    Header_Image = x.org.HeaderImage,
                    Footer_Image = x.org.FooterImage,
                    Font_Size = x.org.FontSize,
                    Pick_Color = x.org.PickColor,
                    Unique_Id = x.org.UniqueId,
                    Business_Address = x.org.BusinessAddress,

                    Department = departments
                        .Where(d => d.OrganizationId == x.org.Id)
                        .Select(d => new DepartmentDto
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Parent_Department = d.ParentDepartment
                        }).ToList()

                }).ToList();

                return new
                {
                    status = true,
                    data,
                    total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
