using ApiBolsaTrabajoUTN.API.Data.Interfaces;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models.Career;
using AutoMapper;

namespace ApiBolsaTrabajoUTN.API.Services
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

        public void DeleteCareer(int id)
        {
           _careerRepository.DeleteCareer(id);
            _careerRepository.SaveChanges();
        }
    }
}
