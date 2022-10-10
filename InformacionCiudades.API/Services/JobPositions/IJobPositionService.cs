using ApiBolsaTrabajoUTN.API.Models.JobPosition;

namespace ApiBolsaTrabajoUTN.API.Services.JobPositions
{
    public interface IJobPositionService
    {
        public Task<CreateJobPositionResponse> AddJobPosition(string companyId, CreateJobPositionRequest rq);
        public GetAllJobPositionsResponse GetAllJobPositions();
    }
}
