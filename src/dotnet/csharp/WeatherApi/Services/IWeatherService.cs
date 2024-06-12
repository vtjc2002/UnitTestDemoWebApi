using WeatherApi.Models;

namespace WeatherApi.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
        Task<WeatherForecast> GetWeatherForecastAsync(int id);
    }
}
