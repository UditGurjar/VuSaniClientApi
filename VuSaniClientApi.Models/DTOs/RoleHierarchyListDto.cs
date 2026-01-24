using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DTOs
{
    public class RoleHierarchyListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Level { get; set; }

        public string? CreatedBy { get; set; }
        public string? CreatedBySurname { get; set; }
        public int? CreatedById { get; set; }
        public string? CreatedByProfile { get; set; }

        public List<int> Organization { get; set; } = new(); // Array for frontend filtering
        public List<OrganizationMiniDto> Organization_Details { get; set; } = new();
    }

    public class OrganizationMiniDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
    }

}
