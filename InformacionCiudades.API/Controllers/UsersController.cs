using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using ApiBolsaTrabajoUTN.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UsersController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserWithoutContentsDto>> GetUsers()
        {
            var users = _userManager.Users.ToList();

            return Ok(_mapper.Map<IEnumerable<UserWithoutContentsDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPut("{idUser}")]
        public async Task<ActionResult> UpdateUser(string idUser, UserCreationDto userForUpdate)
        {
            User user = await _userManager.FindByIdAsync(idUser);
            if (user is null)
                return NotFound();

            _mapper.Map(userForUpdate, user);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);

            
        }

        [HttpDelete("{idUser}")]
        public async Task<ActionResult> DeleteUser(string idUser)
        {
            if (_userManager.FindByIdAsync(idUser) is null)
                return NotFound();
            var userToDelete = await _userManager.FindByIdAsync(idUser);

            var result = _userManager.DeleteAsync(userToDelete);
            if (result.IsCompletedSuccessfully)
            {
                return NoContent();
            }
            return BadRequest(result);
        }
    }
}
