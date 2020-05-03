using NUnit.Business.Interfaces;
using NUnit.Common.Models;
using NUnit.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NUnit.Business
{
    public class WeatherForecastManager : IWeatherForecastManager
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastManager(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        private readonly string[] TemperatureDescriptions = { "COLD", "MEDIUM", "HOT" };

        public string GetTemperatureDescription(int temperature)
        {
            switch(temperature)
            {
                case int temp when temp < 20:
                    return TemperatureDescriptions[0];
                case int temp when temp > 20 && temp < 30:
                    return TemperatureDescriptions[1];
                case int temp when temp > 30:
                    return TemperatureDescriptions[2];
            }

            return string.Empty;
        }

        public async Task<int?> GetTemperatureFor(string query)
        {
            WeatherForecastServiceResponse response = await _weatherForecastService.GetWeatherForecastFor(query);
            if (response.current == null)
                return null;

            return response.current.temperature;
        }
    }
}
