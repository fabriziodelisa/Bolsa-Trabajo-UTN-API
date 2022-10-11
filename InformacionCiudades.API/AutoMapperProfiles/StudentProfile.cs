using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.Register;
using ApiBolsaTrabajoUTN.API.Models.users.Student;

namespace ApiBolsaTrabajoUTN.API.AutoMapperProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentInfoDto>();
            CreateMap<StudentInfoDto, Student> ();
            CreateMap<Student, RegisterStudentRequestBody>();
            CreateMap<RegisterStudentRequestBody, Student>();
        }
    }
}
