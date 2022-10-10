using ApiBolsaTrabajoUTN.API.Models.Career;

namespace ApiBolsaTrabajoUTN.API.Services.Careers
{
    public interface ICareerService
    {
        public IEnumerable<CareerDTO> GetAllCareers();
        public CareerDTO? GetCareer(int id);
        public CareerDTO AddCareer(CareerToCreateDTO careerToCreateDTO);
        public void DeleteCareer(int id);
        public void UpdateCareer(CareerToUpdateDTO careerToUpdateDto, int careerId);
    }
}
