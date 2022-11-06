using ApiBolsaTrabajoUTN.API.Enums;
using System.Text.Json.Serialization;

namespace ApiBolsaTrabajoUTN.API.Models.users.Company
{
    public class CompanyDataDto
    {
        public string? CompanyName { get; set; }
        public string? Cuit { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Sector { get; set; }
        public string? LegalAdress { get; set; }
        public string? PostalCode { get; set; }
        public string? Web { get; set; }

        public string? RecruiterName { get; set; }
        public string? RecruiterLastName { get; set; }
        public string? RecruiterPosition { get; set; }
        public string? RecruiterPhoneNumber { get; set; }
        public string? RecruiterEmail { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RecruiterRelWithCompany RecruiterRelWithCompany { get; set; } = RecruiterRelWithCompany.inCompany;
    }
}

