using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.LoginRepository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {_context = context;

        }
        public async Task<User?> GetByEmailOrUniqueId(string field)
        {
            try
            {
                return await _context.Users
                    .FirstOrDefaultAsync(x => (x.Deleted == false || x.Deleted == null) &&
                        (x.Email == field || x.UniqueId == field));
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public async Task<UserDetailsDto?> GetUserDetails(int id)
        {
            try
            {
                var user = await _context.Users
          .Include(x => x.City)
          .Include(x => x.State)
          .Include(x => x.Country)
          .Include(x => x.Role)
          .Include(x => x.Organization)
          .Where(x => x.Id == id && (x.Deleted == false || x.Deleted == null))
        .Select(x => new UserDetailsDto
        {
            Id = x.Id,
            Name = x.Name,
            Profile = x.Profile,
            Manager = x.Manager,
            Is_Super_Admin = x.IsSuperAdmin,
            My_Organization = x.MyOrganization,

            Organization_Name = x.Organization.Name,
            Organization = x.OrganizationAccess,

            Unique_Id = x.UniqueId,
            Unique_Id_Status = x.UniqueIdStatus,
            Surname = x.Surname,
            Email = x.Email,
            Phone = x.Phone,
            Id_Number = x.IdNumber,

            Joining_Date = x.JoiningDate,
            End_Date = x.EndDate,

            Gender = x.GenderId,
            Disability = x.Disability,
            Race = x.Race.Name,
            Employee_Type = x.EmployeeType.Name,

            Highest_Qualification = x.HighestQualificationId,
            Name_Of_Qualification = x.NameOfQualification,

            Country = x.CountryId,
            State = x.StateId,
            City = x.CityId,

            Current_Address = x.CurrentAddress,

            Role = x.RoleId,
            Role_Desc = x.RoleDesc,
            Level = x.Level,

            Accountability = x.Accountability,
            Otp = x.Otp,

            Deleted = x.Deleted,
            Created_At = x.CreatedAt,
            Created_By = x.CreatedBy,
            Updated_At = x.UpdatedAt,
            Updated_By = x.UpdatedBy,

            City_Name = x.City.Name,
            State_Name = x.State.Name,
            Country_Name = x.Country.Name,
            Role_Name = x.Role.Name,

            Department = x.Department,
            Client_Internal_Id = x.UnifiedUserUiqueId
        })
  .FirstOrDefaultAsync();

                if (user == null) return null;
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
