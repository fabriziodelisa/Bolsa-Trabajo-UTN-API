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
                HttpContext.Response.Cookies.Append("jwt", result.Token, new CookieOptions
                { HttpOnly = true, SameSite = SameSiteMode.Strict });
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuser")]
        public ActionResult<User> GetUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                var userToReturn = new User
                {
                    Id = userClaims.FirstOrDefault(o => o.Type == "sub")?.Value,
                };
                return Ok(userToReturn);
            }
            return BadRequest("The user could not be found");
        }
    }
}
