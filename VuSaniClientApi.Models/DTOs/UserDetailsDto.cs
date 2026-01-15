using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DTOs
{
   
    public class UserDetailsDto
    {
        public string? Name { get; set; }
        public string? Profile { get; set; }
        public int? Manager { get; set; }
        public int? Is_Super_Admin { get; set; }
        public int? My_Organization { get; set; }

        public string? Organization_Name { get; set; }
        public string? Organization { get; set; }

        public int Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Unique_Id_Status { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Id_Number { get; set; }

        public DateTime? Joining_Date { get; set; }
        public DateTime? End_Date { get; set; }

        public int? Gender { get; set; }
        public string? Disability { get; set; }
        public string? Race { get; set; }
        public string? Employee_Type { get; set; }

        public int? Highest_Qualification { get; set; }
        public string? Name_Of_Qualification { get; set; }

        public int? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }

        public string? Current_Address { get; set; }

        public int? Role { get; set; }
        public string? Role_Desc { get; set; }
        public string? Level { get; set; }

        public string? Accountability { get; set; }
        public string? Otp { get; set; }

        public bool? Deleted { get; set; }
        public DateTime? Created_At { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int? Updated_By { get; set; }

        public string? City_Name { get; set; }
        public string? State_Name { get; set; }
        public string? Country_Name { get; set; }
        public string? Role_Name { get; set; }

        public string? Team_Members_Id { get; set; }
        public int? Department { get; set; }
        public string? Client_Internal_Id { get; set; }

    
    }

}
