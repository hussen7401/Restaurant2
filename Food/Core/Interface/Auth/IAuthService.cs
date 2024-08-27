using Core.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interface.Auth
{
    public interface IAuthService
    {
        Task<IActionResult> Register([FromBody] Register register);
        Task<IActionResult> Login([FromBody] Login login);
        Task<IActionResult> ForgetPassword(ForgetPassword forgetPassword);
        Task<IActionResult> ResetPassword(ResetPassword resetPassword);
        Task<IActionResult> ChangeUserRole(ChangeUserRole userRole);
        Task<IActionResult> ManageAccount(int userId , bool status);
    }
}
