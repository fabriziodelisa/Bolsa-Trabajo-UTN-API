using ApiBolsaTrabajoUTN.API.Models.JobPosition;

namespace ApiBolsaTrabajoUTN.API.Services.JobPositions
{
    public interface IJobPositionService
    {
        public Task<CreateJobPositionResponse> AddJobPosition(string companyId, CreateJobPositionRequest rq);
        public GetJobPositionsResponse GetAllJobPositions();
        public GetJobPositionsResponse GetCompanyJobPositions(string companyId);
        public GetJobPositionsResponse GetJobPosition(int jobPositionId);
        public UpdateJobPositionResponse UpdateJobPosition(UpdateJobPositionRequest rq);
    }
}
