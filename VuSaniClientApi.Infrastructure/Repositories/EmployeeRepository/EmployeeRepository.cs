using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Infrastructure.Helpers;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetEmployeesAsync(int page, int pageSize, bool all, string search, string filter)
        {
            try
            {
                // Base query with joins
                var query = from user in _context.Users
                            join org in _context.Organizations on user.MyOrganization equals org.Id into orgGroup
                            from org in orgGroup.DefaultIfEmpty()
                            join role in _context.Roles on user.RoleId equals role.Id into roleGroup
                            from role in roleGroup.DefaultIfEmpty()
                            join gender in _context.Genders on user.GenderId equals gender.Id into genderGroup
                            from gender in genderGroup.DefaultIfEmpty()
                            join empType in _context.EmployeeTypes on user.EmployeeTypeId equals empType.Id into empTypeGroup
                            from empType in empTypeGroup.DefaultIfEmpty()
                            join country in _context.Countries on user.CountryId equals country.Id into countryGroup
                            from country in countryGroup.DefaultIfEmpty()
                            join state in _context.States on user.StateId equals state.Id into stateGroup
                            from state in stateGroup.DefaultIfEmpty()
                            join city in _context.Cities on user.CityId equals city.Id into cityGroup
                            from city in cityGroup.DefaultIfEmpty()
                            join qual in _context.HighestQualifications on user.HighestQualificationId equals qual.Id into qualGroup
                            from qual in qualGroup.DefaultIfEmpty()
                            join dept in _context.Department on user.Department equals dept.Id into deptGroup
                            from dept in deptGroup.DefaultIfEmpty()
                            join createdUser in _context.Users on user.CreatedBy equals createdUser.Id into createdGroup
                            from createdUser in createdGroup.DefaultIfEmpty()
                            where user.Deleted == false
                            select new { user, org, role, gender, empType, country, state, city, qual, dept, createdUser };

                // Search filter
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(x =>
                        (x.user.Name != null && x.user.Name.Contains(search)) ||
                        (x.user.Surname != null && x.user.Surname.Contains(search)) ||
                        (x.user.Email != null && x.user.Email.Contains(search)) ||
                        (x.user.UniqueId != null && x.user.UniqueId.Contains(search)) ||
                        (x.user.Phone != null && x.user.Phone.Contains(search))
                    );
                }

                var total = await query.CountAsync();

                // Pagination
                if (!all)
                {
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);
                }

                var rawData = await query.ToListAsync();

                // Map to DTO
                var employees = rawData.Select(x => new EmployeeListDto
                {
                    Id = x.user.Id,
                    UniqueId = x.user.UniqueId,
                    Name = x.user.Name,
                    Surname = x.user.Surname,
                    Email = x.user.Email,
                    Phone = x.user.Phone,
                    Profile = x.user.Profile,
                    Gender = x.user.GenderId,
                    GenderName = x.gender?.Name,
                    IdNumber = x.user.IdNumber,
                    PassportNumber = x.user.PassportNumber,
                    DateOfBirth = x.user.DateOfBirth,
                    Age = x.user.Age,
                    MaritalStatus = x.user.MaritalStatus,
                    NationalId = x.user.NationalId,
                    MyOrganization = x.user.MyOrganization,
                    OrganizationName = x.org?.Name,
                    Department = x.user.Department,
                    DepartmentName = x.dept?.Name,
                    Role = x.user.RoleId,
                    RoleName = x.role?.Name,
                    RoleDescription = DecodeHelper.DecodeSingle(x.user.RoleDesc),
                    EmployeeType = x.user.EmployeeTypeId,
                    EmployeeTypeName = x.empType?.Name,
                    EmploymentStatus = x.user.EmploymentStatus,
                    DateOfEmployment = x.user.DateOfEmployment,
                    JoiningDate = x.user.JoiningDate,
                    EndDate = x.user.EndDate,
                    Country = x.user.CountryId,
                    CountryName = x.country?.Name,
                    State = x.user.StateId,
                    StateName = x.state?.Name,
                    City = x.user.CityId,
                    CityName = x.city?.Name,
                    CurrentAddress = x.user.CurrentAddress,
                    HighestQualification = x.user.HighestQualificationId,
                    HighestQualificationName = x.qual?.Name,
                    NameOfQualification = x.user.NameOfQualification,
                    Skills = SafeParseIds(x.user.Skills),
                    License = SafeParseIds(x.user.License),
                    ActiveStep = x.user.ActiveStep,
                    CompletedStep = SafeParseBoolArray(x.user.CompletedStep),
                    CreatedBy = x.user.CreatedBy,
                    CreatedByName = x.createdUser != null ? $"{x.createdUser.Name} {x.createdUser.Surname}" : null,
                    CreatedAt = x.user.CreatedAt,
                    Manager = x.user.Manager
                }).ToList();

                return new
                {
                    status = true,
                    data = employees,
                    total = total,
                    page = page,
                    pageSize = pageSize
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var rawData = await (from user in _context.Users
                                     join org in _context.Organizations on user.MyOrganization equals org.Id into orgGroup
                                     from org in orgGroup.DefaultIfEmpty()
                                     join role in _context.Roles on user.RoleId equals role.Id into roleGroup
                                     from role in roleGroup.DefaultIfEmpty()
                                     join gender in _context.Genders on user.GenderId equals gender.Id into genderGroup
                                     from gender in genderGroup.DefaultIfEmpty()
                                     join empType in _context.EmployeeTypes on user.EmployeeTypeId equals empType.Id into empTypeGroup
                                     from empType in empTypeGroup.DefaultIfEmpty()
                                     join country in _context.Countries on user.CountryId equals country.Id into countryGroup
                                     from country in countryGroup.DefaultIfEmpty()
                                     join state in _context.States on user.StateId equals state.Id into stateGroup
                                     from state in stateGroup.DefaultIfEmpty()
                                     join city in _context.Cities on user.CityId equals city.Id into cityGroup
                                     from city in cityGroup.DefaultIfEmpty()
                                     join qual in _context.HighestQualifications on user.HighestQualificationId equals qual.Id into qualGroup
                                     from qual in qualGroup.DefaultIfEmpty()
                                     join dept in _context.Department on user.Department equals dept.Id into deptGroup
                                     from dept in deptGroup.DefaultIfEmpty()
                                     join lang in _context.Languages on user.LanguageId equals lang.Id into langGroup
                                     from lang in langGroup.DefaultIfEmpty()
                                     join manager in _context.Users on user.Manager equals manager.Id into managerGroup
                                     from manager in managerGroup.DefaultIfEmpty()
                                     where user.Id == id && user.Deleted == false
                                     select new { user, org, role, gender, empType, country, state, city, qual, dept, lang, manager })
                                    .FirstOrDefaultAsync();

                if (rawData == null)
                {
                    return new { status = false, message = "Employee not found" };
                }

                var employee = new EmployeeListDto
                {
                    Id = rawData.user.Id,
                    UniqueId = rawData.user.UniqueId,
                    Name = rawData.user.Name,
                    Surname = rawData.user.Surname,
                    Email = rawData.user.Email,
                    Phone = rawData.user.Phone,
                    Profile = rawData.user.Profile,
                    Gender = rawData.user.GenderId,
                    GenderName = rawData.gender?.Name,
                    IdNumber = rawData.user.IdNumber,
                    PassportNumber = rawData.user.PassportNumber,
                    DateOfBirth = rawData.user.DateOfBirth,
                    Age = rawData.user.Age,
                    MaritalStatus = rawData.user.MaritalStatus,
                    NationalId = rawData.user.NationalId,
                    VisaNumber = rawData.user.VisaNumber,
                    WorkPermitExpiryDate = rawData.user.WorkPermitExpiryDate,
                    MyOrganization = rawData.user.MyOrganization,
                    OrganizationName = rawData.org?.Name,
                    Department = rawData.user.Department,
                    DepartmentName = rawData.dept?.Name,
                    Role = rawData.user.RoleId,
                    RoleName = rawData.role?.Name,
                    RoleDescription = DecodeHelper.DecodeSingle(rawData.user.RoleDesc),
                    EmployeeType = rawData.user.EmployeeTypeId,
                    EmployeeTypeName = rawData.empType?.Name,
                    EmploymentStatus = rawData.user.EmploymentStatus,
                    DateOfEmployment = rawData.user.DateOfEmployment,
                    JoiningDate = rawData.user.JoiningDate,
                    EndDate = rawData.user.EndDate,
                    StartProbationPeriod = rawData.user.StartProbationPeriod,
                    EndProbationPeriod = rawData.user.EndProbationPeriod,
                    ProbationPeriod = rawData.user.ProbationPeriod,
                    Country = rawData.user.CountryId,
                    CountryName = rawData.country?.Name,
                    State = rawData.user.StateId,
                    StateName = rawData.state?.Name,
                    City = rawData.user.CityId,
                    CityName = rawData.city?.Name,
                    CurrentAddress = rawData.user.CurrentAddress,
                    ResidentialAddress = rawData.user.ResidentialAddress,
                    PostalAddress = rawData.user.PostalAddress,
                    HighestQualification = rawData.user.HighestQualificationId,
                    HighestQualificationName = rawData.qual?.Name,
                    NameOfQualification = rawData.user.NameOfQualification,
                    Skills = SafeParseIds(rawData.user.Skills),
                    License = SafeParseIds(rawData.user.License),
                    Race = rawData.user.RaceId?.ToString(),
                    PersonWithDisabilities = rawData.user.PersonWithDisabilities,
                    Disability = rawData.user.Disability,
                    Language = rawData.user.LanguageId,
                    LanguageName = rawData.lang?.Name,
                    BloodType = rawData.user.BloodType,
                    IncomeTaxNumber = rawData.user.IncomeTaxNumber,
                    BankName = rawData.user.BankName,
                    AccountNumber = rawData.user.AccountNumber,
                    HierarchyLevel = rawData.user.HierarchyLevel,
                    Manager = rawData.user.Manager,
                    ManagerName = rawData.manager != null ? $"{rawData.manager.Name} {rawData.manager.Surname}" : null,
                    Accountability = rawData.user.Accountability,
                    Level = rawData.user.Level,
                    ActiveStep = rawData.user.ActiveStep,
                    CompletedStep = SafeParseBoolArray(rawData.user.CompletedStep),
                    CreatedBy = rawData.user.CreatedBy,
                    CreatedAt = rawData.user.CreatedAt,
                    UpdatedBy = rawData.user.UpdatedBy,
                    UpdatedAt = rawData.user.UpdatedAt
                };

                return new { status = true, data = employee };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> CreateEmployeeAsync(CreateUpdateEmployeeRequest request, int userId)
        {
            try
            {
                // Check if email already exists
                if (!string.IsNullOrEmpty(request.Email))
                {
                    var existingUser = await _context.Users
                        .AnyAsync(u => u.Email == request.Email && u.Deleted == false);
                    
                    if (existingUser)
                    {
                        return new { status = false, message = "Employee with this email already exists" };
                    }
                }

                // Calculate age from ID number if provided
                int? age = null;
                if (!string.IsNullOrEmpty(request.IdNumber))
                {
                    age = CalculateAgeFromIdNumber(request.IdNumber);
                }

                // Get organization from department if department is provided
                int? organizationId = request.Organization;
                if (request.Department.HasValue || request.EmployeeDepartment.HasValue)
                {
                    var deptId = request.Department ?? request.EmployeeDepartment;
                    var dept = await GeneralHelper.GetOrganizationAccordingToDepartmentAsync(_context, deptId.Value);
                    if (dept.Any())
                    {
                        organizationId = dept[0].OrganizationId;
                    }
                }

                // Generate unique ID
                var uniqueId = await GeneralHelper.UniqueIdGeneratorAsync(
                    _context,
                    organizationId,
                    null,
                    "",
                    "users",
                    "unique_id"
                );

                // Create new employee
                var newEmployee = new User
                {
                    UniqueId = uniqueId,
                    UniqueIdStatus = "automatic",
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email,
                    Phone = request.Phone,
                    Profile = request.Profile ?? "profile/default_profile.png",
                    GenderId = request.Gender,
                    IdNumber = request.IdNumber,
                    PassportNumber = request.PassportNumber,
                    VisaNumber = request.VisaNumber,
                    DateOfBirth = request.DateOfBirth,
                    Age = age ?? request.Age,
                    MaritalStatus = request.MaritalStatus,
                    NationalId = request.NationalId,
                    WorkPermitExpiryDate = request.WorkPermitExpiryDate,
                    LanguageId = request.Language,
                    RaceId = string.IsNullOrEmpty(request.Race) ? null : int.TryParse(request.Race, out int raceId) ? raceId : null,
                    PersonWithDisabilities = request.PersonWithDisabilities,
                    Disability = request.Disability,
                    CountryId = request.Country,
                    StateId = request.State,
                    CityId = request.City,
                    ResidentialAddress = request.ResidentialAddress,
                    PostalAddress = request.PostalAddress,
                    CurrentAddress = request.CurrentAddress,
                    HighestQualificationId = request.HighestQualification,
                    NameOfQualification = request.NameOfQualification,
                    Skills = request.Skills,
                    License = request.License,
                    MyOrganization = organizationId,
                    OrganizationId = organizationId,
                    Department = request.Department ?? request.EmployeeDepartment,
                    RoleId = request.Role,
                    RoleDesc = GeneralHelper.EncodeSingle(request.RoleDescription),
                    EmployeeTypeId = request.EmployeeType,
                    EmploymentStatus = request.EmploymentStatus,
                    DateOfEmployment = request.DateOfEmployment,
                    JoiningDate = request.JoiningDate,
                    EndDate = request.EndDate,
                    StartProbationPeriod = request.StartProbationPeriod,
                    EndProbationPeriod = request.EndProbationPeriod,
                    ProbationPeriod = request.ProbationPeriod,
                    HierarchyLevel = request.HierarchyLevel,
                    Manager = request.Manager,
                    IncomeTaxNumber = request.IncomeTaxNumber,
                    TaxResidencyStatus = request.TaxResidencyStatus,
                    BankName = request.BankName,
                    AccountNumber = request.AccountNumber,
                    BranchCode = request.BranchCode,
                    AccountType = request.AccountType,
                    BloodType = request.BloodType,
                    Allergies = request.Allergies,
                    CurrentMedications = request.CurrentMedications,
                    VaccinationRecords = request.VaccinationRecords,
                    PreEmploymentCheck = request.PreEmploymentCheck,
                    PostEmploymentCheck = request.PostEmploymentCheck,
                    EmploymentChecklist = request.EmploymentChecklist,
                    ActiveStep = request.ActiveStep,
                    CompletedStep = request.CompletedStep,
                    Accountability = request.Accountability,
                    Level = request.Level,
                    DdrmId = request.DdrmId,
                    PermitLicense = request.PermitLicense,
                    EmployeeDepartmentInfo = request.EmployeeDepartmentInfo,
                    CreatedBy = userId,
                    CreatedAt = DateTime.UtcNow,
                    Deleted = false
                };

                _context.Users.Add(newEmployee);
                await _context.SaveChangesAsync();

                // Copy permissions from role if role is assigned
                if (request.Role.HasValue)
                {
                    var rolePermissions = await _context.Roles
                        .Where(r => r.Id == request.Role.Value)
                        .Select(r => r.Permission)
                        .FirstOrDefaultAsync();

                    if (!string.IsNullOrEmpty(rolePermissions))
                    {
                        newEmployee.Permission = rolePermissions;
                        await _context.SaveChangesAsync();
                    }
                }

                // Insert activity log
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "create", "Employee", newEmployee.Id);

                return new { status = true, message = "Record created successfully", id = newEmployee.Id };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> UpdateEmployeeAsync(CreateUpdateEmployeeRequest request, int userId)
        {
            try
            {
                if (!request.Id.HasValue)
                {
                    return new { status = false, message = "Employee ID is required for update" };
                }

                var employee = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id.Value && u.Deleted == false);
                if (employee == null)
                {
                    return new { status = false, message = "Employee not found" };
                }

                // Check if email is being changed and if it already exists
                if (!string.IsNullOrEmpty(request.Email) && request.Email != employee.Email)
                {
                    var emailExists = await _context.Users
                        .AnyAsync(u => u.Email == request.Email && u.Deleted == false && u.Id != request.Id.Value);
                    
                    if (emailExists)
                    {
                        return new { status = false, message = "Employee with this email already exists" };
                    }
                }

                // Calculate age from ID number if provided
                if (!string.IsNullOrEmpty(request.IdNumber))
                {
                    request.Age = CalculateAgeFromIdNumber(request.IdNumber);
                }

                // Get organization from department if department is provided
                int? organizationId = request.Organization ?? employee.MyOrganization;
                if (request.Department.HasValue || request.EmployeeDepartment.HasValue)
                {
                    var deptId = request.Department ?? request.EmployeeDepartment;
                    var dept = await GeneralHelper.GetOrganizationAccordingToDepartmentAsync(_context, deptId.Value);
                    if (dept.Any())
                    {
                        organizationId = dept[0].OrganizationId;
                    }
                }

                // Update fields
                employee.Name = request.Name ?? employee.Name;
                employee.Surname = request.Surname ?? employee.Surname;
                employee.Email = request.Email ?? employee.Email;
                employee.Phone = request.Phone ?? employee.Phone;
                employee.GenderId = request.Gender ?? employee.GenderId;
                employee.IdNumber = request.IdNumber ?? employee.IdNumber;
                employee.PassportNumber = request.PassportNumber ?? employee.PassportNumber;
                employee.VisaNumber = request.VisaNumber ?? employee.VisaNumber;
                employee.DateOfBirth = request.DateOfBirth ?? employee.DateOfBirth;
                employee.Age = request.Age ?? employee.Age;
                employee.MaritalStatus = request.MaritalStatus ?? employee.MaritalStatus;
                employee.NationalId = request.NationalId ?? employee.NationalId;
                employee.WorkPermitExpiryDate = request.WorkPermitExpiryDate ?? employee.WorkPermitExpiryDate;
                employee.LanguageId = request.Language ?? employee.LanguageId;
                employee.RaceId = string.IsNullOrEmpty(request.Race) ? employee.RaceId : int.TryParse(request.Race, out int raceId) ? raceId : employee.RaceId;
                employee.PersonWithDisabilities = request.PersonWithDisabilities ?? employee.PersonWithDisabilities;
                employee.Disability = request.Disability ?? employee.Disability;
                employee.CountryId = request.Country ?? employee.CountryId;
                employee.StateId = request.State ?? employee.StateId;
                employee.CityId = request.City ?? employee.CityId;
                employee.ResidentialAddress = request.ResidentialAddress ?? employee.ResidentialAddress;
                employee.PostalAddress = request.PostalAddress ?? employee.PostalAddress;
                employee.CurrentAddress = request.CurrentAddress ?? employee.CurrentAddress;
                employee.HighestQualificationId = request.HighestQualification ?? employee.HighestQualificationId;
                employee.NameOfQualification = request.NameOfQualification ?? employee.NameOfQualification;
                employee.Skills = request.Skills ?? employee.Skills;
                employee.License = request.License ?? employee.License;
                employee.MyOrganization = organizationId;
                employee.OrganizationId = organizationId;
                employee.Department = request.Department ?? request.EmployeeDepartment ?? employee.Department;
                employee.RoleId = request.Role ?? employee.RoleId;
                employee.RoleDesc = !string.IsNullOrEmpty(request.RoleDescription) 
                    ? GeneralHelper.EncodeSingle(request.RoleDescription) 
                    : employee.RoleDesc;
                employee.EmployeeTypeId = request.EmployeeType ?? employee.EmployeeTypeId;
                employee.EmploymentStatus = request.EmploymentStatus ?? employee.EmploymentStatus;
                employee.DateOfEmployment = request.DateOfEmployment ?? employee.DateOfEmployment;
                employee.JoiningDate = request.JoiningDate ?? employee.JoiningDate;
                employee.EndDate = request.EndDate ?? employee.EndDate;
                employee.StartProbationPeriod = request.StartProbationPeriod ?? employee.StartProbationPeriod;
                employee.EndProbationPeriod = request.EndProbationPeriod ?? employee.EndProbationPeriod;
                employee.ProbationPeriod = request.ProbationPeriod ?? employee.ProbationPeriod;
                employee.HierarchyLevel = request.HierarchyLevel ?? employee.HierarchyLevel;
                employee.Manager = request.Manager ?? employee.Manager;
                employee.IncomeTaxNumber = request.IncomeTaxNumber ?? employee.IncomeTaxNumber;
                employee.TaxResidencyStatus = request.TaxResidencyStatus ?? employee.TaxResidencyStatus;
                employee.BankName = request.BankName ?? employee.BankName;
                employee.AccountNumber = request.AccountNumber ?? employee.AccountNumber;
                employee.BranchCode = request.BranchCode ?? employee.BranchCode;
                employee.AccountType = request.AccountType ?? employee.AccountType;
                employee.BloodType = request.BloodType ?? employee.BloodType;
                employee.Allergies = request.Allergies ?? employee.Allergies;
                employee.CurrentMedications = request.CurrentMedications ?? employee.CurrentMedications;
                employee.VaccinationRecords = request.VaccinationRecords ?? employee.VaccinationRecords;
                employee.PreEmploymentCheck = request.PreEmploymentCheck ?? employee.PreEmploymentCheck;
                employee.PostEmploymentCheck = request.PostEmploymentCheck ?? employee.PostEmploymentCheck;
                employee.EmploymentChecklist = request.EmploymentChecklist ?? employee.EmploymentChecklist;
                employee.ActiveStep = request.ActiveStep ?? employee.ActiveStep;
                employee.CompletedStep = request.CompletedStep ?? employee.CompletedStep;
                employee.Accountability = request.Accountability ?? employee.Accountability;
                employee.Level = request.Level ?? employee.Level;
                employee.DdrmId = request.DdrmId ?? employee.DdrmId;
                employee.Profile = request.Profile ?? employee.Profile;
                employee.PermitLicense = request.PermitLicense ?? employee.PermitLicense;
                employee.EmployeeDepartmentInfo = request.EmployeeDepartmentInfo ?? employee.EmployeeDepartmentInfo;
                employee.UpdatedBy = userId;
                employee.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // Update permissions from role if role is changed
                if (request.Role.HasValue && employee.Email != "superadmin@sartiaglobal.com")
                {
                    var rolePermissions = await _context.Roles
                        .Where(r => r.Id == request.Role.Value)
                        .Select(r => r.Permission)
                        .FirstOrDefaultAsync();

                    if (!string.IsNullOrEmpty(rolePermissions))
                    {
                        employee.Permission = rolePermissions;
                        await _context.SaveChangesAsync();
                    }
                }

                // Insert activity log
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "update", "Employee", employee.Id);

                return new { status = true, message = "Employee details updated successfully", id = employee.Id };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> DeleteEmployeeAsync(int id, int userId)
        {
            try
            {
                var employee = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.Deleted == false);
                
                if (employee == null)
                {
                    return new { status = false, message = "User Not Found" };
                }

                // Check if user is super admin
                if (employee.IsSuperAdmin == 1)
                {
                    return new { status = false, message = "You Can't Delete Super Admin" };
                }

                // Soft delete
                employee.Deleted = true;
                await _context.SaveChangesAsync();

                // Insert activity log
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "delete", "Users", id);

                return new { status = true, message = "Record deleted successfully" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int? CalculateAgeFromIdNumber(string idNumber)
        {
            // South African ID format: YYMMDD...
            if (string.IsNullOrEmpty(idNumber) || idNumber.Length < 6)
                return null;

            try
            {
                var yearPart = idNumber.Substring(0, 2);
                var monthPart = idNumber.Substring(2, 2);
                var dayPart = idNumber.Substring(4, 2);

                int year = int.Parse(yearPart);
                int month = int.Parse(monthPart);
                int day = int.Parse(dayPart);

                // Determine century (assume < 30 is 2000s, >= 30 is 1900s)
                year += year < 30 ? 2000 : 1900;

                var birthDate = new DateTime(year, month, day);
                var age = DateTime.Now.Year - birthDate.Year;
                if (DateTime.Now < birthDate.AddYears(age))
                    age--;

                return age;
            }
            catch
            {
                return null;
            }
        }

        private static List<int> SafeParseIds(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<int>();

            value = value.Trim();

            // Try JSON array format
            if (value.StartsWith("["))
            {
                try
                {
                    return JsonSerializer.Deserialize<List<int>>(value) ?? new List<int>();
                }
                catch
                {
                    return new List<int>();
                }
            }

            // Try comma-separated format
            try
            {
                return value.Split(',')
                    .Select(s => s.Trim())
                    .Where(s => int.TryParse(s, out _))
                    .Select(int.Parse)
                    .ToList();
            }
            catch
            {
                return new List<int>();
            }
        }

        private static List<bool> SafeParseBoolArray(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<bool>();

            try
            {
                return JsonSerializer.Deserialize<List<bool>>(value) ?? new List<bool>();
            }
            catch
            {
                return new List<bool>();
            }
        }
    }
}

