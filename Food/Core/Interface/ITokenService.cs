
namespace Core.Interface
{
    public interface ITokenService
    {
        Task SetAuthenticationTokenAsync(string token);
    }
}
