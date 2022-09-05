using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Company : User
    {
        [Required]
        public string BusinessName { get; set; }
        public int Cuit { get; set; }
        public List<JobPosition> JobPositions { get; set; }
        public Company(string businessName)
        {
            BusinessName = businessName;
            JobPositions = new List<JobPosition>();
        }
    }
}
