using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastsController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="weatherService">The weather service instance.</param>
        public WeatherForecastsController(ILogger<WeatherForecastsController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        /// <summary>
        /// Retrieves all weather forecasts.
        /// </summary>
        /// <returns>A list of weather forecasts.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecast()
        {
            var weatherForecasts = await _weatherService.GetWeatherForecastsAsync();

            return weatherForecasts.ToList();
        }

        /// <summary>
        /// Retrieves a weather forecast by ID.
        /// </summary>
        /// <param name="id">The ID of the weather forecast.</param>
        /// <returns>The weather forecast with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(int id)
        {
            var weatherForecast = await _weatherService.GetWeatherForecastAsync(id);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return weatherForecast;
        }
    }
}
