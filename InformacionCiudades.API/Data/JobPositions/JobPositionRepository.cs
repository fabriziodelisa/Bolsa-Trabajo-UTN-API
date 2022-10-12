using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public IQueryable<JobPosition> GetAllJobPositions()
        {
            return _bolsaTrabajoContext.JobPositions.Include(x => x.Company).AsQueryable();
        }

        public IQueryable<JobPosition> GetCompanyJobPositions(string companyId)
        {
            return _bolsaTrabajoContext.JobPositions.Where(x => x.CompanyId == companyId).AsQueryable();
        }

        public JobPosition GetJobPosition(int jobPositionId)
        {
            return _bolsaTrabajoContext.JobPositions.FirstOrDefault(x => x.Id == jobPositionId);
        }
    }
}
