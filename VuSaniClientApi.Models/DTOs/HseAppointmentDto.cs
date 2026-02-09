using System;
using System.ComponentModel.DataAnnotations;

namespace VuSaniClientApi.Models.DTOs
{
    /// <summary>
    /// DTO for creating or updating an HSE Appointment
    /// </summary>
    public class CreateUpdateHseAppointmentRequest
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Appointer User ID is required.")]
        public int AppointsUserId { get; set; }

        [Required(ErrorMessage = "Appointed User ID is required.")]
        public int AppointedUserId { get; set; }

        public int? NameOfAppointment { get; set; }

        public string? LegalAppointmentRole { get; set; }

        [Required(ErrorMessage = "Effective Date is required.")]
        public DateTime EffectiveDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? PhysicalLocation { get; set; }

        public int? Organization { get; set; }

        public int? Department { get; set; }

        // File paths for signatures (uploaded files)
        public string? AppointerSignaturePath { get; set; }
        public string? AppointedSignaturePath { get; set; }
    }

    /// <summary>
    /// DTO for HSE Appointment list response
    /// </summary>
    public class HseAppointmentListDto
    {
        public int Id { get; set; }
        public string? UniqueId { get; set; }

        // Appointer details
        public int? AppointsUserId { get; set; }
        public string? AppointerName { get; set; }
        public string? AppointerSurname { get; set; }
        public string? AppointerFullName { get; set; }
        public string? AppointerProfile { get; set; }
        public string? AppointerEmail { get; set; }
        public string? AppointerRoleName { get; set; }

        // Appointed details
        public int? AppointedUserId { get; set; }
        public string? AppointedName { get; set; }
        public string? AppointedSurname { get; set; }
        public string? AppointedFullName { get; set; }
        public string? AppointedProfile { get; set; }
        public string? AppointedEmail { get; set; }
        public string? AppointedRoleName { get; set; }

        // Appointment type details
        public int? NameOfAppointment { get; set; }
        public string? AppointmentTypeName { get; set; }
        public string? Assignment { get; set; }
        public string? Designated { get; set; }
        public string? Applicable { get; set; }

        public string? LegalAppointmentRole { get; set; }

        // Dates
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Location
        public int? PhysicalLocation { get; set; }
        public string? PhysicalLocationName { get; set; }

        // Organization and Department
        public int? OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        // Signature fields
        public int? AppointerDdrmId { get; set; }
        public string? AppointerSignatureUrl { get; set; }
        public int? AppointedDdrmId { get; set; }
        public string? AppointedSignatureUrl { get; set; }
        public int? DdrmId { get; set; }

        // Status
        public string? Status { get; set; }
        public int? RenewedFromId { get; set; }

        // Agreement fields
        public string? AgreementId { get; set; }
        public string? AgreementStatus { get; set; }
        public string? LibraryDocumentId { get; set; }

        // Audit fields
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string? UpdatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// DTO for uploading HSE Appointment signature
    /// </summary>
    public class UploadHseAppointmentSignatureRequest
    {
        [Required]
        public int Id { get; set; }

        public int? SidebarId { get; set; }

        public int? DdrmId { get; set; }

        public string? SignaturePath { get; set; }

        public string? SignatureType { get; set; } // "appointer" or "appointed"
    }

    /// <summary>
    /// DTO for changing HSE Appointment status (Accept/Reject/Terminate)
    /// </summary>
    public class UpdateHseAppointmentStatusRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; } = null!; // Active, Rejected, Terminated
    }

    /// <summary>
    /// DTO for renewing an HSE Appointment
    /// </summary>
    public class RenewHseAppointmentRequest
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "New Effective Date is required.")]
        public DateTime EffectiveDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// DTO for HSE Hierarchy chart member
    /// </summary>
    public class HseHierarchyMemberDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? FullName { get; set; }
        public string? Profile { get; set; }
        public string? Email { get; set; }
        public string? RoleName { get; set; }
        public int? HierarchyLevel { get; set; }
        public string? HierarchyLevelName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public List<HseHierarchyMemberDto>? SubMembers { get; set; }
    }

    /// <summary>
    /// DTO for HSE Hierarchy chart response
    /// </summary>
    public class HseHierarchyDto
    {
        public int OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public string? BusinessLogo { get; set; }
        public List<HseHierarchyMemberDto>? Members { get; set; }
    }
}
