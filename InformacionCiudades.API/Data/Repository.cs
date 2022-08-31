using ApiBolsaTrabajoUTN.API.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.Data
{
    public class Repository : IRepository
    {
        internal readonly BolsaTrabajoContext _bolsaTrabajoContext;
        public Repository(BolsaTrabajoContext bolsaTrabajoContext)
        {
            this._bolsaTrabajoContext = bolsaTrabajoContext;
        }
        public bool SaveChanges()
        {
            return (_bolsaTrabajoContext.SaveChanges() >= 0);
        }
    }
}