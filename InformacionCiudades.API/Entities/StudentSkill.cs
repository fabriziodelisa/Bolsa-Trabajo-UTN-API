using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class StudentSkill
    {
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
