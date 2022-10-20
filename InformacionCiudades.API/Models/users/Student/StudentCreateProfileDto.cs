﻿using ApiBolsaTrabajoUTN.API.Enums;
using System.Text.Json.Serialization;

namespace ApiBolsaTrabajoUTN.API.Models.users.Student
{
    public class StudentCreateProfileDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DocumentType DocumentType { get; set; }
        public string? Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Cuil { get; set; }
        public string? Address { get; set; }
        public string? AddressNum { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? PhoneNumb { get; set; }
        //cv
        public int CareerId { get; set; }
        public int ApprovedSubjets { get; set; }
        public string? PlanDeEstudio { get; set; }
        public int CurrentCareerYear { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Turn Turn { get; set; }
        public int Average { get; set; }
        public int AverageWithFails { get; set; }
        //public List<string> Skils { get; set; }   //*** sin implementar aun
        public bool FirstChargeData { get; set; }
    }
}