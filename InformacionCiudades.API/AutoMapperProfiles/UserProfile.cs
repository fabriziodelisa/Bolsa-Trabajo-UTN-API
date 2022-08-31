using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.User;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserCreationDto>();
            CreateMap<User, UserWithoutContentsDto>();
            CreateMap<UserCreationDto, User>();
        }
    }
}
