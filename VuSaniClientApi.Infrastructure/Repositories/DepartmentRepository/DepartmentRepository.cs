using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetDepartmentsAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            try
            {
                var query =
                from dept in _context.Department
                join user in _context.Users
                    on dept.CreatedBy equals user.Id into users
                from user in users.DefaultIfEmpty()
                join deptHead in _context.Users
                    on dept.DepartmentHead equals deptHead.Id into deptHeads
                from deptHead in deptHeads.DefaultIfEmpty()
                join parentDept in _context.Department
                    on dept.ParentDepartment equals parentDept.Id into parentDepts
                from parentDept in parentDepts.DefaultIfEmpty()
                join org in _context.Organizations
                    on dept.OrganizationId equals org.Id into orgs
                from org in orgs.DefaultIfEmpty()
                where dept.Deleted == false
                select new { dept, user, deptHead, parentDept, org };

                // Search
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(x =>
                        (x.dept.Name != null && x.dept.Name.Contains(search)) ||
                        (x.dept.Description != null && x.dept.Description.Contains(search)) ||
                        (x.org != null && x.org.Name != null && x.org.Name.Contains(search)) ||
                        (x.user != null && x.user.Name != null && x.user.Name.Contains(search))
                    );
                }

                var total = await query.CountAsync();

                if (!all)
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);

                var rawData = await query.ToListAsync();

                var departments = rawData.Select(d => new DepartmentListDto
                {
                    Id = d.dept.Id,
                    Name = d.dept.Name,
                    Description = DecodeHelper.DecodeSingle(d.dept.Description),
                    OrganizationId = d.dept.OrganizationId,
                    Organization_name = d.org?.Name,
                    DepartmentHead = d.dept.DepartmentHead,
                    Department_head_name = d.deptHead?.Name,
                    Department_head_surname = d.deptHead?.Surname,
                    Department_head_profile = d.deptHead?.Profile,
                    ParentDepartment = d.dept.ParentDepartment,
                    Parent_department_name = d.parentDept?.Name,
                    UniqueId = d.dept.UniqueId,
                    CreatedBy = d.dept.CreatedBy,
                    Created_by = d.user?.Name,
                    Created_by_surname = d.user?.Surname,
                    Created_by_id = d.user?.Id,
                    Created_by_profile = d.user?.Profile
                }).ToList();

                return new
                {
                    status = true,
                    data = departments,
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

