using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VuSaniClientApi.Models.DTOs
{
    /// <summary>
    /// DTO for creating or updating a Location
    /// </summary>
    public class CreateUpdateLocationRequest
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Location Name is required.")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        public int? Department { get; set; }
        public List<int>? Organization { get; set; }
        public int? Parent_Id { get; set; }
    }

    /// <summary>
    /// DTO for Location list/detail response
    /// </summary>
    public class LocationListDto
    {
        public int Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        // Organization - as parsed list of IDs
        public List<int>? Organization { get; set; }

        // Organization details (when grouped=true)
        public List<OrganizationMiniDto>? Organization_Details { get; set; }

        // Department
        public int? Department_Id { get; set; }
        public string? Department_Name { get; set; }

        // Parent
        public int? Parent_Id { get; set; }
        public string? Parent_Name { get; set; }

        // Is Static flag
        public int Is_Static { get; set; }

        // Audit
        public int? Created_By_Id { get; set; }
        public string? Created_By { get; set; }
        public string? Created_By_Surname { get; set; }
        public string? Created_By_Profile { get; set; }
        public DateTime? Created_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
    }

    /// <summary>
    /// DTO for Location dropdown item
    /// </summary>
    public class LocationDropDownDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Parent { get; set; }
        public List<int>? Organization { get; set; }
    }
}
