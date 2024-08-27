namespace Core.Interface.Auth
{
    public interface ITokenData
    {
        int? UserId();
        string? FullName();
        string? UserName();
        Task<string?> Role();
    }
}
