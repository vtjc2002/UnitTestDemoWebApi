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

        /// <summary>
        /// Retrieves the weather forecast for a given ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the weather forecast to retrieve.</param>
        /// <returns>The weather forecast with the specified ID.</returns>
        public async Task<WeatherForecast> GetWeatherForecastAsync(int id)
        {
            var weatherForecasts = await _context.GetMockDataAsync.ToListAsync();
            var weatherForecast = weatherForecasts.FirstOrDefault(x => x.Id == id, null);

            return weatherForecast;
        }

        /// <summary>
        /// Retrieves the weather forecasts asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of weather forecasts.</returns>
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
        {
            return await _context.GetMockDataAsync.ToListAsync();
        }

        /// <summary>
        /// Adds a new weather forecast asynchronously.
        /// </summary>
        /// <param name="weatherForecast">The weather forecast to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added weather forecast.</returns>
        public async Task<WeatherForecast> AddWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            try
            {
            return await _context.AddWeatherForecastAsync(weatherForecast);

            }
            catch (Exception ex)
            {
            _logger.LogError(ex, "An error occurred while adding the weather forecast.");
            throw; // rethrow the exception to be handled by the caller
            }
        }



    }
}
