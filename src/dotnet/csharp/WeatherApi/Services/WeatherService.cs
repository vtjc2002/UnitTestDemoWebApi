using WeatherApi.DAL;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WebApiContext _context;
        private readonly ILogger<WeatherService> _logger;

        //WeatherService constructor
        public WeatherService(ILogger<WeatherService> logger, WebApiContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<WeatherForecast> GetWeatherForecastAsync(int id)
        {
            var weatherForecasts = await _context.GetMockDataAsync.ToListAsync();
            var weatherForecast = weatherForecasts.FirstOrDefault(x => x.Id == id, null);

            return weatherForecast;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
        {
            return await _context.GetMockDataAsync.ToListAsync();
        }


    }
}
