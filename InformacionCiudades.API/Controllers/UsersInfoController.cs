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
            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var companyInfo = _userRepository.GetCompanyInfo(currentUserId);
            if (companyInfo is null)
                return NotFound();
            return Ok(_mapper.Map<CompanyInfoDto>(companyInfo));
        }

        [HttpPut("UpdateCompanyInfo")]
        public ActionResult<Company> UpdateCompanyInfo(CompanyInfoDto updateCompanyInfo)
        {
            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var companyInfo = _userRepository.GetCompanyInfo(currentUserId);
            companyInfo.CompName = updateCompanyInfo.CompName;
            companyInfo.Cuit = updateCompanyInfo.Cuit;
            companyInfo.Sector = updateCompanyInfo.Sector;
            companyInfo.LegalAdress = updateCompanyInfo.LegalAdress;
            companyInfo.PostalCode = updateCompanyInfo.PostalCode;
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
        public ActionResult<StudentInfoDto> GetStudentInfo()
        {
            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var studentInfo = _userRepository.GetCompanyInfo(currentUserId);
            if (studentInfo is null)
                return NotFound();
            return Ok(_mapper.Map<StudentInfoDto>(studentInfo));
        }

        [HttpPut("UpdateStudentInfo")]
        public ActionResult<Student> UpdateStudentInfo(StudentInfoDto updateCompanyInfo)
        {
            string? currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var studentInfo = _userRepository.GetStudentInfo(currentUserId);

            studentInfo.Legajo = updateCompanyInfo.Legajo;
            studentInfo.FirstName = updateCompanyInfo.FirstName;
            studentInfo.LastName = updateCompanyInfo.LastName;
            studentInfo.Email = updateCompanyInfo.Email;
            studentInfo.DocumentType = updateCompanyInfo.DocumentType;
            studentInfo.Dni = updateCompanyInfo.Dni;
            studentInfo.BirthDate = updateCompanyInfo.BirthDate;
            studentInfo.Cuil = updateCompanyInfo.Cuil;
            studentInfo.Address = updateCompanyInfo.Address;
            studentInfo.AddressNum = updateCompanyInfo.AddressNum;
            studentInfo.Sex = updateCompanyInfo.Sex;
            studentInfo.Country = updateCompanyInfo.Country;
            studentInfo.Province = updateCompanyInfo.Province;
            studentInfo.City = updateCompanyInfo.City;
            studentInfo.PhoneNumber = updateCompanyInfo.PhoneNumber;
            studentInfo.CareerId = updateCompanyInfo.CareerId;
            studentInfo.ApprovedSubjets = updateCompanyInfo.ApprovedSubjets;
            studentInfo.PlanDeEstudio = updateCompanyInfo.PlanDeEstudio;
            studentInfo.CurrentCareerYear = updateCompanyInfo.CurrentCareerYear;
            studentInfo.Turn = updateCompanyInfo.Turn;
            studentInfo.Average = updateCompanyInfo.Average;
            studentInfo.AverageWithFails = updateCompanyInfo.AverageWithFails;
            studentInfo.FirstChargeData = true;

            return NoContent();
        }
    }
}
