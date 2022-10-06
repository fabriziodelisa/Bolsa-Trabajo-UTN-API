using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ApiBolsaTrabajoUTN.API.Models.Register;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using ApiBolsaTrabajoUTN.API.Models.users.Company;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RegisterController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("RegisterStudent")]
        public async Task<ActionResult<StudentDto>> RegisterStudent(RegisterStudentRequestBody student)
        {
            var newStudent = _mapper.Map<Student>(student);
            newStudent.UserName = student.Email;

            var result = await _userManager.CreateAsync(newStudent, student.Password);
            if (result.Succeeded)
            {
                var studentToReturn = _mapper.Map<StudentDto>(newStudent);
                studentToReturn.Password = "";
                string URI = $"https://localhost:7172/api/Register{studentToReturn.Id}";
                return Created(URI, studentToReturn);
            }
            return BadRequest(result);
        }
        [HttpPost("RegisterCompany")]
        public async Task<ActionResult<CompanyDto>> RegisterCompany(RegisterCompanyRequestBody company)
        {
            var newCompany = _mapper.Map<Company>(company);
            newCompany.UserName = company.Email;

            var result = await _userManager.CreateAsync(newCompany, company.Password);
            if (result.Succeeded)
            {
                var companyToReturn = _mapper.Map<CompanyDto>(newCompany);
                string URI = $"https://localhost:7172/api/Register{companyToReturn.Id}";
                return Created(URI, companyToReturn);
            }
            return BadRequest(result);
        }
    }
}
