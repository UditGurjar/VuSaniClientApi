using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuSaniClientApi.Models.DBModels
{
    /// <summary>
    /// Physical location for HSE appointments.
    /// </summary>
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string? UniqueId { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        // Organization
        public int? OrganizationId { get; set; }

        // Audit fields
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;

        // Navigation properties
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public User? CreatedByUser { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public User? UpdatedByUser { get; set; }
    }
}
