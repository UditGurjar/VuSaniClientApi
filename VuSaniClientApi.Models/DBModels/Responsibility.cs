using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class Responsibility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [StringLength(250)]
        public string? Category { get; set; }

        public int? Priority { get; set; }

        public int? Department { get; set; }

        // JSON like: [1]
        public string? Organization { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public int? Deleted { get; set; } = 0;

        [StringLength(255)]
        public string? UniqueId { get; set; }
        public ICollection<RoleResponsibility> RoleResponsibilities { get; set; } = new List<RoleResponsibility>();
    }
}
