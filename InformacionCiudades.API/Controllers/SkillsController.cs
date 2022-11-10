using ApiBolsaTrabajoUTN.API.Data.Skills;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsRepository _skillsRepository;
        private readonly IMapper _mapper;

        public SkillsController(IMapper mapper, ISkillsRepository skillsRepository)
        {
            _mapper = mapper;
            _skillsRepository = skillsRepository;
        }

        [HttpGet("GetAllSkills")]
        public ActionResult GetSkills()
        {
            var SkillsList =_skillsRepository.GetAllSkills();
            return Ok(SkillsList);
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
