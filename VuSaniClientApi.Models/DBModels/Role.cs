using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Level { get; set; }

        [StringLength(250)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]

        public Organization? Organization { get; set; }

        public string? Responsibilities { get; set; }

        public int? Qualification { get; set; }

        [StringLength(500)]
        public string? YearOfExperience { get; set; }

        public string? OtherRequirements { get; set; }

        public string? SelectOtherRequirements { get; set; }

        [StringLength(11)]
        public string? ReportToRole { get; set; }

        public int? Department { get; set; }

        public int? Hierarchy { get; set; }

        public string? License { get; set; }

        public string? Skills { get; set; }

        public string? Permission { get; set; }

        public int? Deleted { get; set; } = 0;

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }

        public string? PreEmployment { get; set; }

        public string? PostEmployment { get; set; }

        [StringLength(250)]
        public string? UniqueId { get; set; }
    }
}
