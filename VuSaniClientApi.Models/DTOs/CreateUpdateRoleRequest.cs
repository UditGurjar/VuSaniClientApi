using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VuSaniClientApi.Models.DTOs
{
    public class CreateUpdateRoleRequest
    {
        public int? Id { get; set; }
        
        [Required(ErrorMessage = "Level is required.")]
        public int? Level { get; set; }
        
        [Required(ErrorMessage = "Role Name is required.")]
        public string Name { get; set; } = null!;
        
        [Required(ErrorMessage = "Role Description is required.")]
        public string Description { get; set; } = null!;
        
        public int? Organization { get; set; }
        
        public List<int>? License { get; set; }
        
        [Required(ErrorMessage = "Skills is required.")]
        public List<int> Skills { get; set; } = new List<int>();
        
        public int? Department { get; set; }
        
        public string? Role_accountability { get; set; }
        
        // Additional fields that might be in the request
        public int? Hierarchy { get; set; }
        public int? Qualification { get; set; }
        public string? Year_of_experience { get; set; }
        public string? Other_requirements { get; set; }
        public string? Select_other_requirements { get; set; }
        public string? Report_to_role { get; set; }
    }
}

