﻿using ApiBolsaTrabajoUTN.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Student : User
    {
        // Personal data
        [Required]
        public int Legajo { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public DocumentType DocumentType { get; set; }
        public string? Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Cuil { get; set; }
        public string? Address { get; set; }
        public string? AddressNum { get; set; }
        public string? PhoneNumb { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public byte[]? Curriculum { get; set; }

        // University data
        public int CareerId { get; set; }
        public int ApprovedSubjets { get; set; }
        public string? PlanDeEstudio { get; set; }
        public int CurrentCareerYear { get; set; }
        public Turn Turn { get; set; }
        public int Average { get; set; }
        public int AverageWithFails { get; set; }
        // public List<string> Skils { get; set; } = new List<string>();   //*** sin implementar aun
        public List<JobPosition> JobApplies { get; set; } = new List<JobPosition>();
    }
}
