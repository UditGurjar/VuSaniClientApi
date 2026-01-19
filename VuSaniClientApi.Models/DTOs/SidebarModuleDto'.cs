using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DTOs
{
    public class SidebarModuleDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }

        public Dictionary<string, PermissionActions> Permissions { get; set; } = new();
        public List<SidebarModuleDto> Submodules { get; set; } = new();
    }

    public class PermissionActions
    {
        public bool View { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Create { get; set; }
    }


}
