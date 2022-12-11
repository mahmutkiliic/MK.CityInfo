using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MK.CityInfo.API.Models;
using MK.CityInfo.API.Services;

namespace MK.CityInfo.API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {        
        private readonly ICityInfoRepository _repository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities()
        {
            var cityEntities = await _repository.GetCitiesAsync();
            
            var results = new List<CityWithoutPointsOfInterestDto>();
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
            
            //without automapper
            //foreach (var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointsOfInterestDto
            //    {
            //        Id = cityEntity.Id,
            //        Description = cityEntity.Description,
            //        Name = cityEntity.Name
            //    });
            //}
           
            //return Ok(results);
            //return Ok(_citiesDataStore.Cities);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(
            int id, bool includePointsOfInterest = false)
        {
            var city = await _repository.GetCityAsync(id, includePointsOfInterest);

            if(city == null)
            {
                return NotFound();
            }
            if(includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }


            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
            
        }
       
    }
}
