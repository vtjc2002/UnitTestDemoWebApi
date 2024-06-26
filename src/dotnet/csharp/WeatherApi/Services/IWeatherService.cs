using WeatherApi.Models;

namespace WeatherApi.Services
{
    /// <summary>
    /// Represents a service for retrieving weather forecasts.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Retrieves a collection of weather forecasts asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of weather forecasts.</returns>
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();

        /// <summary>
        /// Retrieves a weather forecast asynchronously based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the weather forecast to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the weather forecast.</returns>
        Task<WeatherForecast> GetWeatherForecastAsync(int id);

        /// <summary>
        /// Adds a new weather forecast asynchronously.
        /// </summary>
        /// <param name="weatherForecast">The weather forecast to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added weather forecast.</returns>
        Task<WeatherForecast> AddWeatherForecastAsync(WeatherForecast weatherForecast);
    }
}
