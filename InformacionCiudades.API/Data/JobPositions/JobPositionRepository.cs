using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.JobPosition;
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
            return _bolsaTrabajoContext.JobPositions.Include(x => x.Company).Include(x => x.Career).AsQueryable();
        }

        public IQueryable<JobPosition> GetCompanyJobPositions(string companyId)
        {
            return _bolsaTrabajoContext.JobPositions.Include(x => x.StudentsWhoApplied).Where(x => x.CompanyId == companyId).AsQueryable();
        }

        public JobPosition GetJobPosition(int jobPositionId)
        {
            return _bolsaTrabajoContext.JobPositions.Include(x => x.StudentsWhoApplied).FirstOrDefault(x => x.Id == jobPositionId);
        }

        public bool UpdateJobPosition(UpdateJobPositionRequest rq)
        {
            var jobPosition = _bolsaTrabajoContext.JobPositions.FirstOrDefault(x => x.Id == rq.JobPositionId);
            jobPosition.JobTitle = rq.JobTitle;
            jobPosition.JobDescription = rq.JobDescription;
            jobPosition.Location = rq.Location;
            return SaveChange();
        }

        public List<Student> GetStudentsThatAppliedToJobPosition(int jobPositionId)
        {
            var jobPositions = _bolsaTrabajoContext.JobPositions.Include(x => x.StudentsWhoApplied).FirstOrDefault(x => x.Id == jobPositionId);
            return jobPositions.StudentsWhoApplied;
        }

        public List<JobPosition> GetJobAppliesOfStudent(string studentId)
        {
            var student = _bolsaTrabajoContext.students.Include(x => x.JobApplies).FirstOrDefault(x => x.Id == studentId);
            return student.JobApplies;
        }
    }
}
