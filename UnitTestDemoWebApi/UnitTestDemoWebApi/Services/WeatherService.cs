using UnitTestDemoWebApi.DAL;
using UnitTestDemoWebApi.Models;

namespace UnitTestDemoWebApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WebApiContext _context;

        //WeatherService constructor
        public WeatherService(WebApiContext context)
        {
            _context = context;
        }

        public async Task<WeatherForecast> GetWeatherForecastAsync(int id)
        {
            var weatherForecasts = await _context.GetMockDataAsync.ToListAsync();
            var weatherForecast = weatherForecasts.FirstOrDefault(x => x.Id == id, null);

            if (weatherForecast == null)
            {
                return new WeatherForecast
                {
                    Id = -1,
                    Summary = "not found!"

                };
            }

            return weatherForecast;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
        {
            return await _context.GetMockDataAsync.ToListAsync();
        }


    }
}
