using UnitTestDemoWebApi.Models;

namespace UnitTestDemoWebApi.DAL
{
    public class WebApiContext
    {
        public IAsyncEnumerable<WeatherForecast> GetMockDataAsync
        {
            get
            {
                return new List<WeatherForecast>
                {
                    new WeatherForecast { Id = 1, Date = DateTime.Now, TemperatureC = 25, Summary = "Hot" },
                    new WeatherForecast { Id = 2, Date = DateTime.Now, TemperatureC = 15, Summary = "Cold" },
                    new WeatherForecast { Id = 3, Date = DateTime.Now, TemperatureC = 20, Summary = "Warm" },
                    new WeatherForecast { Id = 4, Date = DateTime.Now, TemperatureC = 30, Summary = "Very Hot" },
                    new WeatherForecast { Id = 5, Date = DateTime.Now, TemperatureC = 10, Summary = "Very Cold" },
                    new WeatherForecast { Id = 6, Date = DateTime.Now, TemperatureC = 22, Summary = "Normal" },
                    new WeatherForecast { Id = 7, Date = DateTime.Now, TemperatureC = 18, Summary = "Normal" },
                    new WeatherForecast { Id = 8, Date = DateTime.Now, TemperatureC = 28, Summary = "Hot" },
                    new WeatherForecast { Id = 9, Date = DateTime.Now, TemperatureC = 32, Summary = "Very Hot" }
                }.ToAsyncEnumerable();
            }
        }
    }
}
