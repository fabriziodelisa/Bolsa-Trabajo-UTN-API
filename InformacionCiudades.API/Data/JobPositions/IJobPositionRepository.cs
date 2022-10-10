using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.JobPosition;

namespace ApiBolsaTrabajoUTN.API.Data.JobPositions
{
    public interface IJobPositionRepository : IRepository
    {
        public Task<Company> GetCompany(string companyId);
        public void AddJobPosition(Company company, JobPosition newJobPosition);
        public IQueryable<JobPosition> GetAllJobPositions();
    }
}
