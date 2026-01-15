using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ParentId { get; set; }

        [StringLength(250)]
        public string? Name { get; set; }

        public string? Description { get; set; }   // longtext -> nvarchar(max)

        public int? Level { get; set; }

        public bool? Deleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public int? UpdatedBy { get; set; }

        public string? BusinessLogo { get; set; }

        public string? BackgroundImage { get; set; }

        public string? HeaderImage { get; set; }

        public string? FooterImage { get; set; }

        [StringLength(255)]
        public string? FontSize { get; set; }

        [StringLength(255)]
        public string? PickColor { get; set; }

        [StringLength(255)]
        public string? UniqueId { get; set; }

        [StringLength(255)]
        public string? BusinessAddress { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Organization? Parent { get; set; }

        public ICollection<Organization> Children { get; set; } = new List<Organization>();

        public ICollection<OrganizationLicence> OrganizationLicences { get; set; } = new List<OrganizationLicence>();
        public ICollection<OrganizationRoleHierarchy> OrganizationRoleHierarchies { get; set; } = new List<OrganizationRoleHierarchy>();
    }
}
