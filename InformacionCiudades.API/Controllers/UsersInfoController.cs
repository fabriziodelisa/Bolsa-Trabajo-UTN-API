using ApiBolsaTrabajoUTN.API.Data.UsersInfo;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.JobPosition;
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
    [Authorize]
    public class UsersInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly UserManager<Student> _studentManager;
        private readonly UserManager<Company> _companyManager;
        private readonly IUsersInfoRepository _usersInfoRepository;

        public UsersInfoController(IMapper mapper, UserManager<User> userManager, UserManager<Student> studentManager, UserManager<Company> companyManager, IUsersInfoRepository usersInfoRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _studentManager = studentManager;
            _companyManager = companyManager;
            _usersInfoRepository = usersInfoRepository;
        }

        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<UserWithoutContentsDto>> GetUsers()
        {
            var users = _userManager.Users.ToList();

            return Ok(_mapper.Map<IEnumerable<UserWithoutContentsDto>>(users));
        }

        [HttpGet("Company")]
        public async Task<ActionResult> GetCompanyInfo()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var companyInfo = await _companyManager.FindByIdAsync(userId);
            if (companyInfo is null)
                return NotFound();
            return Ok(_mapper.Map<CompanyDataDto>(companyInfo));
        }

        [HttpGet("GetAllCompanies")]
        public ActionResult GetAllCompanies()
        {
            var rs = new GetAllCompaniesResponse {
                Success = false,
            };
            var companies = _usersInfoRepository.GetAllCompanies().ToList();
            if (companies.Count == 0)
            {
                rs.Message = "No se han encontrado empresas";
                return Ok(rs);
            }
            rs.Data = companies;
            rs.Success = true;
            rs.Message = "Empresas retornadas correctamente";
            return Ok(rs);
        }

        [HttpPut("CreateDataCompany")]
        public async Task<ActionResult> CreateDataCompany([FromBody]CompanyCreateProfileDto companyData)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var companyInfo = await _companyManager.FindByIdAsync(userId);
            if (companyInfo is null)
                return NotFound();

            _mapper.Map(companyData, companyInfo);
            var result = await _companyManager.UpdateAsync(companyInfo);

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
            var companyInfo = await _companyManager.FindByIdAsync(userId);
            if (companyInfo is null)
                return NotFound();

            _mapper.Map(updateCompanyData, companyInfo);
            var result = await _companyManager.UpdateAsync(companyInfo);

            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpGet("Student")]
        public async Task<ActionResult> GetStudentInfo()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var studentInfo = await _studentManager.FindByIdAsync(userId);
            if (studentInfo is null)
                return NotFound();
            return Ok(_mapper.Map<StudentDataDto>(studentInfo));
        }

        [HttpGet("GetAllStudents")]
        public ActionResult GetAllStudents()
        {
            var rs = new GetAllStudentsResponse
            {
                Success = false,
            };
            var students = _usersInfoRepository.GetAllStudents().ToList();
            if (students.Count == 0)
            {
                rs.Message = "No se han encontrado alumnos";
                return Ok(rs);
            }
            rs.Data = students;
            rs.Success = true;
            rs.Message = "Alumnos retornadas correctamente";
            return Ok(rs);
        }

        [HttpPut("CreateDataStudent")]
        public async Task<ActionResult> CreateDataStudent(StudentCreateProfileDto studentData)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var studentInfo = await _studentManager.FindByIdAsync(userId);
            if (studentInfo is null)
                return NotFound();

            _mapper.Map(studentData, studentInfo);
            var result = await _studentManager.UpdateAsync(studentInfo);

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
            var studentInfo = await _studentManager.FindByIdAsync(userId);
            if (studentInfo is null)
                return NotFound();

            _mapper.Map(studentData, studentInfo);
            var result = await _studentManager.UpdateAsync(studentInfo);

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
            var student = await _studentManager.FindByIdAsync(userId);
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

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetCurriculum(string studentId)
        {
            var rs = new CreateJobPositionResponse
            {
                Success = false,
            };
            var student = await _studentManager.FindByIdAsync(studentId);
            if (student is null)
            {
                rs.Message = "El estudiante propietario del CV no fue encontrado";
                return Ok(rs);
            }

            if (student.Curriculum is null)
            {
                rs.Message = "El CV del estudiante es inexistente/aún no fue cargado";
                return Ok(rs);
            }

            return File(student.Curriculum, "application/pdf", $"{student.FirstName}_{student.LastName}_CV.pdf");
        }

        [HttpPut("ActivateDeactivateAccount")]
        public async Task<ActionResult> ActivateDeactivateAccount([FromBody] ActivateDeactivateAccountRequest rq)
        {
            if (rq.UserId == null)
            {
                return BadRequest("El id del usuario es nulo");
            }

            var user = await _userManager.FindByIdAsync(rq.UserId);
            user.ActiveAccount = rq.Activate;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
