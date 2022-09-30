using ApiBolsaTrabajoUTN.API.Data.JobPositions;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.JobPosition;

namespace ApiBolsaTrabajoUTN.API.Services.JobPositions
{
    public class JobPositionService : IJobPositionService
    {
        private readonly IJobPositionRepository _jobPositionRepository;
        public JobPositionService(IJobPositionRepository jobPositionRepository)
        {
            _jobPositionRepository = jobPositionRepository;
        }

        public async Task<CreateJobPositionResponse> AddJobPosition(string companyId, CreateJobPositionRequest rq)
        {
            // Create response object
            var rs = new CreateJobPositionResponse { };

            // Get the company
            var company = await _jobPositionRepository.GetCompany(companyId);

            // Validation
            if (company == null)
            {
                rs.Message = "The job position couldn't be created, there is no associated company";
                rs.Success = false;
                return rs;
            }

            // Create the new JobPosition
            var newJobPosition = new JobPosition
            {
                JobTitle = rq.JobTitle,
                JobDescription = rq.JobDescription,
                Location = rq.Location,
                CreatedDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(90),
            };

            // Add the JobPosition
            _jobPositionRepository.AddJobPosition(company, newJobPosition);

            // Return
            rs.Success = _jobPositionRepository.SaveChange();
            rs.Message = "The job position has been created correctly";
            return rs;
        }
    }
}
