namespace VuSaniClientApi.Models.DTOs
{
    public class ReasonForInactiveListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public string? CreatedBySurname { get; set; }
        public string? UniqueId { get; set; }
    }
}
