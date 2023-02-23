using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        public void ReplaceSkillsOfStudent(Student student, AssignSkillsRequest skillIds)
        {
            if (skillIds.SkillsId != null)
            {
                if (student.StudentSkills != null)
                {
                student.StudentSkills.Clear();
                }

                foreach (var skillId in skillIds.SkillsId)
                {
                    var skill = _bolsaTrabajoContext.Skills.Find(skillId);

                    if (student.StudentSkills == null)
                    {
                        student.StudentSkills = new List<StudentSkill>();
                    }
                    if (skill != null)
                    {
                        StudentSkill newStudentSkill = new StudentSkill
                        {
                            Student = student,
                            Skill = skill
                        };
                        student.StudentSkills.Add(newStudentSkill);                  
                    }
                }
            _bolsaTrabajoContext.Update(student);
            _bolsaTrabajoContext.SaveChanges();
            }
        }
        public async Task<List<StudentSkill>> GetStudentSkillsByStudentId(string studentId)
        {
            return await _bolsaTrabajoContext.studentSkills.Where(ss => ss.StudentId == studentId).ToListAsync();
        }
    }
}
