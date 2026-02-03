using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuSaniClientApi.Models.DBModels
{
    /// <summary>
    /// Employee request for access to a software module; admins approve or reject.
    /// </summary>
    public class SoftwareAccessRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? Reason { get; set; }

        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [StringLength(255)]
        public string? UniqueId { get; set; }

        public int? SidebarId { get; set; }
        [ForeignKey(nameof(SidebarId))]
        public Sidebar? Sidebar { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "pending"; // pending, approved, rejected

        public int? Department { get; set; }
        [ForeignKey(nameof(Department))]
        public Department? DepartmentDetails { get; set; }

        public int? Organization { get; set; }
        [ForeignKey(nameof(Organization))]
        public Organization? OrganizationDetails { get; set; }

        public int Deleted { get; set; } = 0;

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        public User? Creator { get; set; }

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }
        [ForeignKey(nameof(UpdatedBy))]
        public User? Updater { get; set; }
    }
}
