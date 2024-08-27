using Core.Dtos.User;
using Core.Interface.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenData tokenData;

        public UserController(IUserService userServise,ITokenData tokenData)
        {
            _userService = userServise;
            this.tokenData = tokenData;
        }

        [HttpGet]
        public Task<IActionResult> GetUsers()
        {
            return _userService.GetUsers();
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpGet("Get-User-for-Admin/{id}")]
        public Task<IActionResult> GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetUserProfile(int id)
        {
            return _userService.GetUserProfile(id);
        }

        [HttpGet("UserName/{userName}")]
        public Task<IActionResult> SearchUser(string userName)
        {
            return _userService.GetUserByUsername(userName);
        }

        [HttpPut("Update")]
        public Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUser updateUser)
        {
            return _userService.UpdateUser(userId, updateUser);
        }

        [Authorize(Roles = "SuperAdmin ,Admin")]
        [HttpDelete("Delete/{userId}")]
        public Task<IActionResult> DeleteUser(int userId)
        {
            return _userService.DeleteUser(userId);
        }
    }
}
