using AutoMapper;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class CareerProfile : Profile
    {
        public CareerProfile()
        {
            CreateMap<Entities.Career, Models.Career.CareerDTO>();
            CreateMap<Models.Career.CareerToCreateDTO, Entities.Career>();
            CreateMap<Models.Career.CareerToUpdateDTO, Entities.Career>();
        }
    }
}
