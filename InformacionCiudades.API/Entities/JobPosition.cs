using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class JobPosition
    {
        [Key]
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
