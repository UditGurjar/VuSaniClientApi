using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.LoginRepository;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;
using VuSaniClientApi.Models.QueryModels;

namespace VuSaniClientApi.Application.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;
        public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }
        public async Task<AuthResponseDTO> AuthenticateUser(UserLoginQuery user)
        {
            try
            {    
                var isUserExist=await _loginRepository.GetByEmailOrUniqueId(user.Field);
                if (isUserExist == null)
                {
                    return new AuthResponseDTO
                    {
                        Token = string.Empty,
                        User = null,
                        Message = "Email or Unique Id not found",
                        Status=false,
                    };
                }
                if (!PasswordHelper.VerifyPassword(user.Password, isUserExist.Password, "SHA1"))
                {
                    return new AuthResponseDTO
                    {
                        Token = string.Empty,
                        User = null,
                        Message= "Invalid Password",
                        Status=false
                    };
                }
               var userDetails=await _loginRepository.GetUserDetails(isUserExist.Id);
                var token = GenerateJwt(userDetails);
                return new AuthResponseDTO
                {
                    Token = token,
                    User = userDetails,
                    Message = "Sucessfully",
                    Status = true
                };
            }
            catch (Exception)
            {

                throw;
            }   
        }
        //    public string GenerateJwt(UserDetailsDto user)
        //    {
        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        //        var payload = new JwtPayload
        //{
        //    { "sessionEmail", user.Email },
        //    { "sessionid", user.Id },
        //    { "sessionidRole", user.Role },
        //    { "sessionOrganization", user.Organization ?? "[]" },
        //    { "sessionMyOrganization", user.My_Organization },
        //    { "isSuperAdmin", user.Is_Super_Admin },
        //    { "iat", now },
        //    { "exp", now + 21600 }
        //};

        //        var token = new JwtSecurityToken(new JwtHeader(creds), payload);

        //        return new JwtSecurityTokenHandler().WriteToken(token);
        //    }


        public string GenerateJwt(UserDetailsDto user)
        {
            var claims = new[]
            {
            new Claim("sessionEmail", user.Email),
            new Claim("sessionid", user.Id.ToString()),
            new Claim("sessionidRole", "2"),
            new Claim("sessionOrganization", user.Organization.ToString()),
            new Claim("sessionMyOrganization", user.My_Organization.ToString()),
            new Claim("isSuperAdmin", user.Is_Super_Admin.ToString())
        };
            var jwtSettings = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
