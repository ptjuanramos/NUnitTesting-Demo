using NUnit.Business;
using NUnit.Framework;
using NUnit.Services.Interfaces;

namespace NUnit.Test
{
    public class WeatherForecastManagerTest
    {
        private IWeatherForecastService weatherForecastService;
        private WeatherForecastManager weatherForecastManager;

        [SetUp]
        public void SetUp()
        {
            weatherForecastManager = new WeatherForecastManager(weatherForecastService);
        }

        [Test]
        public void GetTemperatureDescription_WhenLessThan20_Cold()
        {
            string expectedValue = "COLD";
            string result = weatherForecastManager.GetTemperatureDescription(19);
            Assert.AreEqual(expectedValue, result);
        }
    }
}