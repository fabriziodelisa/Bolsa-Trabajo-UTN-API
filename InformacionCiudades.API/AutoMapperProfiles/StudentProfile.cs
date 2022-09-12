using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, RegisterStudentRequestBody>();
            CreateMap<RegisterStudentRequestBody, Student>();
        }
    }
}
