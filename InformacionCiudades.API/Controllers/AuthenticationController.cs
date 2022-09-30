using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Helpers;
using ApiBolsaTrabajoUTN.API.Models;
using ApiBolsaTrabajoUTN.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IJwtService _jwtService;

        public AuthenticationController(IAuthenticationRepository authenticationRepository, IJwtService jwtService)
        {
            _authenticationRepository = authenticationRepository;
            _jwtService = jwtService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationModelRequest authenticationRequestBody)
        {
            var result = await _authenticationRepository.Authenticate(authenticationRequestBody);
            if (result.Success && result.Token != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "Successfully logged out"
            });
        }
    }
}
