using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.QueryModels;

namespace VuSaniClientApi.Application.Services.LoginService
{
    public interface ILoginService
    {
        Task<AuthResponseDTO> AuthenticateUser(UserLoginQuery user);
        string GenerateJwt(UserDetailsDto userDetails);
    }
}
