using ApiBolsaTrabajoUTN.API.Data.Careers;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.Career;
using AutoMapper;

namespace ApiBolsaTrabajoUTN.API.Services.Careers
{
    public class CareerService : ICareerService
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IMapper _mapper;


        public CareerService(IMapper mapper, ICareerRepository careerRepository)
        {
            _careerRepository = careerRepository;
            _mapper = mapper;
        }

        public IEnumerable<CareerDTO> GetAllCareers()
        {
            var careers = _careerRepository.GetAllCareers();
            return _mapper.Map<IEnumerable<CareerDTO>>(careers);
        }

        public CareerDTO? GetCareer(int id)
        {
            var career = _careerRepository.GetCareer(id);
            return _mapper.Map<CareerDTO>(career);
        }

        public CareerDTO AddCareer(CareerToCreateDTO careerToCreateDTO)
        {
            var newCareer = _mapper.Map<Career>(careerToCreateDTO);
            return _mapper.Map<CareerDTO>(newCareer);
        }

        public void DeleteCareer(int careerId)
        {
            _careerRepository.DeleteCareer(careerId);
            _careerRepository.SaveChange();
        }
        public void UpdateCareer(CareerToUpdateDTO careerToUpdateDto, int careerId)
        {
            var careerToUpdate = _careerRepository.GetCareer(careerId);

            _mapper.Map(careerToUpdateDto, careerToUpdate);

            _careerRepository.UpdateCareer(careerToUpdate);
            _careerRepository.SaveChange();
        }
    }

}
