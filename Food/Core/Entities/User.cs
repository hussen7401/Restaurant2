using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User :EntityBase
    {
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required string PasswordHash { get; set; }
        public UserRoles Role { get; set; } = UserRoles.Customer;
        public string? Token { get; set; }
        public int? OtpToken { get; set; } = null;
        public DateTime? OtpExpire { get; set; } = null;
        public bool IsLocked { get; set; } = false;
        public int AccessFailedCount { get; set; } = 0;
        public DateTime? LockTime { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int? DeleterId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
