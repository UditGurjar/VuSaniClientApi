using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DTOs
{
    public class SidebarPermissionDto
    {
        public int SidebarId { get; set; }
        public Dictionary<string, PermissionActions> Permissions { get; set; } = new();
    }



}
