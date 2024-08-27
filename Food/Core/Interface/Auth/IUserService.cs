
using Core.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interface.Auth
{
    public interface IUserService
    {
        Task<IActionResult> GetUsers();
        Task<IActionResult> GetUserById(int id);
        Task<IActionResult> GetUserProfile(int id);
        Task<IActionResult> GetUserByUsername(string username);
        Task<IActionResult> DeleteUser(int userId);
        Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUser updateUser);
    }
}
