using ApiBolsaTrabajoUTN.API.Data.Interfaces;
using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Data.implementations
{
    public class UsersRepository : Repository, IUserRepository
    {        
        public UsersRepository(BolsaTrabajoContext bolsaTrabajoContext) : base(bolsaTrabajoContext)
        {
        }

        public Company? GetCompanyInfo(string id)
        {
            return _bolsaTrabajoContext.Companies.FirstOrDefault(c => c.Id == id);
        }

        public Student? GetStudentInfo(string id)
        {
            return _bolsaTrabajoContext.students.FirstOrDefault(s => s.Id == id);
        }

    }
}
