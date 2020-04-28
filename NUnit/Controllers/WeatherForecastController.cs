using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Business.Interfaces;
using NUnit.Common.Models;
using NUnit.Services.Interfaces;

namespace NUnit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IWeatherForecastManager _weatherForecastManager;
        
        public WeatherForecastController(IWeatherForecastManager weatherForecastManager)
        {
            _weatherForecastManager = weatherForecastManager;
        }

        [HttpGet]
        public string GetTemperatureDescription(int temperature)
        {
            return _weatherForecastManager.GetTemperatureDescription(temperature);
        }

        [HttpGet]
        public async Task<WeatherForecastServiceResponse> GetWeatherForecast(string query)
        {
            return await _weatherForecastService.GetWeatherForecastFor(query);
        }
    }
}
