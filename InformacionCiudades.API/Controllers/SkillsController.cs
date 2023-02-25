using ApiBolsaTrabajoUTN.API.Data.Skills;
using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class DeleteSkillRequest
{
    public int Id { get; set; }
}

public class AssignSkillsRequest
{
    public List<int>? SkillsId { get; set; }
}

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsRepository _skillsRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Student> _studentManager;
        private readonly BolsaTrabajoContext _bolsaTrabajoContext;

        public SkillsController(IMapper mapper, ISkillsRepository skillsRepository, UserManager<Student> studentManager, BolsaTrabajoContext bolsaTrabajoContext)
        {
            _mapper = mapper;
            _skillsRepository = skillsRepository;
            _studentManager = studentManager;
            _bolsaTrabajoContext = bolsaTrabajoContext;
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

                var Data = new
                {
                    skillName = newSkill.SkillName,
                };
                return Ok(Data);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteSkill")]
        public ActionResult DeleteSkill(DeleteSkillRequest rq)
        {
            _skillsRepository.DeleteSkill(rq.Id);

            return NoContent();
        }

        [HttpPut("AddSkillToStudent")]

        public async Task<ActionResult> AddSkillsToStudent(AssignSkillsRequest skillsId) 
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var student = await _studentManager.FindByIdAsync(userId);
            if (student != null)
            {
                student.SkillsId = skillsId.SkillsId;

                _bolsaTrabajoContext.Update(student);
                _bolsaTrabajoContext.SaveChanges();
            }
            return Ok();
        }



        //[HttpPost("AssignSkillsToStudent")]
        //public async Task<ActionResult> AssignSkillsToStudent(AssignSkillsRequest skillIds)
        //{
        //    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        //    var student = await _studentManager.FindByIdAsync(userId);

        //    _skillsRepository.ReplaceSkillsOfStudent(student, skillIds);

        //    return Ok();
        //}

        //[HttpGet("SkillsOfStudent")]
        //public async Task<ActionResult> SkillsOfStudent()
        //{
        //    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
           
        //    var skills = await _skillsRepository.GetStudentSkillsByStudentId(userId);

        //    return Ok(skills);
        //}
    }
}
