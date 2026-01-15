using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.LoginRepository
{
    public interface ILoginRepository
    {
        Task<User?> GetByEmailOrUniqueId(string field);
        Task<UserDetailsDto?> GetUserDetails(int id);
    }
}
