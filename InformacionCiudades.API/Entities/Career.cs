using ApiBolsaTrabajoUTN.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Career
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public CareerTypes Type { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        [Required]
        public int TotalSubjets { get; set; }
    }
}
