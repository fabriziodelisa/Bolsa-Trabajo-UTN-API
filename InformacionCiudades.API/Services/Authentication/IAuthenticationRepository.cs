using ApiBolsaTrabajoUTN.API.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsaTrabajoUTN.API.Services.Authentication
{
    public interface IAuthenticationRepository
    {
        public Task<AuthenticationModelResponse> Authenticate(AuthenticationModelRequest authenticationRequestBody);
    }
}
