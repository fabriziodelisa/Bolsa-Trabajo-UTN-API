using ApiBolsaTrabajoUTN.API.Data.Interfaces;
using ApiBolsaTrabajoUTN.API.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.Data.implementations
{
    public class Repository : IRepository
    {
        internal readonly BolsaTrabajoContext _bolsaTrabajoContext;
        public Repository(BolsaTrabajoContext bolsaTrabajoContext)
        {
            _bolsaTrabajoContext = bolsaTrabajoContext;
        }
        public bool SaveChanges()
        {
            return _bolsaTrabajoContext.SaveChanges() >= 0;
        }
    }
}