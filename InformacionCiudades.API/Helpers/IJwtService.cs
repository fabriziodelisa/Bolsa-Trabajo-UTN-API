using ApiBolsaTrabajoUTN.API.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace ApiBolsaTrabajoUTN.API.Helpers
{
    public interface IJwtService
    {
        public Task<string> Generate(User user);
        public JwtSecurityToken Verify(string jwt);
    }
}
