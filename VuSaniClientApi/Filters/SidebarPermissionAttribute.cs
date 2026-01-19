using Microsoft.AspNetCore.Mvc;

namespace VuSaniClientApi.Filters
{
    public class SidebarPermissionAttribute : TypeFilterAttribute
    {
        public SidebarPermissionAttribute(string accessType, int moduleId, string tableName, string field = "organization")
            : base(typeof(SidebarPermissionFilter))
        {
            Arguments = new object[] { accessType, moduleId, tableName, field };
        }
    }

}
