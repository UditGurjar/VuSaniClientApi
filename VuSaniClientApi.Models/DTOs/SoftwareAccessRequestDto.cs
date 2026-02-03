using System.Collections.Generic;

namespace VuSaniClientApi.Models.DTOs
{
    public class SoftwareAccessRequestListDto
    {
        public int Id { get; set; }
        public string? Reason { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserProfile { get; set; }
        public int? SidebarId { get; set; }
        public string? SidebarName { get; set; }
        public string? Status { get; set; }
        public int? Organization { get; set; }
        public string? OrganizationName { get; set; }
        public int? Department { get; set; }
        public string? DepartmentName { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public string? CreatedByProfile { get; set; }
        public string? UserCreatedBy { get; set; }
        public int? UserCreatedById { get; set; }
        public string? UniqueId { get; set; }
    }

    public class CreateUpdateSoftwareAccessRequestDto
    {
        public int? Id { get; set; }
        public string? Reason { get; set; }
        public int? Organization { get; set; }
        public int? SidebarId { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public int? Department { get; set; }
    }

    public class UpdateSoftwareAccessDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = "role"; // "role" | "user"
        public int OrganizationId { get; set; }
        public List<SidebarPermissionDto>? Permission { get; set; }
        public string? Organizations { get; set; } // JSON array of org ids
    }

    public class UpdateAccessRequestStatusDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = "pending"; // approved | rejected
    }
}
