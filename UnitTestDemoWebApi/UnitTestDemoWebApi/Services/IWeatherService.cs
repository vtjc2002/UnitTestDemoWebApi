using UnitTestDemoWebApi.Models;

namespace UnitTestDemoWebApi.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecasts();
        Task<WeatherForecast> GetWeatherForecast(int id);
        Task<WeatherForecast> PutWeatherForecast(int id, WeatherForecast weatherForecast);
        Task<WeatherForecast> PostWeatherForecast(WeatherForecast weatherForecast);
        Task<WeatherForecast> DeleteWeatherForecast(int id);
    }
}
