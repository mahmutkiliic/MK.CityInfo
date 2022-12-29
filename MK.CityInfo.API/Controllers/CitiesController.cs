using AutoMapper;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using MK.CityInfo.API.Models;
using MK.CityInfo.API.Services;
using System.Text.Json;

namespace MK.CityInfo.API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {        
        private readonly ICityInfoRepository _repository;
        private readonly IMapper _mapper;
        const int maxCitiesPageSize = 20;

        public CitiesController(ICityInfoRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*
         * If names are different in your query string, you can pass like this...
         * [FromQuery(Name ="filteronname")] string? name*/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities(
             string? name, string? searchQuery, int pageNumber = 1, int pageSize=10)
        {
            if(pageSize > maxCitiesPageSize)
            {
                pageSize = maxCitiesPageSize;
            }

            var (cityEntities, paginationMetadata) = await _repository
                .GetCitiesAsync(name,
                                searchQuery,
                                pageNumber,
                                pageSize);

            Response.Headers.Add("X-Pagination",
                                 JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
                        
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
