using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ApiBolsaTrabajoUTN.API.Models.Register;
using ApiBolsaTrabajoUTN.API.Models.users.Company;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using ApiBolsaTrabajoUTN.API.Services.Mails;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public RegisterController(UserManager<User> userManager,  IMapper mapper, RoleManager<IdentityRole> roleManager, IMailService mailservice)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _mailService = mailservice;
        }

        [HttpPost("RegisterStudent")]
        public async Task<ActionResult<StudentDto>> RegisterStudent(RegisterStudentRequestBody student)
        {
            // Assign email to username
            var newStudent = _mapper.Map<Student>(student);
            newStudent.UserName = student.Email;

            // Verify if role exists, if not create it
            var existsStudentRole = await _roleManager.RoleExistsAsync("Student");
            if (!existsStudentRole)
            {
                await _roleManager.CreateAsync(new IdentityRole("Student"));
            }

            // Create user with Identity
            var result = await _userManager.CreateAsync(newStudent, student.Password);

            // Assign the role
            var res = _userManager.AddToRoleAsync(newStudent, "Student");

            // Validation
            if (result.Succeeded && res.IsCompleted)
            {
                var studentToReturn = _mapper.Map<StudentDto>(newStudent);
                studentToReturn.Password = "";
                string URI = $"https://localhost:7172/api/Register{studentToReturn.Id}";
                _mailService.enviaMail(newStudent.UserName, $"Bienvenido {newStudent.FirstName}!. Te has registrado correctamente en el sistema de la bolsa de trabajo de la UTN FRRO", "Bolsa Trabajo UTN FRRO");    
                return Created(URI, studentToReturn);
            }     
            return BadRequest(result);
        }

        [HttpPost("RegisterCompany")]
        public async Task<ActionResult<CompanyDto>> RegisterCompany(RegisterCompanyRequestBody company)
        {
            // Assign email to username
            var newCompany = _mapper.Map<Company>(company);
            newCompany.UserName = company.Email;

            // Verify if role exists, if not create it
            var existsCompanyRole = await _roleManager.RoleExistsAsync("Company");
            if (!existsCompanyRole)
            {
                await _roleManager.CreateAsync(new IdentityRole("Company"));
            }

            // Create user with Identity
            var result = await _userManager.CreateAsync(newCompany, company.Password);

            // Assign the role
            var res = _userManager.AddToRoleAsync(newCompany, "Company");

            // Validation
            if (result.Succeeded && res.IsCompleted)
            {
                var companyToReturn = _mapper.Map<CompanyDto>(newCompany);
                string URI = $"https://localhost:7172/api/Register{companyToReturn.Id}";
                _mailService.enviaMail(newCompany.UserName, $"Te has registrado correctamente en el sistema de la bolsa de trabajo de la UTN FRRO", "Bolsa Trabajo UTN FRRO");
                return Created(URI, companyToReturn);  
            }
            return BadRequest(result);
        }
    }
}
