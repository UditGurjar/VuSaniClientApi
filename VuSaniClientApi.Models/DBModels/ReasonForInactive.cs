using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class ReasonForInactive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }   // HTML content

        public int? DepartmentId { get; set; }       // optional FK → Department.Id
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        public int? OrganizationId { get; set; }  
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        [StringLength(1)]
        public string Deleted { get; set; } = "0";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }

        [StringLength(100)]
        public string? UniqueId { get; set; }
    }

}
