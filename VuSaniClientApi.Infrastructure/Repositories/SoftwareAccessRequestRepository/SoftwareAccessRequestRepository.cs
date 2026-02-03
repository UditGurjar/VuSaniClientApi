using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.SoftwareAccessRequestRepository
{
    public class SoftwareAccessRequestRepository : ISoftwareAccessRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public SoftwareAccessRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(List<SoftwareAccessRequestListDto> Data, int Total)> GetAsync(int? id, int page, int pageSize, bool all, string? search, string? filter, int currentUserId)
        {
            var query = from sar in _context.SoftwareAccessRequests
                       join creator in _context.Users on sar.CreatedBy equals creator.Id into creators
                       from creator in creators.DefaultIfEmpty()
                       join u1 in _context.Users on sar.UserId equals u1.Id into u1s
                       from u1 in u1s.DefaultIfEmpty()
                       join sidebar in _context.Sidebars on sar.SidebarId equals sidebar.Id into sidebars
                       from sidebar in sidebars.DefaultIfEmpty()
                       join org in _context.Organizations on sar.Organization equals org.Id into orgs
                       from org in orgs.DefaultIfEmpty()
                       join dept in _context.Department on sar.Department equals dept.Id into depts
                       from dept in depts.DefaultIfEmpty()
                       join u2 in _context.Users on (u1 != null ? u1.CreatedBy : (int?)null) equals u2.Id into u2s
                       from u2 in u2s.DefaultIfEmpty()
                       where sar.Deleted == 0
                             && (sar.UserId == currentUserId || (u1 != null && u1.CreatedBy == currentUserId))
                       select new { sar, creator, u1, sidebar, org, dept, u2 };

            if (id.HasValue)
                query = query.Where(x => x.sar.Id == id.Value);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.Trim();
                query = query.Where(x =>
                    (x.sar.Reason != null && x.sar.Reason.Contains(s)) ||
                    (x.u1 != null && (x.u1.Name + " " + x.u1.Surname).Contains(s)) ||
                    (x.org != null && x.org.Name != null && x.org.Name.Contains(s)) ||
                    (x.sidebar != null && x.sidebar.Title != null && x.sidebar.Title.Contains(s)));
            }

            var total = await query.CountAsync();

            if (!all)
                query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var rows = await query.ToListAsync();
            var list = rows.Select(x => new SoftwareAccessRequestListDto
            {
                Id = x.sar.Id,
                Reason = x.sar.Reason,
                UserId = x.sar.UserId,
                UserName = x.u1 != null ? x.u1.Name + " " + x.u1.Surname : null,
                UserProfile = x.u1 != null ? x.u1.Profile : null,
                SidebarId = x.sar.SidebarId,
                SidebarName = x.sidebar != null ? x.sidebar.Title : null,
                Status = x.sar.Status,
                Organization = x.sar.Organization,
                OrganizationName = x.org != null ? x.org.Name : null,
                Department = x.sar.Department,
                DepartmentName = x.dept != null ? x.dept.Name : null,
                CreatedBy = x.sar.CreatedBy,
                CreatedByName = x.creator != null ? x.creator.Name : null,
                CreatedByProfile = x.creator != null ? x.creator.Profile : null,
                UserCreatedBy = x.u2 != null ? x.u2.Name + " " + x.u2.Surname : null,
                UserCreatedById = x.u2 != null ? x.u2.Id : null,
                UniqueId = x.sar.UniqueId
            }).ToList();

            return (list, total);
        }

        public async Task<SoftwareAccessRequest?> GetByIdAsync(int id)
        {
            return await _context.SoftwareAccessRequests
                .FirstOrDefaultAsync(x => x.Id == id && x.Deleted == 0);
        }

        public async Task<SoftwareAccessRequest> CreateAsync(CreateUpdateSoftwareAccessRequestDto dto, int createdBy, string? uniqueId)
        {
            var entity = new SoftwareAccessRequest
            {
                Reason = dto.Reason,
                Organization = dto.Organization,
                SidebarId = dto.SidebarId,
                UserId = dto.UserId ?? createdBy,
                Status = dto.Status ?? "pending",
                Department = dto.Department,
                UniqueId = uniqueId,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow,
                UpdatedBy = createdBy,
                UpdatedAt = DateTime.UtcNow
            };
            _context.SoftwareAccessRequests.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(CreateUpdateSoftwareAccessRequestDto dto, int updatedBy)
        {
            if (!dto.Id.HasValue) return false;
            var entity = await _context.SoftwareAccessRequests.FindAsync(dto.Id.Value);
            if (entity == null || entity.Deleted != 0) return false;

            entity.Reason = dto.Reason;
            entity.Organization = dto.Organization;
            entity.SidebarId = dto.SidebarId;
            entity.UserId = dto.UserId ?? entity.UserId;
            entity.Status = dto.Status ?? entity.Status;
            entity.Department = dto.Department;
            entity.UpdatedBy = updatedBy;
            entity.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatusAsync(int id, string status, int updatedBy)
        {
            var entity = await _context.SoftwareAccessRequests.FindAsync(id);
            if (entity == null || entity.Deleted != 0) return false;
            entity.Status = status;
            entity.UpdatedBy = updatedBy;
            entity.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.SoftwareAccessRequests.FindAsync(id);
            if (entity == null) return false;
            entity.Deleted = 1;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
