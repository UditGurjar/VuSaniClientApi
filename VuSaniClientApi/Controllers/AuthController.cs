using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VuSaniClientApi.Application.Services.LoginService;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.QueryModels;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILoginService _loginService;
        public AuthController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginQuery dto)
        {
            try
            {
                var user = await _loginService.AuthenticateUser(dto);

                if (user.Status == false)
                {
                    Log.Warning("Login failed for {Field}: {Message}", dto.Field, user.Message);
                    return Unauthorized(new ApiResponse<object>
                    {
                        Status = false,
                        Message = user.Message,
                        Data = null,
                        Token = null
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Status = true,
                    Message = "Successfully",
                    Data = user,
                    Token = user.Token
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Login error for {Field}: {Message}", dto.Field, ex.Message);
                return BadRequest(new ApiResponse<object>
                {
                    Status = false,
                    Message = "An error occurred during login",
                    Data = null,
                    Token = null
                });
            }
        }
        
    }
}
