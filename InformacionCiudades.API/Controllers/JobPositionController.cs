using ApiBolsaTrabajoUTN.API.Models.JobPosition;
using ApiBolsaTrabajoUTN.API.Services.JobPositions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/JobPosition")]
    public class JobPositionController : ControllerBase
    {
        private readonly IJobPositionService _jobPositionService;
        public JobPositionController(IJobPositionService jobPositionService)
        {
            _jobPositionService = jobPositionService;
        }

        [HttpPost("AddJobPosition")]
        public async Task<ActionResult> AddJobPosition(CreateJobPositionRequest rq)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var rs = await _jobPositionService.AddJobPosition(userId, rq);
            return Ok(rs);
        }

        [HttpGet("GetAllJobPositions")]
        public ActionResult GetAllJobPositions()
        {
            var rs = _jobPositionService.GetAllJobPositions();
            return Ok(rs);
        }

        [HttpGet("GetCompanyJobPositions")]
        public ActionResult GetCompanyJobPositions()
        {
            var companyId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var rs = _jobPositionService.GetCompanyJobPositions(companyId);
            return Ok(rs);
        }

        [HttpGet("GetJobPosition")]
        public ActionResult GetJobPosition([FromQuery] GetJobPositionRequest rq)
        {
            var rs = _jobPositionService.GetJobPosition(rq.JobPositionId);
            return Ok(rs);
        }
    }
}
