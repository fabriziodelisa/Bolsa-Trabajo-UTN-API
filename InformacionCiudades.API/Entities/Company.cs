using ApiBolsaTrabajoUTN.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Company : User
    {
        public string CompanyName { get; set; }
        public string Cuit { get; set; }
        public string TelephoneNumber { get; set; }
        public string Sector { get; set; }
        public string LegalAdress { get; set; }
        public string PostalCode { get; set; }
        public string? Web { get; set; }

        public string RecruiterName { get; set; }
        public string RecruiterLastName { get; set; }
        public string RecruiterPosition { get; set; }
        public string RecruiterPhoneNumber { get; set; }
        public string RecruiterEmail { get; set; }
        public RecruiterRelWithCompany RecruiterRelWithCompany { get; set; }
        public bool FirstChargeData { get; set; } = false;
        public List<JobPosition> JobPositions { get; set; }
        public Company()
            {
                JobPositions = new List<JobPosition>();
            }
    }
}

