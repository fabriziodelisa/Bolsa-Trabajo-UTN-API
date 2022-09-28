using ApiBolsaTrabajoUTN.API.Entities;

namespace ApiBolsaTrabajoUTN.API.Data.Interfaces
{
    public interface IUserRepository
    {
        public Company? GetCompanyInfo(string id);
        public Student? GetStudentInfo(string id);
    }
}
