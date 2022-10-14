using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.users;
using ApiBolsaTrabajoUTN.API.Models.users.Company;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
   // [Authorize]
    public class UsersInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UsersInfoController(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        
        [HttpGet("GetAllUsers")]                   //por el momento sin implementación
        public ActionResult<IEnumerable<UserWithoutContentsDto>> GetUsers()
        {
            var users = _userManager.Users.ToList();

            return Ok(_mapper.Map<IEnumerable<UserWithoutContentsDto>>(users));
        }
        /***************************************************************************************************** ***/

        [HttpGet("Company")]
        public async Task<ActionResult> GetCompanyInfo()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Company companyInfo = (Company)await _userManager.FindByIdAsync(userId);
            if (companyInfo is null)
                return NotFound();
            return Ok(_mapper.Map<CompanyDataDto>(companyInfo));
        }

        [HttpPut("CreateDataCompany")]
        public async Task<ActionResult> CreateDataCompany([FromBody]CompanyCreateProfileDto companyData)
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

        [HttpPut("CreateDataStudent")]
        public async Task<ActionResult> CreateDataStudent(StudentCreateProfileDto studentData)
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

        [HttpPost("UploadCV")]
        public async Task<IActionResult> UploadCV([FromForm] UploadCVDto request)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Student student = (Student)await _userManager.FindByIdAsync(userId);
            if (student is null)
                return NotFound();

            IFormFile file = request.File;

            long length = file.Length;
            if (length < 0)
                return BadRequest("You should attach a valid pdf file");

            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);

            student.Curriculum = bytes;

            await _userManager.UpdateAsync(student);

            return Ok();
        }

        [HttpGet("DownloadCV")]
        public async Task<IActionResult> GetCurriculum()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            Student studentInfo = (Student)await _userManager.FindByIdAsync(userId);
            if (studentInfo is null)
                return NotFound();

            if (studentInfo.Curriculum is null)
            {
                return BadRequest();
            }

            return File(studentInfo.Curriculum, "application/pdf", $"{studentInfo.FirstName}_{studentInfo.LastName}_CV.pdf");
        }

    }
}
