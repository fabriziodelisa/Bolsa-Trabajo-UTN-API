using ApiBolsaTrabajoUTN.API.Data.Interfaces;
using ApiBolsaTrabajoUTN.API.Models.Career;
using ApiBolsaTrabajoUTN.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [ApiController]
    //    [Authorize]
    [Route("api/Careers")]
    public class CareerController : ControllerBase
    {
        private readonly ICareerRepository _careerRepository;
        private readonly ICareerService _careerService;
        private readonly IMapper _mapper;
        public CareerController(ICareerService careerService, ICareerRepository careerRepository, IMapper mapper)
        {
            _careerRepository = careerRepository;
            _careerService = careerService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CareerDTO>> GetCarrers()
        {
            var careers = _careerService.GetAllCareers();
            return Ok(careers);
        }

        [HttpGet("{id}", Name = "GetCareer")]
        public IActionResult GetCareer(int id)

        {
            var career = _careerRepository.GetCareer(id);
            if (career == null)
                return NotFound();

            return Ok(_mapper.Map<CareerDTO>(career));
        }

        [HttpPost]
        public ActionResult<CareerDTO> AddCareer(CareerToCreateDTO career)
        {
            var newCareer = _mapper.Map<Entities.Career>(career);

            _careerRepository.AddCareer(newCareer);

            _careerRepository.SaveChange();


            var careerToReturn = _mapper.Map<CareerDTO>(newCareer);

            return CreatedAtRoute(//CreatedAtRoute es para q devuelva 201, el 200 de post.
                "GetCareer", //El primer parámetro es el Name del endpoint que hace el Get
                new //El segundo los parametros q necesita ese endpoint
                {
                    id = careerToReturn.Id
                },
                careerToReturn);//El tercero es el objeto creado. 
        }

        [HttpPut]
        public ActionResult UpdateCareer(CareerToUpdateDTO careerToUpdate, int careerId)
        {
            _careerService.UpdateCareer(careerToUpdate, careerId);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCareer(int id)
        {
            _careerService.DeleteCareer(id);

            return NoContent();
        }

    }
}
