using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User
{
    public class ForgetPassword
    {
        [Required(ErrorMessage = "لاتترك الحقل فارغ")]
        public string Email { get; set; } = null!;
    }
}
