using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;


namespace ApiBolsaTrabajoUTN.API.Data.Skills
{
    public class SkillsRepository : Repository, ISkillsRepository
    {
        public SkillsRepository(BolsaTrabajoContext bolsaTrabajoContext) : base(bolsaTrabajoContext)
        {
        }
        public IEnumerable<Skill> GetAllSkills()
        {
            return _bolsaTrabajoContext.Skills.OrderBy(x => x.SkillName).ToList();
        }

        public void AddSkill(Skill newSkill)
        {
            _bolsaTrabajoContext.Skills.Add(newSkill);
        }

        public void DeleteSkill(int SkillId)
        {
            var skill = _bolsaTrabajoContext.Skills.Find(SkillId);
            if (skill != null)
                _bolsaTrabajoContext.Skills.Remove(skill);
                _bolsaTrabajoContext.SaveChanges();
        }
    }
}
