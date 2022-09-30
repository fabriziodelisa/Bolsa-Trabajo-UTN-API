using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApiBolsaTrabajoUTN.API.Data.JobPositions
{
    public class JobPositionRepository : Repository, IJobPositionRepository
    {
        private readonly UserManager<User> _companyManager;
        public JobPositionRepository(BolsaTrabajoContext bolsaTrabajoContext, UserManager<User> companyManager) : base(bolsaTrabajoContext)
        {
            _companyManager = companyManager;
        }

        public async Task<User> GetCompany(string companyId)
        {
            var company = await _companyManager.FindByIdAsync(companyId);
            return company;
        }

        public void AddJobPosition(User company, JobPosition newJobPosition)
        {
            //company.JobPositions.Add(newJobPosition);
        }
    }
}
