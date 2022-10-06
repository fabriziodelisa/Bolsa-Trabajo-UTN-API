using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.Register;
using ApiBolsaTrabajoUTN.API.Models.users.Company;
using AutoMapper;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Company, CompanyDataDto>();
            CreateMap<CompanyCreateProfileDto, Company>();
            CreateMap<CompanyUpdateProfileDto, Company>();
            CreateMap<Company, RegisterCompanyRequestBody>();
            CreateMap<RegisterCompanyRequestBody, Company>();
        }
    }
}
