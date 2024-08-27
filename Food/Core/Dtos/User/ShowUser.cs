namespace Core.Dtos.User
{
    public class ShowUser
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
