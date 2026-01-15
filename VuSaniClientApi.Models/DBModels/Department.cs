using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = null!;

        public int? DepartmentHead { get; set; }   

        [StringLength(500)]
        public string? Description { get; set; }

        public int? OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }

        public int? ParentDepartment { get; set; }

        [ForeignKey(nameof(ParentDepartment))]
        public Department? Parent { get; set; }

        public ICollection<Department>? Children { get; set; }

        [StringLength(100)]
        public string? UniqueId { get; set; }
    }

}
