using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.Register;
using ApiBolsaTrabajoUTN.API.Models.User;
using AutoMapper;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Company, RegisterCompanyRequestBody>();
            CreateMap<RegisterCompanyRequestBody, Company>();
        }
    }
}
