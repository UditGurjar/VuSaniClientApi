using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public async Task<object> GetEmployeesAsync(int page, int pageSize, bool all, string search, string filter, bool authOnly = false)
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
                            join race in _context.Races on user.RaceId equals race.Id into raceGroup
                            from race in raceGroup.DefaultIfEmpty()
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
                            join reasonForInactive in _context.ReasonForInactives on user.ReasonForEmployeeBecomingInactive equals reasonForInactive.Id into reasonGroup
                            from reasonForInactive in reasonGroup.DefaultIfEmpty()
                            join roleHierarchy in _context.RoleHierarchies on role.Hierarchy equals roleHierarchy.Id into hierarchyGroup
                            from roleHierarchy in hierarchyGroup.DefaultIfEmpty()
                            where user.Deleted == false
                                && (!authOnly || user.Password != null)
                            select new { user, org, role, race, gender, empType, country, state, city, qual, dept, createdUser, reasonForInactive, roleHierarchy };

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

                // Filter by organization and/or department (from JSON filter)
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    try
                    {
                        var filterObj = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(filter);
                        if (filterObj != null)
                        {
                            if ((filterObj.TryGetValue("my_organization", out var orgVal) || filterObj.TryGetValue("myOrganization", out orgVal)) && TryGetIntFromElement(orgVal, out var orgId) && orgId > 0)
                                query = query.Where(x => x.user.MyOrganization == orgId);
                            if (filterObj.TryGetValue("department", out var deptVal) && TryGetIntFromElement(deptVal, out var deptId) && deptId > 0)
                                query = query.Where(x => x.user.Department == deptId);
                        }
                    }
                    catch { /* ignore parse errors */ }
                }

                var total = await query.CountAsync();

                // Pagination
                if (!all)
                {
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);
                }

                var rawData = await query.ToListAsync();

                // Hierarchy is derived from Role (Role.Hierarchy -> RoleHierarchy) - display only
                var hierarchyIds = rawData.Where(x => x.role != null && x.role.Hierarchy.HasValue).Select(x => x.role!.Hierarchy!.Value).Distinct().ToList();
                var hierarchyNames = new Dictionary<int, string>();
                if (hierarchyIds.Count > 0)
                {
                    var rhList = await _context.RoleHierarchies.AsNoTracking()
                        .Where(rh => hierarchyIds.Contains(rh.Id))
                        .Select(rh => new { rh.Id, Name = rh.Name ?? rh.Level })
                        .ToListAsync();
                    foreach (var rh in rhList)
                        hierarchyNames[rh.Id] = rh.Name ?? string.Empty;
                }

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
                    BusinessAddress = x.org?.BusinessAddress,
                    Department = x.user.Department,
                    DepartmentName = x.dept?.Name,
                    Role = x.user.RoleId,
                    RoleName = x.role?.Name,
                    RoleDescription = x.role != null
    ? DecodeHelper.DecodeSingle(x.role.Description)
    : null,
                    EmployeeType = x.user.EmployeeTypeId,
                    EmployeeTypeName = x.empType?.Name,
                    EmploymentStatus = x.user.EmploymentStatus,
                    DateOfEmployment = x.user.DateOfEmployment,
                    DateOfTermination = x.user.DateOfTermination,
                    JoiningDate = x.user.JoiningDate,
                    EndDate = x.user.EndDate,
                    Country = x.user.CountryId,
                    CountryName = x.country?.Name,
                    State = x.user.StateId,
                    StateName = x.state?.Name,
                    City = x.user.CityId,
                    CityName = x.city?.Name,
                    Race = x.user.RaceId,
                    RaceName = x.race?.Name,
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
                    Manager = x.user.Manager,
                    HierarchyLevel = x.role?.Hierarchy,
                    HierarchyLevelName = x.roleHierarchy?.Name ?? (x.role?.Hierarchy.HasValue == true && hierarchyNames.TryGetValue(x.role.Hierarchy!.Value, out var hn) ? hn : null),
                    ReasonForEmployeeBecomingInactive = x.user.ReasonForEmployeeBecomingInactive,
                    ReasonForEmployeeBecomingInactiveName = x.reasonForInactive?.Name
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
                                     join race in _context.Races on user.RaceId equals race.Id into raceGroup
                                     from race in raceGroup.DefaultIfEmpty()
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
                                     join createdUser in _context.Users on user.CreatedBy equals createdUser.Id into createdGroup
                                     from createdUser in createdGroup.DefaultIfEmpty()
                                     join updatedUser in _context.Users on user.UpdatedBy equals updatedUser.Id into updatedGroup
                                     from updatedUser in updatedGroup.DefaultIfEmpty()
                                     join reasonForInactive in _context.ReasonForInactives on user.ReasonForEmployeeBecomingInactive equals reasonForInactive.Id into reasonGroup
                                     from reasonForInactive in reasonGroup.DefaultIfEmpty()
                                     join roleHierarchy in _context.RoleHierarchies on role.Hierarchy equals roleHierarchy.Id into hierarchyGroup
                                     from roleHierarchy in hierarchyGroup.DefaultIfEmpty()
                                     where user.Id == id && user.Deleted == false
                                     select new { user, org, role, race, gender, empType, country, state, city, qual, dept, lang, manager, createdUser, updatedUser, reasonForInactive, roleHierarchy })
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
                    BusinessAddress = rawData.org?.BusinessAddress,
                    Department = rawData.user.Department,
                    DepartmentName = rawData.dept?.Name,
                    Role = rawData.user.RoleId,
                    RoleName = rawData.role?.Name,
                    RoleDescription = DecodeHelper.DecodeSingle(rawData.user.RoleDesc),
                    EmployeeType = rawData.user.EmployeeTypeId,
                    EmployeeTypeName = rawData.empType?.Name,
                    EmploymentStatus = rawData.user.EmploymentStatus,
                    DateOfEmployment = rawData.user.DateOfEmployment,
                    DateOfTermination = rawData.user.DateOfTermination,
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
                    Race = rawData.user.RaceId,
                    RaceName = rawData.race?.Name,
                    PersonWithDisabilities = rawData.user.PersonWithDisabilities,
                    Disability = rawData.user.Disability,
                    Language = rawData.user.LanguageId,
                    LanguageName = rawData.lang?.Name,
                    BloodType = rawData.user.BloodType,
                    IncomeTaxNumber = rawData.user.IncomeTaxNumber,
                    BankName = rawData.user.BankName,
                    AccountNumber = rawData.user.AccountNumber,
                    HierarchyLevel = rawData.role?.Hierarchy,
                    HierarchyLevelName = rawData.roleHierarchy?.Name,
                    Manager = rawData.user.Manager,
                    ManagerName = rawData.manager != null ? $"{rawData.manager.Name} {rawData.manager.Surname}" : null,
                    Accountability = rawData.user.Accountability,
                    Level = rawData.user.Level,
                    ReasonForEmployeeBecomingInactive = rawData.user.ReasonForEmployeeBecomingInactive,
                    ReasonForEmployeeBecomingInactiveName = rawData.reasonForInactive?.Name,
                    ActiveStep = rawData.user.ActiveStep,
                    CompletedStep = SafeParseBoolArray(rawData.user.CompletedStep),
                    CreatedBy = rawData.user.CreatedBy,
                    CreatedByName = rawData.createdUser != null ? $"{rawData.createdUser.Name} {rawData.createdUser.Surname}" : null,
                    CreatedAt = rawData.user.CreatedAt,
                    UpdatedBy = rawData.user.UpdatedBy,
                    UpdatedByName = rawData.updatedUser != null ? $"{rawData.updatedUser.Name} {rawData.updatedUser.Surname}" : null,
                    UpdatedAt = rawData.user.UpdatedAt
                };

                // Hierarchy is from Role (display only) - resolve name if join missed
                if (employee.HierarchyLevel.HasValue && string.IsNullOrEmpty(employee.HierarchyLevelName))
                {
                    var rh = await _context.RoleHierarchies.AsNoTracking()
                        .Where(r => r.Id == employee.HierarchyLevel!.Value)
                        .Select(r => r.Name ?? r.Level)
                        .FirstOrDefaultAsync();
                    if (rh != null)
                        employee.HierarchyLevelName = rh;
                }

                // Load emergency contact details from NextOfKin table
                var nextOfKins = await _context.NextOfKins
                    .Where(n => n.UserId == id)
                    .Include(n => n.RelationShip)
                    .ToListAsync();
                employee.EmergencyContactDetails = nextOfKins.Select(n => new EmergencyContactItemDto
                {
                    ContactName = n.Name,
                    Employee = n.RelationshipId,
                    ContactNumber = n.ContactNumber,
                    RelationName = n.RelationShip?.Name
                }).ToList();

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

                // If Date of Termination is in the past, set Employment Status to Inactive
                var employmentStatus = request.EmploymentStatus;
                if (request.DateOfTermination.HasValue && request.DateOfTermination.Value.Date < DateTime.UtcNow.Date)
                    employmentStatus = "Inactive";

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
                    // Step 0: Personal Information
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email,
                    Phone = request.Phone,
                    Profile = request.ProfilePath ?? "profile/default_profile.png",
                    GenderId = request.Gender,
                    IdNumber = request.IdNumber,
                    PassportNumber = request.PassportNumber,
                    VisaNumber = request.VisaNumber,
                    DateOfBirth = request.DateOfBirth,
                    Age = age ?? request.Age,
                    MaritalStatus = request.MaritalStatus,
                    NationalId = request.NationalId,
                    LanguageId = request.Language,
                    RaceId = string.IsNullOrEmpty(request.Race) ? null : int.TryParse(request.Race, out int raceId) ? raceId : null,
                    PersonWithDisabilities = request.PersonWithDisabilities,
                    Disability = request.Disability,
                    CountryId = request.Country,
                    StateId = request.State,
                    CityId = request.City,
                    ResidentialAddress = request.ResidentialAddress,
                    PostalAddress = request.PostalAddress,
                    HighestQualificationId = request.HighestQualification,
                    NameOfQualification = request.NameOfQualification,
                    MyOrganization = organizationId,
                    OrganizationId = organizationId,
                    // Step 1: Employment Information
                    Department = request.Department ?? request.EmployeeDepartment,
                    EmployeeDepartment = request.EmployeeDepartment,
                    EmployeeDepartmentInfo = request.EmployeeDepartmentInfo,
                    RoleId = request.Role,
                    RoleDesc = GeneralHelper.EncodeSingle(request.RoleDescription),
                    EmployeeTypeId = request.EmployeeType,
                    EmploymentStatus = employmentStatus ?? request.EmploymentStatus,
                    DateOfEmployment = request.DateOfEmployment,
                    StartProbationPeriod = request.StartProbationPeriod,
                    EndProbationPeriod = request.EndProbationPeriod,
                    DateOfTermination = request.DateOfTermination,
                    ReasonForEmployeeBecomingInactive = request.ReasonForEmployeeBecomingInactive,
                    // Multi-step tracking
                    ActiveStep = request.ActiveStep,
                    CompletedStep = request.CompletedStep,
                    CreatedBy = userId,
                    CreatedAt = DateTime.UtcNow,
                    Deleted = false
                };

                _context.Users.Add(newEmployee);
                await _context.SaveChangesAsync();

                // Save emergency contacts to NextOfKin table
                if (!string.IsNullOrWhiteSpace(request.EmergencyContactDetails))
                {
                    var emergencyContacts = ParseEmergencyContactDetails(request.EmergencyContactDetails);
                    foreach (var ec in emergencyContacts)
                    {
                        _context.NextOfKins.Add(new NextOfKin
                        {
                            UserId = newEmployee.Id,
                            Name = ec.ContactName ?? string.Empty,
                            RelationshipId = ec.Employee,
                            ContactNumber = ec.ContactNumber ?? string.Empty
                        });
                    }
                    await _context.SaveChangesAsync();
                }

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
                //await GeneralHelper.InsertActivityLogAsync(_context, userId, "create", "Employee", newEmployee.Id);

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

                // Update fields - Step 0: Personal Information
                if (request.Name != null) employee.Name = request.Name;
                if (request.Surname != null) employee.Surname = request.Surname;
                if (request.Email != null) employee.Email = request.Email;
                if (request.Phone != null) employee.Phone = request.Phone;
                if (request.Gender.HasValue) employee.GenderId = request.Gender;
                if (request.IdNumber != null) employee.IdNumber = request.IdNumber;
                if (request.PassportNumber != null) employee.PassportNumber = request.PassportNumber;
                if (request.VisaNumber != null) employee.VisaNumber = request.VisaNumber;
                if (request.DateOfBirth.HasValue) employee.DateOfBirth = request.DateOfBirth;
                if (request.Age.HasValue) employee.Age = request.Age;
                if (request.MaritalStatus != null) employee.MaritalStatus = request.MaritalStatus;
                if (request.NationalId != null) employee.NationalId = request.NationalId;
                if (request.Language.HasValue) employee.LanguageId = request.Language;
                if (!string.IsNullOrEmpty(request.Race))
                {
                    if (int.TryParse(request.Race, out int raceId))
                        employee.RaceId = raceId;
                }
                if (request.PersonWithDisabilities != null) employee.PersonWithDisabilities = request.PersonWithDisabilities;
                if (request.Disability != null) employee.Disability = request.Disability;
                if (request.Country.HasValue) employee.CountryId = request.Country;
                if (request.State.HasValue) employee.StateId = request.State;
                if (request.City.HasValue) employee.CityId = request.City;
                if (request.ResidentialAddress != null) employee.ResidentialAddress = request.ResidentialAddress;
                if (request.PostalAddress != null) employee.PostalAddress = request.PostalAddress;
                if (request.HighestQualification.HasValue) employee.HighestQualificationId = request.HighestQualification;
                if (request.NameOfQualification != null) employee.NameOfQualification = request.NameOfQualification;
                if (!string.IsNullOrEmpty(request.ProfilePath)) employee.Profile = request.ProfilePath;
                
                // Update organization if provided
                if (organizationId.HasValue)
                {
                    employee.MyOrganization = organizationId.Value;
                    employee.OrganizationId = organizationId.Value;
                }
                
                // Update fields - Step 1: Employment Information
                if (request.Department.HasValue || request.EmployeeDepartment.HasValue)
                {
                    employee.Department = request.Department ?? request.EmployeeDepartment ?? employee.Department;
                    employee.EmployeeDepartment = request.EmployeeDepartment ?? employee.EmployeeDepartment;
                }
                if (request.EmployeeDepartmentInfo.HasValue) employee.EmployeeDepartmentInfo = request.EmployeeDepartmentInfo;
                if (request.Role.HasValue) employee.RoleId = request.Role;
                if (!string.IsNullOrEmpty(request.RoleDescription))
                    employee.RoleDesc = GeneralHelper.EncodeSingle(request.RoleDescription);
                if (request.EmployeeType.HasValue) employee.EmployeeTypeId = request.EmployeeType;
                if (request.EmploymentStatus != null) employee.EmploymentStatus = request.EmploymentStatus;
                if (request.DateOfEmployment.HasValue) employee.DateOfEmployment = request.DateOfEmployment;
                if (request.StartProbationPeriod.HasValue) employee.StartProbationPeriod = request.StartProbationPeriod;
                if (request.EndProbationPeriod.HasValue) employee.EndProbationPeriod = request.EndProbationPeriod;
                if (request.DateOfTermination.HasValue)
                {
                    employee.DateOfTermination = request.DateOfTermination;
                    if (request.DateOfTermination.Value.Date < DateTime.UtcNow.Date)
                        employee.EmploymentStatus = "Inactive";
                }
                if (request.ReasonForEmployeeBecomingInactive.HasValue) employee.ReasonForEmployeeBecomingInactive = request.ReasonForEmployeeBecomingInactive;
                
                // Multi-step tracking
                if (request.ActiveStep.HasValue) employee.ActiveStep = request.ActiveStep;
                if (request.CompletedStep != null) employee.CompletedStep = request.CompletedStep;
                
                employee.UpdatedBy = userId;
                employee.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // Sync emergency contacts (NextOfKin): remove existing, add from request
                var existingNextOfKins = await _context.NextOfKins.Where(n => n.UserId == request.Id).ToListAsync();
                _context.NextOfKins.RemoveRange(existingNextOfKins);
                if (!string.IsNullOrWhiteSpace(request.EmergencyContactDetails))
                {
                    var emergencyContacts = ParseEmergencyContactDetails(request.EmergencyContactDetails);
                    foreach (var ec in emergencyContacts)
                    {
                        _context.NextOfKins.Add(new NextOfKin
                        {
                            UserId = request.Id.Value,
                            Name = ec.ContactName ?? string.Empty,
                            RelationshipId = ec.Employee,
                            ContactNumber = ec.ContactNumber ?? string.Empty
                        });
                    }
                }
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

        public async Task<DeleteEmployeeResponse> DeleteEmployeeAsync(int id, int userId)
        {
            try
            {
                var employee = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.Deleted == false);

                if (employee == null)
                {
                    return new DeleteEmployeeResponse { Status = false, Message = "User Not Found" };
                }

                // Check if user is super admin ( is_super_admin == 1)
                if (employee.IsSuperAdmin == 1)
                {
                    return new DeleteEmployeeResponse { Status = false, Message = "You Can't Delete Super Admin" };
                }

                // Soft delete 
                employee.Deleted = true;
                await _context.SaveChangesAsync();

                // Insert activity log (insertActivityLog)
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "delete", "Users", id);

                return new DeleteEmployeeResponse { Status = true, Message = "Record deleted successfully" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(bool Status, string Message)> UpdateCredentialAsync(int userId, string? password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId && u.Deleted == false);
                if (user == null)
                    return (false, "User not found");

                if (string.IsNullOrWhiteSpace(password))
                {
                    user.Password = null;
                    await _context.SaveChangesAsync();
                    return (true, "Access removed successfully");
                }

                user.Password = PasswordHelper.HashPassword(password, "SHA1", null!);
                await _context.SaveChangesAsync();
                return (true, "Credential updated successfully");
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

        private static List<EmergencyContactInput> ParseEmergencyContactDetails(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return new List<EmergencyContactInput>();

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var list = JsonSerializer.Deserialize<List<EmergencyContactInput>>(json, options);
                return list ?? new List<EmergencyContactInput>();
            }
            catch
            {
                return new List<EmergencyContactInput>();
            }
        }

        private static bool TryGetIntFromElement(JsonElement element, out int value)
        {
            value = 0;
            if (element.ValueKind == JsonValueKind.Number && element.TryGetInt32(out value))
                return true;
            if (element.ValueKind == JsonValueKind.String)
            {
                var s = element.GetString();
                return int.TryParse(s, out value);
            }
            return false;
        }

        private class EmergencyContactInput
        {
            [JsonPropertyName("contact_name")]
            public string? ContactName { get; set; }
            [JsonPropertyName("employee")]
            public int? Employee { get; set; }
            [JsonPropertyName("contact_number")]
            public string? ContactNumber { get; set; }
        }
    }
}

