using AutoMapper;
using ApiBolsaTrabajoUTN.API.Models.Career;
using ApiBolsaTrabajoUTN.API.Entities;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class CareerProfile : Profile
    {
        public CareerProfile()
        {
            CreateMap<Career,CareerDTO>();
            CreateMap<CareerToCreateDTO, Career>();
            CreateMap<CareerToUpdateDTO, Career>();
        }
    }
}
