using ApiBolsaTrabajoUTN.API.Data;
using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    public class CareerController : Repository, ICareerController
    {
        public CareerController(BolsaTrabajoContext bolsaTrabajoContext) : base(bolsaTrabajoContext)
        {

        }
        public Career? GetCareerById(int CareerId)
        {
            return _bolsaTrabajoContext.Careers.Find(CareerId);
        }
    }
}
