using Microsoft.AspNetCore.Mvc;
using UseCases;

namespace GagarinWebAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly UseCasesWeather _useCasesWeather;

        public WeatherController(ILogger<WeatherController> logger, 
            UseCasesWeather useCasesWeather)
        {
            var d = DateTime.Now.ToString();
            _logger = logger;
            _useCasesWeather = useCasesWeather;
        }

        [HttpGet]
        public IActionResult MoskowWeather(DateTime date)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult SaveMoskowWeather()
        {
            return BadRequest();
        }
    }
}