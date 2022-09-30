using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.Data.Careers
{
    public class CareerRepository : Repository, ICareerRepository
    {
        public CareerRepository(BolsaTrabajoContext bolsaTrabajoContext) : base(bolsaTrabajoContext)
        {
        }

        public Career? GetCareer(int careerId)
        {
            return _bolsaTrabajoContext.Careers.FirstOrDefault(c => c.Id == careerId);
        }

        public IEnumerable<Career> GetAllCareers()
        {
            return _bolsaTrabajoContext.Careers.OrderBy(x => x.Name).ToList();
        }

        public void DeleteCareer(int careerId)
        {
            var career = _bolsaTrabajoContext.Careers.Find(careerId);
            if (career != null)
                _bolsaTrabajoContext.Careers.Remove(career);
        }
        public void AddCareer(Career career)
        {
            _bolsaTrabajoContext.Careers.Add(career);
        }
        public void UpdateCareer(Career careerToUpdate)
        {
            _bolsaTrabajoContext.Entry(careerToUpdate).State = EntityState.Modified;
        }
    }
}
