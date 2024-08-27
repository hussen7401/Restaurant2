using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.User
{
    public class ChangeUserRole
    {
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage = "الرجاء اختيار الدور")]
        public UserRoles NewRole { get; set; }
    }
}
