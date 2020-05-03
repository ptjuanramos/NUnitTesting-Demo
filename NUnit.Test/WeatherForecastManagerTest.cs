using Moq;
using NUnit.Business;
using NUnit.Common.Models;
using NUnit.Framework;
using NUnit.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NUnit.Test
{
    public class WeatherForecastManagerTest
    {
        private WeatherForecastServiceResponse weatherForecastServiceResponse;
        private Mock<IWeatherForecastService> weatherForecastServiceMocked;
        private WeatherForecastManager weatherForecastManager;

        [SetUp]
        public void SetUp()
        {
            weatherForecastServiceResponse = new WeatherForecastServiceResponse();
            weatherForecastServiceMocked = new Mock<IWeatherForecastService>();
            weatherForecastManager = new WeatherForecastManager(weatherForecastServiceMocked.Object);
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
        
        private void PrepareMockedWeatherResponse(Current current)
        {
            weatherForecastServiceResponse.current = current;
            weatherForecastServiceMocked.Setup(m => m.GetWeatherForecastFor(It.IsAny<string>())) //It.IsAny: Any argument for testing is 
                .Returns(Task.FromResult(weatherForecastServiceResponse)); //Task.FromResult is used because service method returns a new Task
        }

        [Test]
        public void WhenResponseModelCurrentNull_GetTemperatureFor_ReturnsNull()
        {
            PrepareMockedWeatherResponse(null);
            Assert.IsFalse(weatherForecastManager.GetTemperatureFor("any query").Result.HasValue); //proves that doesn't have a value
        }

        [Test]
        public void WhenResponseModelCurrentHasTempValue_GetTemperatureFor_ReturnsTempValue()
        {
            Current notNullCurrentWithTemp = new Current
            {
                temperature = 32
            };

            PrepareMockedWeatherResponse(notNullCurrentWithTemp);
            Assert.IsTrue(weatherForecastManager.GetTemperatureFor("any query").Result.HasValue);
        }
        #endregion

        #region other-testing
        [Test]
        public void ThrowExceptionToPass()
        {
            Assert.Throws<Exception>(() => throw new Exception());
        }
        #endregion
    }
}