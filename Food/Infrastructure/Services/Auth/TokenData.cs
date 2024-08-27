using Core.Interface.Auth;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class TokenData : ITokenData
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppDbContext _context;

        public TokenData(IHttpContextAccessor httpContext,AppDbContext context)
        {
            _httpContext = httpContext;
            _context = context;
        }

        public int? UserId()
        {
            var tokenClaims = _httpContext.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == "userId");
            return tokenClaims != null && int.TryParse(tokenClaims.Value, out int result) ? result : null;
        }

        public string? FullName()
        {
            var tokenClaims = _httpContext.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == "fullName");
            return tokenClaims?.Value ?? string.Empty;
        }

        public string? UserName()
        {
            var tokenClaims = _httpContext.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == "userName");
            return tokenClaims?.Value ?? string.Empty;
        }

        public async Task<string?> Role()
        {
            var userIdClaim = _httpContext.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "userId");

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return null;
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user?.Role.ToString();
        }
    }
}
