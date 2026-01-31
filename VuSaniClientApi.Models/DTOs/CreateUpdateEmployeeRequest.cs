using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace VuSaniClientApi.Models.DTOs
{
    public class CreateUpdateEmployeeRequest
    {
        public int? Id { get; set; }
        
        // ============================================
        // STEP 0: PERSONAL INFORMATION
        // ============================================
        
        // Organization (from Step 0 validation)
        public int? Organization { get; set; }
        
        // Basic Personal Details
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? MaritalStatus { get; set; }
        
        // Identification Documents
        public string? NationalId { get; set; } // "South African" or "Other"
        public string? IdNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? VisaNumber { get; set; }
        
        // Demographics
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
        
        // Education & Qualifications
        public int? HighestQualification { get; set; }
        public string? NameOfQualification { get; set; }
        
        // Profile Picture
        public IFormFile? Profile { get; set; } // File upload
        public string? ProfilePath { get; set; } // File path after upload
        
        // ============================================
        // STEP 1: EMPLOYMENT INFORMATION
        // ============================================
        
        // Role & Position
        public int? Role { get; set; } // REQUIRED for Step 1
        public string? RoleDescription { get; set; }
        
        // Department
        public int? Department { get; set; }
        public int? EmployeeDepartment { get; set; }
        public int? EmployeeDepartmentInfo { get; set; }
        
        // Employment Details
        public int? EmployeeType { get; set; }
        public string? EmploymentStatus { get; set; }
        
        // Employment Dates
        public DateTime? DateOfEmployment { get; set; }
        public DateTime? StartProbationPeriod { get; set; }
        public DateTime? EndProbationPeriod { get; set; }
        public DateTime? DateOfTermination { get; set; }
        public string? EmergencyContactDetails { get; set; }

        // Termination
        public int? ReasonForEmployeeBecomingInactive { get; set; }
        
        // ============================================
        // MULTI-STEP TRACKING
        // ============================================
        public int? ActiveStep { get; set; } // 0 = Personal Information, 1 = Employment Information
        public string? CompletedStep { get; set; } // JSON string like "[true, false]" for [Step0, Step1]

    }
}

