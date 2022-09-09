//using AutoMapper;
//using ApiBolsaTrabajoUTN.API.Entities;
//using ApiBolsaTrabajoUTN.API.Models;
//using ApiBolsaTrabajoUTN.API.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
//using ApiBolsaTrabajoUTN.API.Models.User;

//namespace ApiBolsaTrabajoUTN.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RegisterController : ControllerBase
//    {
//        private readonly UserManager<User> _userManager;
//        private readonly IMapper _mapper;

//        public RegisterController(UserManager<User> userManager, IMapper mapper)
//        {
//            _userManager = userManager;
//            _mapper = mapper;
//        }

//        [HttpPost]
//        public async Task<ActionResult<UserDto>> RegisterUser(UserCreationDto user)
//        {
//            var newUser = _mapper.Map<User>(user);

//            var result = await _userManager.CreateAsync(newUser, user.Password);
//            if (result.Succeeded)
//            {

//                var userToReturn = _mapper.Map<UserDto>(newUser);
//                string URI = $"https://localhost:7172/api/Register{userToReturn.Id}"; //acá no deberían alguna url a un endpoint de getUser by id
//                return Created(URI, userToReturn);
//            }
//            return BadRequest(result);
//        }
//    }
//}
