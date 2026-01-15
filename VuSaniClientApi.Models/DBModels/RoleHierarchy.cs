using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class RoleHierarchy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // In DB: level is varchar in real data
        [StringLength(255)]
        public string? Level { get; set; }

        [StringLength(250)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? Department { get; set; }

        // JSON like: [3,2,1]
        public string? Organization { get; set; }

        public bool? Deleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        public int? Editable { get; set; } = 1;

        [StringLength(250)]
        public string? UniqueId { get; set; }
        public ICollection<OrganizationRoleHierarchy> OrganizationRoleHierarchies { get; set; } = new List<OrganizationRoleHierarchy>();

    }
}
