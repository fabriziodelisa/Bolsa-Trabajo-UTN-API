using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.users.Student;

namespace ApiBolsaTrabajoUTN.API.Data.Skills
{
    public interface ISkillsRepository : IRepository
    {
        public IEnumerable<Skill> GetAllSkills();
        public void AddSkill(Skill newSkill);
        public void DeleteSkill(int SkillId);
    }
}
