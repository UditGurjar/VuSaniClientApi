using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VuSaniClientApi.Models.DTOs
{
    public class EmployeeListDto
    {
        public int Id { get; set; }
        public string? UniqueId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Profile { get; set; }
        
        // Personal Information
        public int? Gender { get; set; }
        public string? GenderName { get; set; }
        public string? IdNumber { get; set; }
        public string? PassportNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? MaritalStatus { get; set; }
        public string? NationalId { get; set; }
        
        // Organization & Role
        public int? MyOrganization { get; set; }
        public string? OrganizationName { get; set; }
        /// <summary>Work location from organization's business address (same as Node.js: organization.business_address as work_location).</summary>
        public string? BusinessAddress { get; set; }
        public int? Department { get; set; }
        public string? DepartmentName { get; set; }
        public int? Role { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        
        // Employment Details
        public int? EmployeeType { get; set; }
        public string? EmployeeTypeName { get; set; }
        public string? EmploymentStatus { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? DateOfTermination { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? EndDate { get; set; }
        
        // Location
        public int? Country { get; set; }
        public string? CountryName { get; set; }
        public int? State { get; set; }
        public string? StateName { get; set; }
        public int? City { get; set; }
        public string? CityName { get; set; }
        public string? CurrentAddress { get; set; }
        
        // Qualifications
        public int? HighestQualification { get; set; }
        public string? HighestQualificationName { get; set; }
        public string? NameOfQualification { get; set; }
        
        // Skills & Licenses (as arrays for frontend)
        public List<int> Skills { get; set; } = new();
        public List<int> License { get; set; } = new();
        
        // Multi-step tracking
        public int? ActiveStep { get; set; }
        public List<bool> CompletedStep { get; set; } = new();
        
        // Audit fields
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string? UpdatedByName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // Manager
        public int? Manager { get; set; }
        public string? ManagerName { get; set; }

        // Additional fields for detail view
        public int? Race { get; set; }
        public string? RaceName { get; set; }
        public string? PersonWithDisabilities { get; set; }
        public string? Disability { get; set; }
        // ? correct
        //public List<int> Disability { get; set; } = new();
        //public List<string> DisabilityName { get; set; } = new();
        public int? Language { get; set; }
        public string? LanguageName { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PostalAddress { get; set; }
        public string? VisaNumber { get; set; }
        public DateTime? WorkPermitExpiryDate { get; set; }
        public string? BloodType { get; set; }
        public string? IncomeTaxNumber { get; set; }
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public int? HierarchyLevel { get; set; }
        public string? HierarchyLevelName { get; set; }
        public string? Accountability { get; set; }
        public int? ReasonForEmployeeBecomingInactive { get; set; }
        /// <summary>Display name from reason_for_inactive (same as Node.js reason_for_employee_becoming_inactive_name).</summary>
        public string? ReasonForEmployeeBecomingInactiveName { get; set; }
        public string? Level { get; set; }
        public string? ProbationPeriod { get; set; }
        public DateTime? StartProbationPeriod { get; set; }
        public DateTime? EndProbationPeriod { get; set; }

        /// <summary>
        /// Emergency contact details from NextOfKin table (contact_name, employee = relationship id, contact_number, relation_name).
        /// </summary>
        public List<EmergencyContactItemDto> EmergencyContactDetails { get; set; } = new();
    }

    public class EmergencyContactItemDto
    {
        public string? ContactName { get; set; }
        public int? Employee { get; set; } // RelationshipId
        public string? ContactNumber { get; set; }
        public string? RelationName { get; set; }
    }
}

