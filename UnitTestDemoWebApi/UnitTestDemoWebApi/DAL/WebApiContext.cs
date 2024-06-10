using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitTestDemoWebApi.Models;

namespace UnitTestDemoWebApi.DAL
{
    public class WebApiContext : DbContext
    {
        public WebApiContext (DbContextOptions<WebApiContext> options)
            : base(options)
        {
        }

        public DbSet<UnitTestDemoWebApi.Models.WeatherForecast> WeatherForecast { get; set; } = default!;
    }
}
