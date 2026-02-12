using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuSaniClientApi.Models.DBModels
{
    /// <summary>
    /// Location entity used for HSE appointments and across the application.
    /// Organization is stored as a JSON array string (e.g. "[1,2,3]") for multi-org support.
    /// </summary>
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string? UniqueId { get; set; }

        [StringLength(250)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        // Department FK
        public int? DepartmentId { get; set; }

        // Organization - stored as JSON array string e.g. "[1,2,3]"
        public string? Organization { get; set; }

        // Parent location (self-referencing for hierarchy)
        public int? Parent { get; set; }

        // Static flag - prevents deletion of seed data
        public int IsStatic { get; set; } = 0;

        // Audit fields
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;

        // Navigation properties
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        [ForeignKey(nameof(Parent))]
        public Location? ParentLocation { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public User? CreatedByUser { get; set; }

        [ForeignKey(nameof(UpdatedBy))]
        public User? UpdatedByUser { get; set; }
    }
}
