using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuSaniClientApi.Models.DBModels
{
    /// <summary>
    /// Enum representing the lifecycle statuses of an HSE Appointment.
    /// Stored in the database as string values (e.g. "PendingAcceptance", "Active", etc.)
    /// </summary>
    public enum HseAppointmentStatus
    {
        PendingAcceptance,
        Active,
        Rejected,
        Terminated,
        Expired,
        Renewed
    }

    /// <summary>
    /// HSE Appointment record linking appointer and appointed users with appointment details.
    /// </summary>
    public class HseAppointment
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string? UniqueId { get; set; }

        // User who makes the appointment
        public int? AppointsUserId { get; set; }

        // User being appointed
        public int? AppointedUserId { get; set; }

        // Type of appointment (FK to AppointmentType)
        public int? NameOfAppointment { get; set; }

        [StringLength(255)]
        public string? LegalAppointmentRole { get; set; }

        // Dates
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Location
        public int? PhysicalLocation { get; set; }

        // Organization and Department
        public int? OrganizationId { get; set; }
        public int? DepartmentId { get; set; }

        // Status: PendingAcceptance, Active, Rejected, Terminated, Expired, Renewed
        public HseAppointmentStatus Status { get; set; } = HseAppointmentStatus.PendingAcceptance;

        // Reason for rejection (populated when Status = Rejected)
        public string? RejectionReason { get; set; }

        // Secure token for email-based accept/reject actions (GUID, unique per appointment)
        [StringLength(100)]
        public string? ActionToken { get; set; }

        // FK to the renewed-from appointment (null unless this is a renewal)
        public int? RenewedFromId { get; set; }

        // Signature fields - DDRM IDs
        public int? AppointerDdrmId { get; set; }
        public int? AppointedDdrmId { get; set; }
        public int? DdrmId { get; set; }

        // Agreement fields
        [StringLength(255)]
        public string? AgreementId { get; set; }

        [StringLength(100)]
        public string? AgreementStatus { get; set; }

        [StringLength(255)]
        public string? LibraryDocumentId { get; set; }

        // Audit fields
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;

        // Navigation properties
        [ForeignKey(nameof(AppointsUserId))]
        public User? AppointerUser { get; set; }

        [ForeignKey(nameof(AppointedUserId))]
        public User? AppointedUser { get; set; }

        [ForeignKey(nameof(NameOfAppointment))]
        public AppointmentType? AppointmentType { get; set; }

        [ForeignKey(nameof(PhysicalLocation))]
        public Location? Location { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public User? CreatedByUser { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public User? UpdatedByUser { get; set; }
    }
}
