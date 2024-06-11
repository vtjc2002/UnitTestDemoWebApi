using UnitTestDemoWebApi.Models;

namespace UnitTestDemoWebApi.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
        Task<WeatherForecast> GetWeatherForecastAsync(int id);
    }
}
