using ApiBolsaTrabajoUTN.API.Data.implementations;
using ApiBolsaTrabajoUTN.API.Data.Interfaces;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
        [Controller]
        //[Authorize(Roles = "Company")]
        [Route("api/Company")]
    public class CompanyInfoController : ControllerBase
    {
        private readonly UserManager<Company> _userManager;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyInfoController(UserManager<Company> userManager, ICompanyRepository companyRepository, IMapper mapper) 
        {
            _userManager = userManager;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public string? GetUserId()
        {
         return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes./*sub*/NameIdentifier)?.Value;
            //   User.FindFirstValue(ClaimTypes.NameIdentifier);
            //   var userRole = User.FindFirstValue(ClaimTypes.Role);            
        }

        [HttpGet("CompanyInfo")]

        public ActionResult<CompanyInfoDto> GetInfo()
        {
            var currentUserId = GetUserId();

            var companyInfo = _companyRepository.GetInfo(currentUserId);
            if (companyInfo is null)
                return NotFound();
            return Ok(_mapper.Map<CompanyInfoDto>(companyInfo));
        }

        [HttpPut]

        public ActionResult UpdateInfo(UpdateCompanyInfoDto updateCompanyInfo)
        {
            var currentUserId = GetUserId();

            //var companyUpdate =
            //{
            //    company
            //}

            return NoContent();
        }

    }
}
