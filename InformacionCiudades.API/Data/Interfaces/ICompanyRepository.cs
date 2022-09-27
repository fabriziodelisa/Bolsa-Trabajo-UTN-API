using ApiBolsaTrabajoUTN.API.Entities;

namespace ApiBolsaTrabajoUTN.API.Data.Interfaces
{
    public interface ICompanyRepository
    {
        public Company? GetInfo(string id);
    }
}
