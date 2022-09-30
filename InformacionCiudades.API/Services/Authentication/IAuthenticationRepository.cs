using ApiBolsaTrabajoUTN.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsaTrabajoUTN.API.Services.Authentication
{
    public interface IAuthenticationRepository
    {
        public Task<AuthenticationModelResponse> Authenticate(AuthenticationModelRequest authenticationRequestBody);
    }
}
