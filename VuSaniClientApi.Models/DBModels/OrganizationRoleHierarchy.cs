using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class OrganizationRoleHierarchy
    {
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;

        public int RoleHierarchyId { get; set; }
        public RoleHierarchy RoleHierarchy { get; set; } = null!;
    }
}
