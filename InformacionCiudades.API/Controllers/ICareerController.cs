using ApiBolsaTrabajoUTN.API.Entities;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    public interface ICareerController
    {
        public Career? GetCareerById(int CareerId);
    }
}
