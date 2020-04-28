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

            //Mocking IWeatherForecastService
        }


        #region withoutMocking
        [Test]
        public void GetTemperatureDescription_WhenLessThan20_Cold()
        {
            string expectedValue = "COLD";
            string result = weatherForecastManager.GetTemperatureDescription(19);
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void GetTemperatureDescription_WhenGreaterThan20LessThan30_Medium()
        {
            string expectedValue = "MEDIUM";
            string result = weatherForecastManager.GetTemperatureDescription(25);
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void GetTemperatureDescription_WhenGreaterThan30_Hot()
        {
            string expectedValue = "HOT";
            string result = weatherForecastManager.GetTemperatureDescription(35);
            Assert.AreEqual(expectedValue, result);
        }
        #endregion

        #region withMocking

        #endregion
    }
}