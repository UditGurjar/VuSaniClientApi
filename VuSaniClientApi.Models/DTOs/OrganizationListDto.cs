using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DTOs
{
    public class OrganizationListDto
    {
        public int Id { get; set; }
        public int? Parent_Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Level { get; set; }
        public bool? Deleted { get; set; }

        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }

        public int? Created_By_Id { get; set; }
        public string? Created_By { get; set; }
        public string? Created_By_Name { get; set; }
        public string? Created_By_Surname { get; set; }
        public string? Created_By_Profile { get; set; }

        public string? Business_Logo { get; set; }
        public string? Background_Image { get; set; }
        public string? Header_Image { get; set; }
        public string? Footer_Image { get; set; }
        public string? Font_Size { get; set; }
        public string? Pick_Color { get; set; }
        public string? Unique_Id { get; set; }
        public string? Business_Address { get; set; }

        public List<DepartmentDto> Department { get; set; } = new();
    }
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Parent_Department { get; set; }
    }

}
