﻿using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using ApiBolsaTrabajoUTN.API.Models.Register;

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
