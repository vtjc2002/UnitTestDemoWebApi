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

            var weather = new WeatherForecast { Id = -1, Summary = "Not Found!" };

            service.Setup(x => x.GetWeatherForecastAsync(It.IsAny<int>())).ReturnsAsync(weather);

            //Act
            var result = await controller.GetWeatherForecast(100);

            //Assert
            Assert.Equal(-1, result.Value?.Id);
            Assert.Equal("Not Found!", result.Value?.Summary);
        }
    }
}