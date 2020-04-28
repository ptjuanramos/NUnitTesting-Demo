using NUnit.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastServiceResponse> GetWeatherForecastFor(string query);
    }
}
