using ApiBolsaTrabajoUTN.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsaTrabajoUTN.API.Services
{
    public interface IAuthenticationRepository
    {
        public Task<string> Authenticate(AuthenticationRequestBody authenticationRequestBody);
    }
}
