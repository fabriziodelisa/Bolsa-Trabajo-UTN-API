using ApiBolsaTrabajoUTN.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class JobPosition
    {
        [Key]
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public int CareerId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
        public int PositionsAvailable { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime EndDate { get; set; }
        public JobType JobType { get; set; }
        public WorkDay WorkDay { get; set; }
        [ForeignKey("CareerId")]
        public Career Career { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public List<Student> StudentsWhoApplied { get; set; } = new List<Student>();
    }
}
