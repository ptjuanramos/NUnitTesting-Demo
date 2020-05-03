using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Business.Interfaces
{
    public interface IWeatherForecastManager
    {
        string GetTemperatureDescription(int temperature);
        Task<int?> GetTemperatureFor(string query);
    }
}
