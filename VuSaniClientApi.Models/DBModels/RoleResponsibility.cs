using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    //create multi relation ship between roles and responsibilities like many-to-many relationship
    public class RoleResponsibility
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int ResponsibilityId { get; set; }
        public Responsibility Responsibility { get; set; }
    }

}
