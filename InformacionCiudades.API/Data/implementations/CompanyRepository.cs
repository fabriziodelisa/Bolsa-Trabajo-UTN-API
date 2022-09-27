using ApiBolsaTrabajoUTN.API.Data.Interfaces;
using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;

namespace ApiBolsaTrabajoUTN.API.Data.implementations
{
    public class CompanyRepository : Repository, ICompanyRepository
    {        
        public CompanyRepository(BolsaTrabajoContext bolsaTrabajoContext) : base(bolsaTrabajoContext)
        {
        }

        public Company? GetInfo(string id)
        {
            return _bolsaTrabajoContext.Companies.FirstOrDefault(c => c.Id == id);
        }

    }
}
