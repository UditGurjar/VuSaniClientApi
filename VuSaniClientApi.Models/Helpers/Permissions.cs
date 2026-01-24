using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.Helpers
{
    public class Permissions
    {
        public class UserPermission
        {
            public int SidebarId { get; set; }
            public Dictionary<string, PermissionActions> Permissions { get; set; } = new();
        }

        public class PermissionActions
        {
            public bool View { get; set; }
            public bool Create { get; set; }
            public bool Edit { get; set; }
            public bool Delete { get; set; }
        }
    }
}
