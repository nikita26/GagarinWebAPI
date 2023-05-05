using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases;

namespace GagarinWebAPI.Controllers
{
    [Authorize]
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
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(double))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type = typeof(string))]
        public async Task<IActionResult> MoskowWeather(string date)
        {
            var result = await _useCasesWeather.GetMoskowWeatherAsync(date);
            if(result.IsError)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(double))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SaveMoskowWeather(string date)
        {
            var result = await _useCasesWeather.SaveMoskowWeatherAsync(date);
            if (result.IsError)
                return BadRequest(result.ErrorMessage);

            return StatusCode(201,result.Value);
        }
    }
}