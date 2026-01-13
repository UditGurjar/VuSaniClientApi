using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class OrganizationLicence
    {
        public int LicenceId { get; set; }
        public Licence Licence { get; set; } = null!;

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;
    }

}
