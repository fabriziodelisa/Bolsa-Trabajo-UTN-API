using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiBolsaTrabajoUTN.API.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        public AuthenticationRepository(UserManager<User> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
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

            var roles = await _userManager.GetRolesAsync(user);

            //Crear el token
            var claveDeSeguridad = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credenciales = new SigningCredentials(claveDeSeguridad, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("email", user.Email));

            foreach (var role in roles)
            {
                claimsForToken.Add(new Claim("role", role));
            }

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credenciales);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            response.Success = true;
            response.Message = "You have been correctly logged in";
            response.Token = tokenToReturn;
            return response;
        } 
    }
}
