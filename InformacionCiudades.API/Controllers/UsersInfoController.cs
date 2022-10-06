using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.users.Company;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Controller]
    [Route("api/UsersInfo")]
    public class UsersInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UsersInfoController(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        [HttpGet("Company")]
        public async Task<ActionResult> GetCompanyInfo()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Company companyInfo = (Company)await _userManager.FindByIdAsync(userId);
            if (companyInfo is null)
                return NotFound();
            return Ok(_mapper.Map<CompanyDataDto>(companyInfo));

        }

        [HttpPut("ChargeDataCompany")]
        public async Task<ActionResult> ChargeDataCompany(CompanyCreateProfileDto companyData)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Company companyInfo = (Company)await _userManager.FindByIdAsync(userId);
            if (companyInfo is null)
                return NotFound();

            _mapper.Map(companyData, companyInfo);
            var result = await _userManager.UpdateAsync(companyInfo);

            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateDataCompany")]
        public async Task<ActionResult> UpdateDataCompany(CompanyUpdateProfileDto updateCompanyData)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Company companyInfo = (Company)await _userManager.FindByIdAsync(userId);
            if (companyInfo is null)
                return NotFound();

            _mapper.Map(updateCompanyData, companyInfo);
            var result = await _userManager.UpdateAsync(companyInfo);

            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);
        }
        /*******************************************************************************************************/

        [HttpGet("Student")]
        public async Task<ActionResult> GetStudentInfo()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Student studentInfo = (Student)await _userManager.FindByIdAsync(userId);
            if (studentInfo is null)
                return NotFound();
            return Ok(_mapper.Map<StudentDataDto>(studentInfo));

        }

        [HttpPut("ChargeDataStudent")]
        public async Task<ActionResult> ChargeDataStudent(StudentCreateProfileDto studentData)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Student studentInfo = (Student)await _userManager.FindByIdAsync(userId);
            if (studentInfo is null)
                return NotFound();

            _mapper.Map(studentData, studentInfo);
            var result = await _userManager.UpdateAsync(studentInfo);

            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateDataStudent")]
        public async Task<ActionResult> UpdateDataStudent(StudentUpdateProfileDto studentData)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Student studentInfo = (Student)await _userManager.FindByIdAsync(userId);
            if (studentInfo is null)
                return NotFound();

            _mapper.Map(studentData, studentInfo);
            var result = await _userManager.UpdateAsync(studentInfo);

            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);
        }
    }
}
