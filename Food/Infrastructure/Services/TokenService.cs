using System.Net.Http.Headers;
using Core.Interface;
namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly HttpClient _httpClient;

        public TokenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SetAuthenticationTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Token cannot be null or empty", nameof(token));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            await Task.CompletedTask;
        }
    }
}
