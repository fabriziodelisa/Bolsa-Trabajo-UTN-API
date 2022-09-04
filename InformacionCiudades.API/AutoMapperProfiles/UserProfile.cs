using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, RegisterStudentRequestBody>();
            CreateMap<RegisterStudentRequestBody, User>();
        }
    }
}
