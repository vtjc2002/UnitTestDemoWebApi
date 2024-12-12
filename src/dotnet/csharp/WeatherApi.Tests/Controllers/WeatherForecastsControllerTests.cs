using Xunit;
using WeatherApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WeatherApi.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WeatherApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers.Tests
{
    public class WeatherForecastsControllerTests
    {
        /// <summary>
        /// Test when get weather by id is not found
        /// </summary>
        [Fact()]
        public async Task GetWeatherForecastNotFound()
        {
            //Setup 
            var service = new Mock<IWeatherService>();

            var controller = new WeatherForecastsController(new NullLogger<WeatherForecastsController>(), service.Object);

            WeatherForecast weather = null;

            service.Setup(x => x.GetWeatherForecastAsync(It.IsAny<int>())).ReturnsAsync(weather);

            //Act
            var result = await controller.GetWeatherForecast(100);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        /// <summary>
        /// Test when get weather by id is found
        /// </summary>
        [Fact()]
        public async Task GetWeatherForecastFound()
        {
            //Setup 
            var service = new Mock<IWeatherService>();

            var controller = new WeatherForecastsController(new NullLogger<WeatherForecastsController>(), service.Object);

            WeatherForecast weather = new WeatherForecast { Id = 1, Date = DateTime.Now, TemperatureC = 20, Summary = "Test" };

            service.Setup(x => x.GetWeatherForecastAsync(It.IsAny<int>())).ReturnsAsync(weather);

            //Act
            var result = await controller.GetWeatherForecast(1);

            //Assert
            Assert.IsType<WeatherForecast>(result.Value);
        }

        /// <summary>
        /// Test when adding a weather forecast is successful
        /// </summary>
        [Fact()]
        public async Task AddWeatherForecastSuccess()
        {
            // Setup
            var service = new Mock<IWeatherService>();
            var controller = new WeatherForecastsController(new NullLogger<WeatherForecastsController>(), service.Object);
            WeatherForecast newWeather = new WeatherForecast { Id = 2, Date = DateTime.Now, TemperatureC = 25, Summary = "Sunny" };

            service.Setup(x => x.AddWeatherForecastAsync(It.IsAny<WeatherForecast>())).ReturnsAsync(newWeather);

            // Act
            var result = await controller.AddWeatherForecast(newWeather);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<WeatherForecast>(actionResult.Value);
            Assert.Equal(newWeather.Id, returnValue.Id);
        }

        /// <summary>
        /// Test when adding a weather forecast fails due to invalid input
        /// </summary>
        [Fact()]
        public async Task AddWeatherForecastFailure()
        {
            // Setup
            var service = new Mock<IWeatherService>();
            var controller = new WeatherForecastsController(new NullLogger<WeatherForecastsController>(), service.Object);
            WeatherForecast invalidWeather = null; // Simulating invalid input

            service.Setup(x => x.AddWeatherForecastAsync(It.IsAny<WeatherForecast>())).ReturnsAsync(invalidWeather);

            // Act
            var result = await controller.AddWeatherForecast(invalidWeather);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}