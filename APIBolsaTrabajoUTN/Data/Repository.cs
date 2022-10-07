using ApiBolsaTrabajoUTN.API.Data;
using ApiBolsaTrabajoUTN.API.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.Data
{
    public class Repository : IRepository
    {
        internal readonly BolsaTrabajoContext _bolsaTrabajoContext;
        public Repository(BolsaTrabajoContext bolsaTrabajoContext)
        {
            _bolsaTrabajoContext = bolsaTrabajoContext;
        }
        public bool SaveChange()
        {
            return _bolsaTrabajoContext.SaveChanges() >= 0;
        }
    }
}