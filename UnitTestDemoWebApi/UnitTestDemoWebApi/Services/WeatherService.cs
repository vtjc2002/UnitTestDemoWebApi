using Microsoft.EntityFrameworkCore;
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

        public async Task<WeatherForecast> GetWeatherForecast(int id)
        {
            var weatherForecast = await _context.WeatherForecast.FindAsync(id);

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

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            return await _context.WeatherForecast.ToListAsync();
        }

        #region Not implemented
        public Task<WeatherForecast> PostWeatherForecast(WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> PutWeatherForecast(int id, WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> DeleteWeatherForecast(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
