using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.users;
using AutoMapper;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
             CreateMap<User, UserWithoutContentsDto>();
        }

    }
}
