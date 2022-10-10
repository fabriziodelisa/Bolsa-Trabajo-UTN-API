using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApiBolsaTrabajoUTN.API.Data.JobPositions
{
    public class JobPositionRepository : Repository, IJobPositionRepository
    {
        private readonly UserManager<User> _userManager;
        public JobPositionRepository(BolsaTrabajoContext bolsaTrabajoContext, UserManager<User> userManager) : base(bolsaTrabajoContext)
        {
            _userManager = userManager;
        }

        public async Task<Company> GetCompany(string companyId)
        {
            var company = (Company)await _userManager.FindByIdAsync(companyId);
            return company;
        }

        public void AddJobPosition(Company company, JobPosition newJobPosition)
        {
            company.JobPositions.Add(newJobPosition);
        }
    }
}
