using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.JobPosition;

namespace ApiBolsaTrabajoUTN.API.Data.JobPositions
{
    public interface IJobPositionRepository : IRepository
    {
        public Task<User> GetCompany(string companyId);
        public void AddJobPosition(User company, JobPosition newJobPosition);
    }
}
