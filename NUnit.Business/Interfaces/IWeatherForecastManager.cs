using System;
using System.Collections.Generic;
using System.Text;

namespace NUnit.Business.Interfaces
{
    public interface IWeatherForecastManager
    {
        string GetTemperatureDescription(int temperature);
    }
}
