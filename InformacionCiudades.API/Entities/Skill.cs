using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Skill {
        [Key]
        public int Id { get; set; }
        public string? SkillName { get; set; } 
    }
}
