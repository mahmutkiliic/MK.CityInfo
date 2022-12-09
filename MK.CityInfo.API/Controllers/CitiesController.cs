using Microsoft.AspNetCore.Mvc;
using MK.CityInfo.API.Models;

namespace MK.CityInfo.API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesDataStore _citiesDataStore;
        public CitiesController(CitiesDataStore citiesDataStore)
        {
            _citiesDataStore = citiesDataStore;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {

            return Ok(_citiesDataStore.Cities);
        }
        //public JsonResult GetCities()
        //{

        //    return new JsonResult(CitiesDataStore.Current.Cities);
        //}

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            //find city
            var cityToReturn = _citiesDataStore.Cities
                .FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
        //public JsonResult GetCity(int id)
        //{
        //    return new JsonResult(
        //        CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
        //}
    }
}
