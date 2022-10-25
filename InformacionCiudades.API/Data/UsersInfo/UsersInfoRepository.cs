using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.Data.UsersInfo
{
    public class UsersInfoRepository : Repository, IUsersInfoRepository
    {
        public UsersInfoRepository(BolsaTrabajoContext bolsaTrabajoContext) : base(bolsaTrabajoContext)
        {
        }

        public IQueryable<Company> GetAllCompanies()
        {
            return _bolsaTrabajoContext.Companies.AsQueryable();
        }

        public IQueryable<Student> GetAllStudents()
        {
            return _bolsaTrabajoContext.students.AsQueryable();
        }
    }
}
