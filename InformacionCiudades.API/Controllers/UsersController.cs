using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using ApiBolsaTrabajoUTN.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public UsersController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserWithoutContentsDto>> GetUsers()
        {
            var users = _appRepository.GetUsers();

            return Ok(_mapper.Map<IEnumerable<UserWithoutContentsDto>>(users));
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _appRepository.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPut("{idUser}")]
        public ActionResult UpdateUser(int idUser, UserCreationDto user)
        {
            if (!_appRepository.UserExists(idUser))
                return NotFound();

            var userInDB = _appRepository.GetUser(idUser);
            if (userInDB is null)
                return NotFound();

            _mapper.Map(user, userInDB);
            _appRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{idUser}")]
        public ActionResult DeleteUser(int idUser)
        {
            if (!_appRepository.UserExists(idUser))
                return NotFound();
            var userToDelete = _appRepository.GetUser(idUser);
            if (userToDelete is null)
                return NotFound();
            _appRepository.DeleteUser(userToDelete.Id);
            _appRepository.SaveChanges();

            return NoContent();
        }
    }
}
