﻿using ApiBolsaTrabajoUTN.API.Models.JobPosition;
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
        [HttpGet("AddJobPosition")]
        public ActionResult AddJobPosition(CreateJobPositionRequest rq)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return Ok(new {
                id = userId,
            });
        }
    }
}
