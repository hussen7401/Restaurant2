using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core.Helper
{
    public class PasswordValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var password = value as string;

            if (password!.Length < 8)
            {
                return new ValidationResult("يجب أن تكون كلمة المرور مكونة من 8 أحرف على الأقل.");
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return new ValidationResult("يجب أن تحتوي على حرف كبير واحد على الأقل.");
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                return new ValidationResult("يجب أن تحتوي على حرف صغير واحد على الأقل .");
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                return new ValidationResult("يجب أن تحتوي على رقم واحد على الأقل (0-9).");
            }

            if (!Regex.IsMatch(password, @"[^a-zA-Z\d]"))
            {
                return new ValidationResult("يجب أن تحتوي على رمز خاص واحد على الأقل : !@#$%^&*.");
            }

            return ValidationResult.Success!;
        }
    }

}
