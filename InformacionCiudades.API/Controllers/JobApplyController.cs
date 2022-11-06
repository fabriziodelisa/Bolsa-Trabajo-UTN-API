using ApiBolsaTrabajoUTN.API.Data.JobPositions;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.JobApply;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/JobApply")]
    public class JobApplyController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IJobPositionRepository _jobPositionRepository;
        public JobApplyController(UserManager<User> userManager, IJobPositionRepository jobPositionRepository)
        {
            _userManager = userManager;
            _jobPositionRepository = jobPositionRepository;
        }

        [HttpPost("CreateJobApply")]
        public async Task<ActionResult> CreateJobApply(CreateJobApplyRequest rq)
        {
            var rs = new CreateJobApplyResponse {
                Success = false,
            };
            var studentId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var jobPositionId = rq.JobPositionId;
            var jobPositionToApply = _jobPositionRepository.GetJobPosition(jobPositionId);
            if (jobPositionToApply == null)
            {
                rs.Message = "La postulación no se ha podido concretar. No se ha encontrado una Oferta laboral";
                return Ok(rs);
            }
            if (jobPositionToApply.StudentsWhoApplied.Any(x => x.Id == studentId))
            {
                rs.Message = "Ya has postulado a esta oferta laboral";
                return Ok(rs);
            }
            var student = (Student) await _userManager.FindByIdAsync(studentId);
            student.JobApplies.Add(jobPositionToApply);
            rs.Success = _jobPositionRepository.SaveChange();
            if (!rs.Success)
            {
                rs.Message = "La postulación no se ha podido concretar";
                return Ok(rs);
            }
            rs.Message = "Postulaste correctamente a: " + jobPositionToApply.JobTitle;
            return Ok(rs);
        }
        
        [HttpGet("GetJobAppliesOfStudent")]
        public ActionResult GetJobAppliesOfStudent()
        {
            var rs = new GetJobAppliesOfStudentResponse
            {
                Success = false,
            };
            var studentId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (studentId == null)
            {
                return BadRequest("Debes ser un Estudiante para solicitar tus postulaciones laborales");
            }
            rs.Data = _jobPositionRepository.GetJobAppliesOfStudent(studentId);
            if (rs.Data == null)
            {
                rs.Message = "No se han encontrado las postulaciones del estudiante";
                return Ok(rs);
            }
            rs.Success = true;
            rs.Message = "Postulaciones devueltas correctamente!";
            return Ok(rs);
        }

        [HttpGet("GetStudentsThatAppliedToJobPosition")]
        public ActionResult GetStudentsThatAppliedToJobPosition([FromQuery]GetJobAppliesOfStudentRequest rq)
        {
            var rs = new GetJobAppliesOfStudentResponse
            {
                Success = false,
            };
            var jobPositionId = rq.JobPositionId;
            rs.Data = _jobPositionRepository.GetStudentsThatAppliedToJobPosition(jobPositionId);
            if (rs.Data == null)
            {
                rs.Message = "Estudiantes no encontrados!";
                return Ok(rs);
            }
            rs.Success = true;
            rs.Message = "Estudiantes devueltos correctamente!";
            return Ok(rs);
        }

        [HttpDelete("DeleteJobApply")]
        public async Task<ActionResult> DeleteJobApply(DeleteJobApplyRequest rq)
        {
            var rs = new DeleteJobApplyResponse
            {
                Success = false,
            };
            var studentId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var jobPositionId = rq.JobPositionId;
            var jobPositionToDelete = _jobPositionRepository.GetJobPosition(jobPositionId);
            if (jobPositionToDelete == null)
            {
                return Ok("La postulación no se ha podido eliminar. No se ha encontrado una Oferta laboral asociada");
            }
            var student = (Student)await _userManager.FindByIdAsync(studentId);
            student.JobApplies.Remove(jobPositionToDelete);
            rs.Success = _jobPositionRepository.SaveChange();
            if (!rs.Success)
            {
                rs.Message = "La postulación no se ha podido eliminar";
                return Ok(rs);
            }
            rs.Message = "Eliminaste correctamente tu postulación a la Oferta laboral: " + jobPositionToDelete.JobTitle;
            return Ok(rs);
        }
    }
}
