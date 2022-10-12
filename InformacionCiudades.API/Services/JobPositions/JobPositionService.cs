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
                rs.Message = "La oferta laboral no pudo ser creada, no existe una empresa asociada";
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
            rs.Message = "La oferta laboral fue creada exitosamente";
            return rs;
        }

        public GetJobPositionsResponse GetAllJobPositions()
        {
            // Create response object
            var rs = new GetJobPositionsResponse { };

            // Get the company
            var jobPositions =  _jobPositionRepository.GetAllJobPositions().ToList();

            // Validation
            if (jobPositions.Count == 0)
            {
                rs.Message = "No se encontro ninguna oferta laboral";
                rs.Success = false;
                return rs;
            }

            rs.Data = jobPositions;

            // Return
            rs.Success = _jobPositionRepository.SaveChange();
            rs.Message = "Ofertas laborales retornadas correctamente";
            return rs;
        }

        public GetJobPositionsResponse GetCompanyJobPositions(string companyId)
        {
            // Create response object
            var rs = new GetJobPositionsResponse { };

            // Get the company
            var jobPositions = _jobPositionRepository.GetCompanyJobPositions(companyId).ToList();

            // Validation
            if (jobPositions.Count == 0)
            {
                rs.Message = "No se encontro ninguna oferta laboral";
                rs.Success = false;
                return rs;
            }

            rs.Data = jobPositions;

            // Return
            rs.Success = _jobPositionRepository.SaveChange();
            rs.Message = "Ofertas laborales retornadas correctamente";
            return rs;
        }
    }
}
