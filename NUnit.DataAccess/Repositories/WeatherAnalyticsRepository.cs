using NUnit.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnit.DataAccess.Repositories
{
    public class WeatherAnalyticsRepository : IWeatherAnalyticsRepository
    {
        public decimal WeirdCalculation()
        {
            //Imagine that this is a db call...
            return decimal.MaxValue;
        }
    }
}
