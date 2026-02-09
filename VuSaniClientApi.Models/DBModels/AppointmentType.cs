using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuSaniClientApi.Models.DBModels
{
    /// <summary>
    /// Defines types of HSE appointments with assignment, designated, and applicable details.
    /// </summary>
    public class AppointmentType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string? UniqueId { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        // TEXT fields for detailed descriptions
        public string? Assignment { get; set; }
        public string? Designated { get; set; }
        public string? Applicable { get; set; }

        // Audit fields
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;

        // Navigation properties
        [ForeignKey(nameof(CreatedBy))]
        public User? CreatedByUser { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public User? UpdatedByUser { get; set; }
    }
}
