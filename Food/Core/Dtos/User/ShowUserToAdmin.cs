﻿using Core.Enums;

namespace Core.Dtos.User
{
    public class ShowUserToAdmin
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public UserRoles Role { get; set; }
        public bool IsLocked { get; set; } 
        public DateTime? LastLoginDate { get; set; }
        public int? CreatorId { get; set; }
        public DateTime CreateAt { get; set; } 
        public int? ModifierId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? DeleterId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
