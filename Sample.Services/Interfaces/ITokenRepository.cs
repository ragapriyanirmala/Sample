using Microsoft.AspNetCore.Identity;

namespace Sample.Services.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
