using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Company : User
    {
        [Required]
        public string CompanyName { get; set; }
        public int Cuit { get; set; }
        public List<JobPosition> JobPositions { get; set; }
        public Company(string companyName)
        {
            CompanyName = companyName;
            JobPositions = new List<JobPosition>();
        }
    }
}
