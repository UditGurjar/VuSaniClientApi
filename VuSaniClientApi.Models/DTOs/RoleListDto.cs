using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DTOs
{
    public class RoleListDto
    {
        public int Id { get; set; }
        public string? Unique_id { get; set; }

        public int? Report_to_role { get; set; }
        public string? Report_to_role_name { get; set; }

        public int? Hierarchy { get; set; }
        public int? Qualification { get; set; }

        public string? Year_of_experience { get; set; }

        public List<int> License { get; set; } = new();

        public string? License_name { get; set; }
        public string? Other_requirements { get; set; }
        public string? Select_other_requirements { get; set; }

        public string? Level { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public int? Organization { get; set; }
        public string? Organization_name { get; set; }

        public string? Header_image { get; set; }
        public string? Footer_image { get; set; }
        public string? Business_logo { get; set; }

        public int? Created_by_id { get; set; }
        public string? Created_by { get; set; }
        public string? Created_by_profile { get; set; }
        public string? Created_by_surname { get; set; }

        public string? Hierarchy_name { get; set; }
        public string? Qualification_name { get; set; }

        public List<IdNameDto> SkillsDetail { get; set; } = new();
        public List<IdNameDto> LicenseDetail { get; set; } = new();
        public List<IdNameDto> ResponsibilityDetail { get; set; } = new();
    }

    public class IdNameDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

}
