using ApiBolsaTrabajoUTN.API.Data.UsersInfo;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.users;
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
        private readonly IUsersInfoRepository _usersInfoRepository;

        public UsersInfoController(IMapper mapper, UserManager<User> userManager, IUsersInfoRepository usersInfoRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _usersInfoRepository = usersInfoRepository;
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

        [HttpGet("GetAllCompanies")]
        public async Task<ActionResult> GetAllCompanies()
        {
            var rs = new GetAllCompaniesResponse {
                Success = false,
            };
            var companyInfo = _usersInfoRepository.GetAllCompanies().ToList();
            if (companyInfo.Count == 0)
            {
                rs.Message = "No se han encontrado empresas";
                return Ok(rs);
            }
            rs.Data = companyInfo;
            rs.Success = true;
            rs.Message = "Empresas retornadas correctamente";
            return Ok(rs);
        }

        [HttpPut("CreateDataCompany")]
        public async Task<ActionResult> CreateDataCompany(CompanyCreateProfileDto companyData)
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
    }
}
