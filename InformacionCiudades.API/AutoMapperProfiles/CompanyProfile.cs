using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using ApiBolsaTrabajoUTN.API.Models.User;
using AutoMapper;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Company, CompanyInfoDto>();
            CreateMap<CompanyInfoDto, Company>();
            CreateMap<Company, RegisterCompanyRequestBody>();
            CreateMap<RegisterCompanyRequestBody, Company>();
        }
    }
}
