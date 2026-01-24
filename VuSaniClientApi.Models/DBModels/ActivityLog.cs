using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuSaniClientApi.Models.DBModels
{
   
    public class ActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int? CreatedBy { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }

        [StringLength(500)]
        public string? Module { get; set; }

        public string? Message { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; }

        // Navigation property
        [ForeignKey(nameof(CreatedBy))]
        public User? User { get; set; }
    }
}

