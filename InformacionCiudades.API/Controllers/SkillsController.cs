using ApiBolsaTrabajoUTN.API.Data.Skills;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.Career;
using ApiBolsaTrabajoUTN.API.Models.users.Company;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly UserManager<Student> _studentManager;
        private readonly ISkillsRepository _skillsRepository;
        private readonly IMapper _mapper;

        public SkillsController(UserManager<Student> studentManager, IMapper mapper, ISkillsRepository skillsRepository)
        {
            _studentManager = studentManager;
            _mapper = mapper;
            _skillsRepository = skillsRepository;
        }

        [HttpGet("GetAllSkills")]
        public ActionResult GetSkills()
        {
            var SkillsList =_skillsRepository.GetAllSkills();
            return Ok(SkillsList);
        }

        [HttpPut("UpdateStudentSkills")]
        public async Task<ActionResult> UpdateStudentSkills(SkillsDto SkillsId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var student = await _studentManager.FindByIdAsync(userId);
            if (student is null)
                return NotFound();


            var Skills = _skillsRepository.UpdateStudentSkills(SkillsId.SkillsId);

            student.Skills = Skills;

            var result = await _studentManager.UpdateAsync(student);
 

            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpPost("CreateSkill")]
        public ActionResult CreateSkill(SkillCreateDTO skill)
        {
            var newSkill = _mapper.Map<Skill>(skill);

            if (newSkill != null)
            {
                _skillsRepository.AddSkill(newSkill);

                _skillsRepository.SaveChange();

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("DeleteSkill")]
        public ActionResult DeleteSkill(int id)
        {
            _skillsRepository.DeleteSkill(id);

            return NoContent();
        }

    }
}
