using System;
using System.ComponentModel.DataAnnotations;

namespace VuSaniClientApi.Models.DTOs
{
    /// <summary>
    /// DTO for creating or updating an Appointment Type
    /// </summary>
    public class CreateUpdateAppointmentTypeRequest
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Appointment Type Name is required.")]
        public string Name { get; set; } = null!;

        public string? Assignment { get; set; }
        public string? Designated { get; set; }
        public string? Applicable { get; set; }
    }

    /// <summary>
    /// DTO for Appointment Type list/detail response
    /// </summary>
    public class AppointmentTypeListDto
    {
        public int Id { get; set; }
        public string? UniqueId { get; set; }
        public string? Name { get; set; }
        public string? Assignment { get; set; }
        public string? Designated { get; set; }
        public string? Applicable { get; set; }

        // Audit fields
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string? UpdatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
