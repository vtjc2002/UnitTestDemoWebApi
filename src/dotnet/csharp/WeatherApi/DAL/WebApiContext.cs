using WeatherApi.Models;

namespace WeatherApi.DAL
{
    public class WebApiContext
    {
        
        private IList<WeatherForecast> _weatherForecasts;

        public WebApiContext()
        {
            // create a list of mock weather forecasts
            _weatherForecasts = new List<WeatherForecast>
            {
                new WeatherForecast { Id = 1, Date = DateTime.Now, TemperatureC = 25, Summary = "Hot" },
                new WeatherForecast { Id = 2, Date = DateTime.Now.AddHours(-1), TemperatureC = 15, Summary = "Cold" },
                new WeatherForecast { Id = 3, Date = DateTime.Now.AddHours(-0.5), TemperatureC = 20, Summary = "Warm" },
                new WeatherForecast { Id = 4, Date = DateTime.Now.AddHours(-0.2), TemperatureC = 30, Summary = "Very Hot" },
                new WeatherForecast { Id = 5, Date = DateTime.Now.AddHours(-2), TemperatureC = 10, Summary = "Very Cold" },
                new WeatherForecast { Id = 6, Date = DateTime.Now, TemperatureC = 22, Summary = "Normal" },
                new WeatherForecast { Id = 7, Date = DateTime.Now, TemperatureC = 18, Summary = "Normal" },
                new WeatherForecast { Id = 8, Date = DateTime.Now, TemperatureC = 28, Summary = "Hot" },
                new WeatherForecast { Id = 9, Date = DateTime.Now, TemperatureC = 32, Summary = "Very Hot" }
            };
        }

        /// <summary>
        /// Get mock data asynchronously.
        /// </summary>
        public IAsyncEnumerable<WeatherForecast> GetMockDataAsync => _weatherForecasts.ToAsyncEnumerable();

        /// <summary>
        /// Add a new weather forecast to weatherForecasts.
        /// </summary>
        public Task<WeatherForecast> AddWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            // get the last id
            int lastId = _weatherForecasts.Last().Id;

            // set the new id
            weatherForecast.Id = lastId + 1;

            // add the new weather forecast
            _weatherForecasts.Add(weatherForecast);

            return Task.FromResult(weatherForecast);
        }
    }
}
