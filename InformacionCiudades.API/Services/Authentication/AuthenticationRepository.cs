using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Helpers;
using ApiBolsaTrabajoUTN.API.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiBolsaTrabajoUTN.API.Services.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;
        public AuthenticationRepository(UserManager<User> userManager, IConfiguration config, IJwtService jwtService)
        {
            _userManager = userManager;
            _config = config;
            _jwtService = jwtService;
        }
        public async Task<AuthenticationModelResponse> Authenticate(AuthenticationModelRequest rq)
        {
            var response = new AuthenticationModelResponse();

            if (rq.Email == null || rq.Password == null)
            {
                response.Success = false;
                response.Message = "Please, introduce valid data.";
                return response;
            }

            var user = await _userManager.FindByEmailAsync(rq.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, rq.Password))
            {
                response.Success = false;
                response.Message = "The user was not found";
                return response;
            }

            // Generamos el token
            var tokenToReturn = await _jwtService.Generate(user);

            response.Success = true;
            response.Message = "You have been correctly logged in";
            response.Token = tokenToReturn;
            return response;
        }
    }
}
