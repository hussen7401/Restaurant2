using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User
{
    public class Login
    {
        [Required(ErrorMessage = "لاتترك الحقل فارغ")]
        public string UserOrEmail { get; set; } = null!;
        [Required(ErrorMessage = "يرجى ادخال كلمة المرور")]
        [MinLength(8)]
        public string Password { get; set; } = null!;
    }
}
