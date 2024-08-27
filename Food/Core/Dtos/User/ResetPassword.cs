using Core.Helper;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User
{
    public class ResetPassword
    {
        [Required(ErrorMessage ="يرجى ادخال كلمة المرور الجديدة.")]
        [PasswordValidation]
        public string NewPassword { get; set; } = null!;
        [Required(ErrorMessage = "يرجى إدخال  الرمز السري ")]
        [Range(1000000, 9999999, ErrorMessage = " يجب أن يحتوي على 7 أرقام")]
        public int OtpToken { get; set; }
    }
}
