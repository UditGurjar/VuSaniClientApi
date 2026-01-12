using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.DBModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        public string? UniqueId { get; set; }

        [StringLength(20)]
        public string? UniqueIdStatus { get; set; } // automatic / manual

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Surname { get; set; }

        [StringLength(255)]
        public string? Email { get; set; }

        [StringLength(255)]
        public string? Password { get; set; }

        [StringLength(250)]
        public string? Profile { get; set; } = "profile/default_profile.png";

        [StringLength(255)]
        public string? IdNumber { get; set; }

        public DateTime? JoiningDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? Gender { get; set; }

        public string? Disability { get; set; }

        [StringLength(255)]
        public string? Race { get; set; }

        [StringLength(255)]
        public string? EmployeeType { get; set; }

        public int? HighestQualificationId { get; set; }
        [ForeignKey(nameof(HighestQualificationId))]
        public HighestQualification? HighestQualification { get; set; }


        [StringLength(255)]
        public string? NameOfQualification { get; set; }

        public int? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }

        public int? RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
        public string? RoleDesc { get; set; }

        [StringLength(255)]
        public string? Level { get; set; }

        public int? Department { get; set; }

        public string? Accountability { get; set; }
        public string? Skills { get; set; }
        public string? License { get; set; }

        [StringLength(250)]
        public string? Otp { get; set; }

        public int? MyOrganization { get; set; }

        public string? Organization { get; set; }
        public string? Permission { get; set; }

        public int? SpecialPermission { get; set; } = 0;

        public string? NotificationSender { get; set; }

        public string? OrganizationAccess { get; set; }

        [StringLength(10)]
        public string? ViewType { get; set; } = "all";

        public int? IsSuperAdmin { get; set; } = 0;

        [StringLength(1)]
        public string? Deleted { get; set; } = "0";

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }

        public int? Age { get; set; }

        [StringLength(255)]
        public string? PassportNumber { get; set; }

        [StringLength(255)]
        public string? MaritalStatus { get; set; }

        public string? EmployeeContactDetails { get; set; }

        [StringLength(255)]
        public string? EmploymentStatus { get; set; }

        [StringLength(255)]
        public string? ProbationPeriod { get; set; }

        public DateTime? DateOfTermination { get; set; }

        [StringLength(500)]
        public string? ResidentialAddress { get; set; }

        [StringLength(500)]
        public string? PostalAddress { get; set; }

        [StringLength(255)]
        public string? IncomeTaxNumber { get; set; }

        [StringLength(255)]
        public string? TaxResidencyStatus { get; set; }

        [StringLength(255)]
        public string? BankName { get; set; }

        [StringLength(255)]
        public string? AccountNumber { get; set; }

        [StringLength(255)]
        public string? BranchCode { get; set; }

        [StringLength(255)]
        public string? AccountType { get; set; }

        public string? EmploymentChecklist { get; set; }
        public string? Allergies { get; set; }
        public string? CurrentMedications { get; set; }

        [StringLength(255)]
        public string? BloodType { get; set; }

        public string? VaccinationRecords { get; set; }

        [StringLength(255)]
        public string? NationalId { get; set; }

        [StringLength(255)]
        public string? VisaNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Language { get; set; }

        [StringLength(3)]
        public string? PersonWithDisabilities { get; set; } // Yes / No

        [StringLength(500)]
        public string? CurrentAddress { get; set; }

        public string? EmergencyContactDetails { get; set; }

        [StringLength(255)]
        public string? EmploymentType { get; set; }

        public DateTime? DateOfEmployment { get; set; }

        public DateTime? StartProbationPeriod { get; set; }
        public DateTime? EndProbationPeriod { get; set; }

        public int? ReasonForEmployeeBecomingInactive { get; set; }

        public int? HierarchyLevel { get; set; }
        public int? Manager { get; set; }

        [StringLength(250)]
        public string? Phone { get; set; }

        public DateTime? WorkPermitExpiryDate { get; set; }

        public int? EmployeeDepartment { get; set; }
        public string? PermitLicense { get; set; }

        public int? ActiveStep { get; set; }

        public string? PreEmploymentCheck { get; set; }
        public string? PostEmploymentCheck { get; set; }

        public int? EmployeeDepartmentInfo { get; set; }

        public int? DdrmId { get; set; }
        public string? CompletedStep { get; set; }

        public int? Policy { get; set; }
        public int? Incident { get; set; }
        public int? NonConformance { get; set; }
        public int? Risk { get; set; }

        [StringLength(255)]
        public string? ClientInternalId { get; set; }

        public int? TeamId { get; set; }

        [StringLength(255)]
        public string? UnifiedUserUiqueId { get; set; }
    }
}
