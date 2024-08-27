using Core.Dtos.User;
using Core.Helper;
using Core.Interface.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly Responses _responses;

        public AuthController(IAuthService authServise, Responses responses)
        {
            _authService = authServise;
            _responses = responses;
        }
        [HttpPost("register")]
        public Task<IActionResult> Register([FromBody] Register register)
        {
            return _authService.Register(register);
        }

        [HttpPost("Lodin")]
        public Task<IActionResult> Login([FromBody] Login login)
        {
            return _authService.Login(login);
        }

        [HttpPost("forgot-password")]
        public Task<IActionResult> ForgetPassword(ForgetPassword forgetPassword)
        {
            return _authService.ForgetPassword(forgetPassword);
        }

        [HttpPost("Reset-password")]
        public Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            return _authService.ResetPassword(resetPassword);
        }
        
        [HttpPut("Change-User-Role")]
        [Authorize(Roles = "SuperAdmin ,Admin")]
        public Task<IActionResult> ChangeUserRole(ChangeUserRole userRole)
        {
            return _authService.ChangeUserRole(userRole);
        }

        [HttpPut("Manage-Account/{userId}")]
        [Authorize(Roles = "SuperAdmin ,Admin")]
        public Task<IActionResult> ManageAccount(int userId, bool status)
        {
            return _authService.ManageAccount(userId, status);
        }
    }
}
