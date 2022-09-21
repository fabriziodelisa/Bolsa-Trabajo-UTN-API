using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using ApiBolsaTrabajoUTN.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationController(IConfiguration config, UserManager<User> userManager, IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationModelRequest authenticationRequestBody)
        {
            var result = await _authenticationRepository.Authenticate(authenticationRequestBody);
            if (result.Success && result.Token != null)
            {
                HttpContext.Response.Cookies.Append("jwt", result.Token, new CookieOptions
                { HttpOnly = true, SameSite = SameSiteMode.Strict });
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
