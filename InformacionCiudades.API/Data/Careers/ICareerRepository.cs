using ApiBolsaTrabajoUTN.API.Entities;

namespace ApiBolsaTrabajoUTN.API.Data.Careers
{
    public interface ICareerRepository : IRepository
    {
        public Career? GetCareer(int careerId);
        public IEnumerable<Career> GetAllCareers();
        public void AddCareer(Career career);
        public void DeleteCareer(int careerId);
        public void UpdateCareer(Career careerToUpdate);
    }
}
