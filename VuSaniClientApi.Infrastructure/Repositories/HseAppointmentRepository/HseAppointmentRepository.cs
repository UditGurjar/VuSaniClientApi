using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Infrastructure.Helpers;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.HseAppointmentRepository
{
    public class HseAppointmentRepository : IHseAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public HseAppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetHseAppointmentsAsync(int page, int pageSize, bool all, string search, string filter)
        {
            try
            {
                var query = from hse in _context.HseAppointments
                            join appointerUser in _context.Users on hse.AppointsUserId equals appointerUser.Id into appointerGroup
                            from appointer in appointerGroup.DefaultIfEmpty()
                            join appointedUser in _context.Users on hse.AppointedUserId equals appointedUser.Id into appointedGroup
                            from appointed in appointedGroup.DefaultIfEmpty()
                            join appointmentType in _context.AppointmentTypes on hse.NameOfAppointment equals appointmentType.Id into typeGroup
                            from appType in typeGroup.DefaultIfEmpty()
                            join location in _context.Locations on hse.PhysicalLocation equals location.Id into locationGroup
                            from loc in locationGroup.DefaultIfEmpty()
                            join org in _context.Organizations on hse.OrganizationId equals org.Id into orgGroup
                            from organization in orgGroup.DefaultIfEmpty()
                            join dept in _context.Department on hse.DepartmentId equals dept.Id into deptGroup
                            from department in deptGroup.DefaultIfEmpty()
                            join appointerRole in _context.Roles on appointer.RoleId equals appointerRole.Id into appointerRoleGroup
                            from appRole in appointerRoleGroup.DefaultIfEmpty()
                            join appointedRole in _context.Roles on appointed.RoleId equals appointedRole.Id into appointedRoleGroup
                            from aptRole in appointedRoleGroup.DefaultIfEmpty()
                            join createdUser in _context.Users on hse.CreatedBy equals createdUser.Id into createdGroup
                            from created in createdGroup.DefaultIfEmpty()
                            where hse.Deleted == false
                            select new
                            {
                                hse,
                                appointer,
                                appointed,
                                appType,
                                loc,
                                organization,
                                department,
                                appRole,
                                aptRole,
                                created
                            };

                // Search filter
                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();
                    query = query.Where(x =>
                        (x.appointer != null && (x.appointer.Name + " " + x.appointer.Surname).ToLower().Contains(search)) ||
                        (x.appointed != null && (x.appointed.Name + " " + x.appointed.Surname).ToLower().Contains(search)) ||
                        (x.appType != null && x.appType.Name != null && x.appType.Name.ToLower().Contains(search)) ||
                        (x.organization != null && x.organization.Name != null && x.organization.Name.ToLower().Contains(search)) ||
                        (x.hse.UniqueId != null && x.hse.UniqueId.ToLower().Contains(search))
                    );
                }

                // Filter by organization
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    try
                    {
                        var filterObj = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(filter);
                        if (filterObj != null)
                        {
                            if (filterObj.TryGetValue("organization", out var orgVal) && TryGetIntFromElement(orgVal, out var orgId) && orgId > 0)
                                query = query.Where(x => x.hse.OrganizationId == orgId);
                            if (filterObj.TryGetValue("department", out var deptVal) && TryGetIntFromElement(deptVal, out var deptId) && deptId > 0)
                                query = query.Where(x => x.hse.DepartmentId == deptId);
                        }
                    }
                    catch { /* ignore parse errors */ }
                }

                // Order by most recent first
                query = query.OrderByDescending(x => x.hse.CreatedAt);

                var total = await query.CountAsync();

                // Pagination
                if (!all)
                {
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);
                }

                var rawData = await query.ToListAsync();

                // Map to DTO
                var data = rawData.Select(x => new HseAppointmentListDto
                {
                    Id = x.hse.Id,
                    UniqueId = x.hse.UniqueId,
                    
                    // Appointer
                    AppointsUserId = x.hse.AppointsUserId,
                    AppointerName = x.appointer?.Name,
                    AppointerSurname = x.appointer?.Surname,
                    AppointerFullName = x.appointer != null ? $"{x.appointer.Name} {x.appointer.Surname}".Trim() : null,
                    AppointerProfile = x.appointer?.Profile,
                    AppointerEmail = x.appointer?.Email,
                    AppointerRoleName = x.appRole?.Name,
                    
                    // Appointed
                    AppointedUserId = x.hse.AppointedUserId,
                    AppointedName = x.appointed?.Name,
                    AppointedSurname = x.appointed?.Surname,
                    AppointedFullName = x.appointed != null ? $"{x.appointed.Name} {x.appointed.Surname}".Trim() : null,
                    AppointedProfile = x.appointed?.Profile,
                    AppointedEmail = x.appointed?.Email,
                    AppointedRoleName = x.aptRole?.Name,
                    
                    // Appointment Type
                    NameOfAppointment = x.hse.NameOfAppointment,
                    AppointmentTypeName = x.appType?.Name,
                    Assignment = DecodeHelper.DecodeSingle(x.appType?.Assignment),
                    Designated = DecodeHelper.DecodeSingle(x.appType?.Designated),
                    Applicable = DecodeHelper.DecodeSingle(x.appType?.Applicable),
                    
                    LegalAppointmentRole = x.hse.LegalAppointmentRole,
                    
                    // Dates
                    EffectiveDate = x.hse.EffectiveDate,
                    EndDate = x.hse.EndDate,
                    
                    // Location
                    PhysicalLocation = x.hse.PhysicalLocation,
                    PhysicalLocationName = x.loc?.Name,
                    
                    // Organization & Department
                    OrganizationId = x.hse.OrganizationId,
                    OrganizationName = x.organization?.Name,
                    DepartmentId = x.hse.DepartmentId,
                    DepartmentName = x.department?.Name,
                    
                    // Signatures
                    AppointerDdrmId = x.hse.AppointerDdrmId,
                    AppointedDdrmId = x.hse.AppointedDdrmId,
                    DdrmId = x.hse.DdrmId,
                    
                    // Status - auto-expire if Active and EndDate has passed
                    Status = (x.hse.Status == "Active" && x.hse.EndDate.HasValue && x.hse.EndDate.Value.Date < DateTime.UtcNow.Date)
                        ? "Expired"
                        : x.hse.Status,
                    RenewedFromId = x.hse.RenewedFromId,

                    // Agreement
                    AgreementId = x.hse.AgreementId,
                    AgreementStatus = x.hse.AgreementStatus,
                    LibraryDocumentId = x.hse.LibraryDocumentId,
                    
                    // Audit
                    CreatedBy = x.hse.CreatedBy,
                    CreatedByName = x.created != null ? $"{x.created.Name} {x.created.Surname}".Trim() : null,
                    CreatedAt = x.hse.CreatedAt,
                    UpdatedBy = x.hse.UpdatedBy,
                    UpdatedAt = x.hse.UpdatedAt
                }).ToList();

                // Auto-expire: update DB for any Active records that have passed EndDate
                var expiredIds = data.Where(d => d.Status == "Expired").Select(d => d.Id).ToList();
                if (expiredIds.Any())
                {
                    var toExpire = await _context.HseAppointments
                        .Where(h => expiredIds.Contains(h.Id) && h.Status == "Active")
                        .ToListAsync();
                    foreach (var h in toExpire)
                    {
                        h.Status = "Expired";
                        h.UpdatedAt = DateTime.UtcNow;
                    }
                    if (toExpire.Any()) await _context.SaveChangesAsync();
                }

                return new
                {
                    status = true,
                    data = data,
                    total = total,
                    page = page,
                    pageSize = pageSize
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetHseAppointmentByIdAsync(int id)
        {
            try
            {
                var query = from hse in _context.HseAppointments
                            join appointerUser in _context.Users on hse.AppointsUserId equals appointerUser.Id into appointerGroup
                            from appointer in appointerGroup.DefaultIfEmpty()
                            join appointedUser in _context.Users on hse.AppointedUserId equals appointedUser.Id into appointedGroup
                            from appointed in appointedGroup.DefaultIfEmpty()
                            join appointmentType in _context.AppointmentTypes on hse.NameOfAppointment equals appointmentType.Id into typeGroup
                            from appType in typeGroup.DefaultIfEmpty()
                            join location in _context.Locations on hse.PhysicalLocation equals location.Id into locationGroup
                            from loc in locationGroup.DefaultIfEmpty()
                            join org in _context.Organizations on hse.OrganizationId equals org.Id into orgGroup
                            from organization in orgGroup.DefaultIfEmpty()
                            join dept in _context.Department on hse.DepartmentId equals dept.Id into deptGroup
                            from department in deptGroup.DefaultIfEmpty()
                            join appointerRole in _context.Roles on appointer.RoleId equals appointerRole.Id into appointerRoleGroup
                            from appRole in appointerRoleGroup.DefaultIfEmpty()
                            join appointedRole in _context.Roles on appointed.RoleId equals appointedRole.Id into appointedRoleGroup
                            from aptRole in appointedRoleGroup.DefaultIfEmpty()
                            join createdUser in _context.Users on hse.CreatedBy equals createdUser.Id into createdGroup
                            from created in createdGroup.DefaultIfEmpty()
                            join updatedUser in _context.Users on hse.UpdatedBy equals updatedUser.Id into updatedGroup
                            from updated in updatedGroup.DefaultIfEmpty()
                            where hse.Id == id && hse.Deleted == false
                            select new
                            {
                                hse,
                                appointer,
                                appointed,
                                appType,
                                loc,
                                organization,
                                department,
                                appRole,
                                aptRole,
                                created,
                                updated
                            };

                var result = await query.FirstOrDefaultAsync();

                if (result == null)
                {
                    return new { status = false, message = "HSE Appointment not found" };
                }

                var data = new HseAppointmentListDto
                {
                    Id = result.hse.Id,
                    UniqueId = result.hse.UniqueId,
                    
                    AppointsUserId = result.hse.AppointsUserId,
                    AppointerName = result.appointer?.Name,
                    AppointerSurname = result.appointer?.Surname,
                    AppointerFullName = result.appointer != null ? $"{result.appointer.Name} {result.appointer.Surname}".Trim() : null,
                    AppointerProfile = result.appointer?.Profile,
                    AppointerEmail = result.appointer?.Email,
                    AppointerRoleName = result.appRole?.Name,
                    
                    AppointedUserId = result.hse.AppointedUserId,
                    AppointedName = result.appointed?.Name,
                    AppointedSurname = result.appointed?.Surname,
                    AppointedFullName = result.appointed != null ? $"{result.appointed.Name} {result.appointed.Surname}".Trim() : null,
                    AppointedProfile = result.appointed?.Profile,
                    AppointedEmail = result.appointed?.Email,
                    AppointedRoleName = result.aptRole?.Name,
                    
                    NameOfAppointment = result.hse.NameOfAppointment,
                    AppointmentTypeName = result.appType?.Name,
                    Assignment = DecodeHelper.DecodeSingle(result.appType?.Assignment),
                    Designated = DecodeHelper.DecodeSingle(result.appType?.Designated),
                    Applicable = DecodeHelper.DecodeSingle(result.appType?.Applicable),
                    
                    LegalAppointmentRole = result.hse.LegalAppointmentRole,
                    
                    EffectiveDate = result.hse.EffectiveDate,
                    EndDate = result.hse.EndDate,
                    
                    PhysicalLocation = result.hse.PhysicalLocation,
                    PhysicalLocationName = result.loc?.Name,
                    
                    OrganizationId = result.hse.OrganizationId,
                    OrganizationName = result.organization?.Name,
                    DepartmentId = result.hse.DepartmentId,
                    DepartmentName = result.department?.Name,
                    
                    AppointerDdrmId = result.hse.AppointerDdrmId,
                    AppointedDdrmId = result.hse.AppointedDdrmId,
                    DdrmId = result.hse.DdrmId,

                    // Status - auto-expire if Active and EndDate has passed
                    Status = (result.hse.Status == "Active" && result.hse.EndDate.HasValue && result.hse.EndDate.Value.Date < DateTime.UtcNow.Date)
                        ? "Expired"
                        : result.hse.Status,
                    RenewedFromId = result.hse.RenewedFromId,
                    
                    AgreementId = result.hse.AgreementId,
                    AgreementStatus = result.hse.AgreementStatus,
                    LibraryDocumentId = result.hse.LibraryDocumentId,
                    
                    CreatedBy = result.hse.CreatedBy,
                    CreatedByName = result.created != null ? $"{result.created.Name} {result.created.Surname}".Trim() : null,
                    CreatedAt = result.hse.CreatedAt,
                    UpdatedBy = result.hse.UpdatedBy,
                    UpdatedByName = result.updated != null ? $"{result.updated.Name} {result.updated.Surname}".Trim() : null,
                    UpdatedAt = result.hse.UpdatedAt
                };

                // Auto-expire in DB if needed
                if (data.Status == "Expired" && result.hse.Status == "Active")
                {
                    var entity = await _context.HseAppointments.FindAsync(id);
                    if (entity != null)
                    {
                        entity.Status = "Expired";
                        entity.UpdatedAt = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                    }
                }

                return new { status = true, data = new List<HseAppointmentListDto> { data } };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> CreateHseAppointmentAsync(CreateUpdateHseAppointmentRequest request, int userId)
        {
            try
            {
                // Get organization from department if not provided
                int? organizationId = request.Organization;
                if (!organizationId.HasValue && request.Department.HasValue)
                {
                    var dept = await _context.Department
                        .Where(d => d.Id == request.Department.Value && d.Deleted == false)
                        .Select(d => d.OrganizationId)
                        .FirstOrDefaultAsync();
                    organizationId = dept;
                }

                // Check for date conflicts for "16 (1)" appointment type
                if (request.NameOfAppointment.HasValue)
                {
                    var appointmentType = await _context.AppointmentTypes
                        .Where(a => a.Id == request.NameOfAppointment.Value)
                        .Select(a => a.Name)
                        .FirstOrDefaultAsync();

                    if (appointmentType == "16 (1)")
                    {
                        var conflict = await _context.HseAppointments
                            .Where(h => h.Deleted == false
                                && h.OrganizationId == organizationId
                                && h.NameOfAppointment == request.NameOfAppointment
                                && h.EffectiveDate <= request.EffectiveDate
                                && (h.EndDate == null || h.EndDate >= request.EffectiveDate))
                            .AnyAsync();

                        if (conflict)
                        {
                            return new { status = false, message = "A 16 (1) appointment already exists for this organization within the specified date range" };
                        }
                    }
                }

                // Generate unique ID
                var uniqueId = await GeneralHelper.UniqueIdGeneratorAsync(
                    _context,
                    organizationId,
                    request.Department,
                    "HSE",
                    "HseAppointments",
                    "UniqueId"
                );

                var newAppointment = new HseAppointment
                {
                    UniqueId = uniqueId,
                    AppointsUserId = request.AppointsUserId,
                    AppointedUserId = request.AppointedUserId,
                    NameOfAppointment = request.NameOfAppointment,
                    LegalAppointmentRole = request.LegalAppointmentRole,
                    EffectiveDate = request.EffectiveDate,
                    EndDate = request.EndDate,
                    PhysicalLocation = request.PhysicalLocation,
                    OrganizationId = organizationId,
                    DepartmentId = request.Department,
                    Status = "PendingAcceptance",
                    CreatedBy = userId,
                    CreatedAt = DateTime.UtcNow,
                    Deleted = false
                };

                _context.HseAppointments.Add(newAppointment);
                await _context.SaveChangesAsync();

                // Insert activity log
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "create", "HSE Appointment", newAppointment.Id);

                // Send emails to appointer and appointed
                try
                {
                    var appointer = await _context.Users
                        .Where(u => u.Id == request.AppointsUserId)
                        .Select(u => new { u.Name, u.Surname, u.Email, u.MyOrganization })
                        .FirstOrDefaultAsync();

                    var appointed = await _context.Users
                        .Where(u => u.Id == request.AppointedUserId)
                        .Select(u => new { u.Name, u.Surname, u.Email })
                        .FirstOrDefaultAsync();

                    var appointmentTypeName = request.NameOfAppointment.HasValue
                        ? await _context.AppointmentTypes
                            .Where(a => a.Id == request.NameOfAppointment.Value)
                            .Select(a => a.Name)
                            .FirstOrDefaultAsync() ?? ""
                        : "";

                    var companyName = appointer?.MyOrganization.HasValue == true
                        ? await _context.Organizations
                            .Where(o => o.Id == appointer.MyOrganization.Value)
                            .Select(o => o.Name)
                            .FirstOrDefaultAsync() ?? ""
                        : "";

                    var appointerFullName = $"{appointer?.Name} {appointer?.Surname}".Trim();
                    var appointedFullName = $"{appointed?.Name} {appointed?.Surname}".Trim();
                    var effectiveDateStr = request.EffectiveDate.ToString("dd MMMM yyyy");
                    var endDateStr = request.EndDate?.ToString("dd MMMM yyyy") ?? "";

                    // Email to Appointer
                    if (!string.IsNullOrWhiteSpace(appointer?.Email))
                    {
                        //await _emailService.SendHseAppointmentAppointerEmailAsync(
                        //    appointer.Email, appointerFullName, appointedFullName,
                        //    companyName, appointmentTypeName, effectiveDateStr, endDateStr);
                    }

                    // Email to Appointed
                    if (!string.IsNullOrWhiteSpace(appointed?.Email))
                    {
                        //await _emailService.SendHseAppointmentAppointedEmailAsync(
                        //    appointed.Email, appointerFullName, appointedFullName,
                        //    companyName, appointmentTypeName, effectiveDateStr, endDateStr);
                    }
                }
                catch (Exception)
                {
                    // Email failure should not fail the create operation
                }

                return new { status = true, message = "HSE Appointment created successfully", id = newAppointment.Id };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> UpdateHseAppointmentAsync(CreateUpdateHseAppointmentRequest request, int userId)
        {
            try
            {
                if (!request.Id.HasValue)
                {
                    return new { status = false, message = "HSE Appointment ID is required for update" };
                }

                var appointment = await _context.HseAppointments
                    .FirstOrDefaultAsync(h => h.Id == request.Id.Value && h.Deleted == false);

                if (appointment == null)
                {
                    return new { status = false, message = "HSE Appointment not found" };
                }

                // Get organization from department if not provided
                int? organizationId = request.Organization ?? appointment.OrganizationId;
                if (request.Department.HasValue && !request.Organization.HasValue)
                {
                    var dept = await _context.Department
                        .Where(d => d.Id == request.Department.Value && d.Deleted == false)
                        .Select(d => d.OrganizationId)
                        .FirstOrDefaultAsync();
                    if (dept.HasValue) organizationId = dept;
                }

                // Check for date conflicts for "16 (1)" appointment type (excluding current)
                if (request.NameOfAppointment.HasValue)
                {
                    var appointmentType = await _context.AppointmentTypes
                        .Where(a => a.Id == request.NameOfAppointment.Value)
                        .Select(a => a.Name)
                        .FirstOrDefaultAsync();

                    if (appointmentType == "16 (1)")
                    {
                        var conflict = await _context.HseAppointments
                            .Where(h => h.Deleted == false
                                && h.Id != request.Id.Value
                                && h.OrganizationId == organizationId
                                && h.NameOfAppointment == request.NameOfAppointment
                                && h.EffectiveDate <= request.EffectiveDate
                                && (h.EndDate == null || h.EndDate >= request.EffectiveDate))
                            .AnyAsync();

                        if (conflict)
                        {
                            return new { status = false, message = "A 16 (1) appointment already exists for this organization within the specified date range" };
                        }
                    }
                }

                // Update fields
                appointment.AppointsUserId = request.AppointsUserId;
                appointment.AppointedUserId = request.AppointedUserId;
                appointment.NameOfAppointment = request.NameOfAppointment;
                appointment.LegalAppointmentRole = request.LegalAppointmentRole;
                appointment.EffectiveDate = request.EffectiveDate;
                appointment.EndDate = request.EndDate;
                appointment.PhysicalLocation = request.PhysicalLocation;
                appointment.OrganizationId = organizationId;
                appointment.DepartmentId = request.Department;
                appointment.UpdatedBy = userId;
                appointment.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // Insert activity log
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "update", "HSE Appointment", appointment.Id);

                return new { status = true, message = "HSE Appointment updated successfully", id = appointment.Id };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> DeleteHseAppointmentAsync(int id, int userId)
        {
            try
            {
                var appointment = await _context.HseAppointments
                    .FirstOrDefaultAsync(h => h.Id == id && h.Deleted == false);

                if (appointment == null)
                {
                    return new { status = false, message = "HSE Appointment not found" };
                }

                // Soft delete
                appointment.Deleted = true;
                appointment.UpdatedBy = userId;
                appointment.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // Insert activity log
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "delete", "HSE Appointment", id);

                return new { status = true, message = "HSE Appointment deleted successfully" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> UploadSignatureAsync(UploadHseAppointmentSignatureRequest request, int userId)
        {
            try
            {
                var appointment = await _context.HseAppointments
                    .FirstOrDefaultAsync(h => h.Id == request.Id && h.Deleted == false);

                if (appointment == null)
                {
                    return new { status = false, message = "HSE Appointment not found" };
                }

                // Update signature based on type
                if (request.SignatureType?.ToLower() == "appointer")
                {
                    appointment.AppointerDdrmId = request.DdrmId;
                }
                else if (request.SignatureType?.ToLower() == "appointed")
                {
                    appointment.AppointedDdrmId = request.DdrmId;
                }
                else
                {
                    appointment.DdrmId = request.DdrmId;
                }

                appointment.UpdatedBy = userId;
                appointment.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return new { status = true, message = "Signature uploaded successfully" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetHseHierarchyAsync(int organizationId)
        {
            try
            {
                // Get organization details
                var organization = await _context.Organizations
                    .Where(o => o.Id == organizationId && o.Deleted == false)
                    .Select(o => new { o.Id, o.Name, o.BusinessLogo })
                    .FirstOrDefaultAsync();

                if (organization == null)
                {
                    return new { status = false, message = "Organization not found" };
                }

                // Get all HSE appointed users for this organization
                var hseAppointments = await (from hse in _context.HseAppointments
                                             join user in _context.Users on hse.AppointedUserId equals user.Id
                                             join role in _context.Roles on user.RoleId equals role.Id into roleGroup
                                             from r in roleGroup.DefaultIfEmpty()
                                             join hierarchy in _context.RoleHierarchies on r.Hierarchy equals hierarchy.Id into hierarchyGroup
                                             from h in hierarchyGroup.DefaultIfEmpty()
                                             join dept in _context.Department on user.Department equals dept.Id into deptGroup
                                             from d in deptGroup.DefaultIfEmpty()
                                             where hse.Deleted == false
                                                && hse.OrganizationId == organizationId
                                                && user.Deleted == false
                                             select new HseHierarchyMemberDto
                                             {
                                                 Id = user.Id,
                                                 Name = user.Name,
                                                 Surname = user.Surname,
                                                 FullName = (user.Name + " " + user.Surname).Trim(),
                                                 Profile = user.Profile,
                                                 Email = user.Email,
                                                 RoleName = r != null ? r.Name : null,
                                                 HierarchyLevel = r != null ? r.Hierarchy : null,
                                                 HierarchyLevelName = h != null ? h.Name : null,
                                                 DepartmentId = user.Department,
                                                 DepartmentName = d != null ? d.Name : null
                                             })
                                            .Distinct()
                                            .OrderBy(x => x.HierarchyLevel)
                                            .ToListAsync();

                // Build hierarchy tree (simple flat list for now, can be enhanced)
                var result = new HseHierarchyDto
                {
                    OrganizationId = organization.Id,
                    OrganizationName = organization.Name,
                    BusinessLogo = organization.BusinessLogo,
                    Members = hseAppointments
                };

                return new { status = true, data = result };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> UpdateStatusAsync(UpdateHseAppointmentStatusRequest request, int userId)
        {
            try
            {
                var appointment = await _context.HseAppointments
                    .FirstOrDefaultAsync(h => h.Id == request.Id && h.Deleted == false);

                if (appointment == null)
                    return new { status = false, message = "HSE Appointment not found" };

                // Validate status transitions per workflow
                var validTransitions = new Dictionary<string, string[]>
                {
                    { "PendingAcceptance", new[] { "Active", "Rejected" } },
                    { "Rejected", new[] { "PendingAcceptance" } },      // Can resubmit
                    { "Active", new[] { "Terminated" } },               // Terminate by editing
                };

                if (!validTransitions.ContainsKey(appointment.Status) ||
                    !validTransitions[appointment.Status].Contains(request.Status))
                {
                    return new { status = false, message = $"Cannot transition from '{appointment.Status}' to '{request.Status}'" };
                }

                appointment.Status = request.Status;
                appointment.UpdatedBy = userId;
                appointment.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // Activity log
                var actionDesc = request.Status switch
                {
                    "Active" => "accepted",
                    "Rejected" => "rejected",
                    "Terminated" => "terminated",
                    _ => "updated status of"
                };
                await GeneralHelper.InsertActivityLogAsync(_context, userId, actionDesc, "HSE Appointment", appointment.Id);

                // Send status change email to both appointer and appointed
                try
                {
                    var appointer = await _context.Users
                        .Where(u => u.Id == appointment.AppointsUserId)
                        .Select(u => new { u.Name, u.Surname, u.Email })
                        .FirstOrDefaultAsync();

                    var appointed = await _context.Users
                        .Where(u => u.Id == appointment.AppointedUserId)
                        .Select(u => new { u.Name, u.Surname, u.Email })
                        .FirstOrDefaultAsync();

                    var appointmentTypeName = appointment.NameOfAppointment.HasValue
                        ? await _context.AppointmentTypes
                            .Where(a => a.Id == appointment.NameOfAppointment.Value)
                            .Select(a => a.Name)
                            .FirstOrDefaultAsync() ?? ""
                        : "";

                    var appointedFullName = $"{appointed?.Name} {appointed?.Surname}".Trim();

                    if (!string.IsNullOrWhiteSpace(appointer?.Email))
                    {
                        //await _emailService.SendHseAppointmentStatusChangeEmailAsync(
                        //    appointer.Email, $"{appointer.Name} {appointer.Surname}".Trim(),
                        //    appointmentTypeName, appointedFullName, request.Status);
                    }

                    if (!string.IsNullOrWhiteSpace(appointed?.Email))
                    {
                        //await _emailService.SendHseAppointmentStatusChangeEmailAsync(
                        //    appointed.Email, appointedFullName,
                        //    appointmentTypeName, appointedFullName, request.Status);
                    }
                }
                catch (Exception)
                {
                    // Email failure should not fail the status update
                }

                return new { status = true, message = $"HSE Appointment {actionDesc} successfully", id = appointment.Id };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> RenewAppointmentAsync(RenewHseAppointmentRequest request, int userId)
        {
            try
            {
                var original = await _context.HseAppointments
                    .FirstOrDefaultAsync(h => h.Id == request.Id && h.Deleted == false);

                if (original == null)
                    return new { status = false, message = "HSE Appointment not found" };

                if (original.Status != "Expired")
                    return new { status = false, message = "Only expired appointments can be renewed" };

                // Mark original as Renewed
                original.Status = "Renewed";
                original.UpdatedBy = userId;
                original.UpdatedAt = DateTime.UtcNow;

                // Generate unique ID for the new record
                var uniqueId = await GeneralHelper.UniqueIdGeneratorAsync(
                    _context,
                    original.OrganizationId,
                    original.DepartmentId,
                    "HSE",
                    "HseAppointments",
                    "UniqueId"
                );

                // Create new appointment record with same details but new dates
                var renewed = new HseAppointment
                {
                    UniqueId = uniqueId,
                    AppointsUserId = original.AppointsUserId,
                    AppointedUserId = original.AppointedUserId,
                    NameOfAppointment = original.NameOfAppointment,
                    LegalAppointmentRole = original.LegalAppointmentRole,
                    EffectiveDate = request.EffectiveDate,
                    EndDate = request.EndDate,
                    PhysicalLocation = original.PhysicalLocation,
                    OrganizationId = original.OrganizationId,
                    DepartmentId = original.DepartmentId,
                    Status = "PendingAcceptance",
                    RenewedFromId = original.Id,
                    CreatedBy = userId,
                    CreatedAt = DateTime.UtcNow,
                    Deleted = false
                };

                _context.HseAppointments.Add(renewed);
                await _context.SaveChangesAsync();

                // Activity logs
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "renewed", "HSE Appointment", original.Id);
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "create", "HSE Appointment", renewed.Id);

                return new
                {
                    status = true,
                    message = "HSE Appointment renewed successfully. A new appointment has been created.",
                    originalId = original.Id,
                    newId = renewed.Id
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool TryGetIntFromElement(JsonElement element, out int value)
        {
            value = 0;
            if (element.ValueKind == JsonValueKind.Number && element.TryGetInt32(out value))
                return true;
            if (element.ValueKind == JsonValueKind.String)
            {
                var s = element.GetString();
                return int.TryParse(s, out value);
            }
            return false;
        }
    }
}
