using GetTemp;
using GetTempBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetTempService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TempItem> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new TempItem
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Temperature")]
        public double GetTemp(DateTime date, double lat, double lon)
        {
            date = DateTime.Today;
            lat = 32.0745;
            lon = 34.79213;
            //TemperatureDto temp = new GetTempBusinessLayer.TemperatureDto();
            GetTempBusinessLayer.Handlers.TemperatureHandler handler = new GetTempBusinessLayer.Handlers.TemperatureHandler();
            TemperatureDto temp = handler.HandleIncomingRequest(date, lat, lon);
            return temp.TemperatureC;
        }

        
    }

}
