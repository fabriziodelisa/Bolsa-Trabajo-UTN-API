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
                return Ok("La postulación no se ha podido concretar. No se ha encontrado una Oferta laboral");
            }
            var student = (Student) await _userManager.FindByIdAsync(studentId);
            student.JobApplies.Add(jobPositionToApply);
            rs.Success = _jobPositionRepository.SaveChange();
            if (!rs.Success)
            {
                rs.Message = "La postulación no se ha pidodo concretar";
                return Ok(rs);
            }
            rs.Message = "Postulaste correctamente a la Oferta laboral: " + jobPositionToApply.JobTitle;
            return Ok(rs);
        }
    }
}
