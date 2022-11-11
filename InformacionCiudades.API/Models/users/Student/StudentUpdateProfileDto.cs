using ApiBolsaTrabajoUTN.API.Enums;
using System.Text.Json.Serialization;

namespace ApiBolsaTrabajoUTN.API.Models.users.Student
{
    public class StudentUpdateProfileDto
    {
        public string? Address { get; set; }
        public string? AddressNum { get; set; }
        public string? PhoneNumb { get; set; }
        public string? Email { get; set; }
        public string? Sex { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? GithubProfileURL { get; set; }
        public string? LinkedinProfileURL { get; set; }
        //cv
        public int CareerId { get; set; }
        public int ApprovedSubjets { get; set; }
        public string? PlanDeEstudio { get; set; }
        public int CurrentCareerYear { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Turn Turn { get; set; }
        public float Average { get; set; }
        public float AverageWithFails { get; set; }
        public bool FirstChargeData { get; set; }
        public bool ActiveAccount { get; set; } = true;
    }
}
