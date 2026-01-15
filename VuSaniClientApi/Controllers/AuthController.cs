using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VuSaniClientApi.Application.Services.LoginService;
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
                    return NotFound(user.Message);

                return Ok(new ApiResponse<object>
                {
                    Status = true,
                    Message = "Successfully",
                    Data = user,
                    Token=user.Token
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
        public class ApiResponse<T>
        {
            public bool Status { get; set; }
            public string Message { get; set; }
            public string Token { get; set; }
            public T Data { get; set; }
        }
    }
}
