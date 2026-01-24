using System;

namespace VuSaniClientApi.Models.DTOs
{
    public class DepartmentListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? OrganizationId { get; set; }
        public string? Organization_name { get; set; }
        public int? DepartmentHead { get; set; }
        public string? Department_head_name { get; set; }
        public string? Department_head_surname { get; set; }
        public string? Department_head_profile { get; set; }
        public int? ParentDepartment { get; set; }
        public string? Parent_department_name { get; set; }
        public string? UniqueId { get; set; }
        public int? CreatedBy { get; set; }
        public string? Created_by { get; set; }
        public string? Created_by_surname { get; set; }
        public int? Created_by_id { get; set; }
        public string? Created_by_profile { get; set; }
    }
}

