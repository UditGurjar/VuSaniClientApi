using System;
using System.Collections.Generic;

namespace VuSaniClientApi.Models.DTOs
{
    public class CreateUpdateEmployeeRequest
    {
        public int? Id { get; set; }
        
        // Step 1: Personal Information
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Gender { get; set; }
        public string? NationalId { get; set; } // "South African" or "Other"
        public string? IdNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? VisaNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? WorkPermitExpiryDate { get; set; }
        public string? MaritalStatus { get; set; }
        public int? Language { get; set; }
        public string? Race { get; set; }
        public string? PersonWithDisabilities { get; set; } // "Yes" or "No"
        public string? Disability { get; set; }
        
        // Address Information
        public int? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? PostalAddress { get; set; }
        public string? CurrentAddress { get; set; }
        
        // Education & Qualifications
        public int? HighestQualification { get; set; }
        public string? NameOfQualification { get; set; }
        public string? Skills { get; set; } // JSON string
        public string? License { get; set; } // JSON string
        
        // Step 2: Employment Information
        public int? Organization { get; set; }
        public int? Department { get; set; }
        public int? EmployeeDepartment { get; set; }
        public int? Role { get; set; }
        public string? RoleDescription { get; set; }
        public int? EmployeeType { get; set; }
        public string? EmploymentStatus { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartProbationPeriod { get; set; }
        public DateTime? EndProbationPeriod { get; set; }
        public string? ProbationPeriod { get; set; }
        public int? HierarchyLevel { get; set; }
        
        // Manager/Supervisor - NOT REQUIRED (as per user request)
        public int? Manager { get; set; }
        
        // Financial Information
        public string? IncomeTaxNumber { get; set; }
        public string? TaxResidencyStatus { get; set; }
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public string? BranchCode { get; set; }
        public string? AccountType { get; set; }
        
        // Health Information
        public string? BloodType { get; set; }
        public string? Allergies { get; set; }
        public string? CurrentMedications { get; set; }
        public string? VaccinationRecords { get; set; } // JSON string
        
        // Emergency Contact
        public string? EmergencyContactDetails { get; set; } // JSON string
        
        // Employment Checks
        public string? PreEmploymentCheck { get; set; } // JSON string
        public string? PostEmploymentCheck { get; set; } // JSON string
        public string? EmploymentChecklist { get; set; } // JSON string
        
        // Documents & Files
        public string? Profile { get; set; }
        public int? DdrmId { get; set; }
        public List<PermitLicenseFile>? PermitLicenseFiles { get; set; }
        
        // Multi-step tracking
        public int? ActiveStep { get; set; }
        public string? CompletedStep { get; set; } // JSON string like "[true, true, false, false, false, false]"
        
        // Other fields
        public string? Accountability { get; set; }
        public string? Level { get; set; }
        public int? Age { get; set; }
        public int? ReasonForEmployeeBecomingInactive { get; set; }
        public DateTime? DateOfTermination { get; set; }
        public int? TeamId { get; set; }
        public int? SidebarId { get; set; } = 16;
        public string? PermitLicense { get; set; }
        public int? EmployeeDepartmentInfo { get; set; }
    }
    
    public class PermitLicenseFile
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? DdrmId { get; set; }
        public int? UserId { get; set; }
    }
}

