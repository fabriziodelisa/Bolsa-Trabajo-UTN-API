using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using ApiBolsaTrabajoUTN.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public RegisterController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }
        //[HttpGet("{id}", Name = "GetRegister")]
        //public IActionResult GetRegister(int id)
        //{
        //    return Ok(id);
        //}

        [HttpPost]
        public ActionResult<UserDto> RegisterUser(UserCreationDto user)
        {
            var newUser = _mapper.Map<User>(user);

            _appRepository.CreateUser(newUser);
            _appRepository.SaveChanges();

            var userToReturn = _mapper.Map<UserDto>(newUser);
            string URI = $"https://localhost:7172/api/Register{userToReturn.Id}";
            return Created(URI, userToReturn);

            //return CreatedAtRoute("GetRegister", new { id = newUser.Id }, userToReturn);
        }
    }
}
