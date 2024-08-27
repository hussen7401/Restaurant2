using Core.Helper;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User
{
    public class Register
    {
        [Required(ErrorMessage = "يرجى ادخال الاسم الاول ")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "يرجى ادخال الاسم الثاني ")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "يرجى ادخال اسم المستخدم")]
        public required string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "يرجى ادخال عنوان البريد الالكتروني")]
        public required string Email { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "يرجى ادخال كلمة المرور .")]
        [PasswordValidation]
        public required string Password { get; set; }
    }
}
