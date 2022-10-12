using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.Register;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using AutoMapper;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, StudentDataDto>();
            CreateMap<StudentCreateProfileDto, Student>();
            CreateMap<StudentUpdateProfileDto, Student>();
            CreateMap<Student, RegisterStudentRequestBody>();
            CreateMap<RegisterStudentRequestBody, Student>();
        }
    }
}
