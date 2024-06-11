using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTestDemoWebApi.Models;
using UnitTestDemoWebApi.Services;

namespace UnitTestDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {

        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastsController> _logger;

        public WeatherForecastsController(ILogger<WeatherForecastsController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        // GET: api/WeatherForecasts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecast()
        {
            var weatherForecasts = await _weatherService.GetWeatherForecastsAsync();

            return weatherForecasts.ToList();
        }

        // GET: api/WeatherForecasts/5
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
