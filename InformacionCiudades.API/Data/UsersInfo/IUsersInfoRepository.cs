using ApiBolsaTrabajoUTN.API.Entities;

namespace ApiBolsaTrabajoUTN.API.Data.UsersInfo
{
    public interface IUsersInfoRepository
    {
        public IQueryable<Company> GetAllCompanies();
        public IQueryable<Student> GetAllStudents();
    }
}
