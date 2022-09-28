using ApiBolsaTrabajoUTN.API.Data.implementations;
using ApiBolsaTrabajoUTN.API.Data.Interfaces;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Controller]
    //[Authorize(Roles = "Company")]
    [Route("api/UsersInfo")]
    public class CompanyInfoController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CompanyInfoController(IUserRepository companyRepository, IMapper mapper)
        {
            _userRepository = companyRepository;
            _mapper = mapper;
        }


        [HttpGet("Company")]
        public ActionResult<CompanyInfoDto> GetCompanyInfo()
        {
            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var companyInfo = _userRepository.GetCompanyInfo(currentUserId);
            if (companyInfo is null)
                return NotFound();
            return Ok(_mapper.Map<CompanyInfoDto>(companyInfo));
        }

        [HttpPut("UpdateCompanyInfo")]
        public ActionResult<Company> UpdateCompanyInfo(UpdateCompanyInfoDto updateCompanyInfo)
        {
            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var companyInfo = _userRepository.GetCompanyInfo(currentUserId);
            //companyInfo.CompanyName = updateCompanyInfo.CompanyName;                estos datos no deberia poder cambiarlo el usuario
            //companyInfo.Cuit = updateCompanyInfo.Cuit;                            porque requeriria otra validacion de administracion
            //companyInfo.Sector = updateCompanyInfo.Sector;
            //companyInfo.LegalAdress = updateCompanyInfo.LegalAdress;
            //companyInfo.PostalCode = updateCompanyInfo.PostalCode;
            companyInfo.TelephoneNumber = updateCompanyInfo.TelephoneNumber;
            companyInfo.Web = updateCompanyInfo.Web;

            companyInfo.RecruiterName = updateCompanyInfo.RecruiterName;
            companyInfo.RecruiterLastName = updateCompanyInfo.RecruiterLastName;
            companyInfo.RecruiterPosition = updateCompanyInfo.RecruiterPosition;
            companyInfo.RecruiterPhoneNumber = updateCompanyInfo.RecruiterPhoneNumber;
            companyInfo.RecruiterEmail = updateCompanyInfo.RecruiterEmail;
            companyInfo.RecruiterRelWithCompany = updateCompanyInfo.RecruiterRelWithCompany;
            companyInfo.FirstChargeData = true;

            return NoContent();
        }

        /**************************************************************************************************************************/



        [HttpGet("Student")]
        public ActionResult<CompanyInfoDto> GetStudentInfo()
        {
            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var companyInfo = _userRepository.GetCompanyInfo(currentUserId);
            if (companyInfo is null)
                return NotFound();
            return Ok(_mapper.Map<CompanyInfoDto>(companyInfo));
        }

        [HttpPut("UpdateStudentInfo")]
        public ActionResult<Student> UpdateStudentInfo(UpdateCompanyInfoDto updateCompanyInfo)
        {
            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var studentInfo = _userRepository.GetStudentInfo(currentUserId);

            //me falta armar la entidad y el dto de student

            return NoContent();
        }
    }
}
