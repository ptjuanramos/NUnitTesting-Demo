using Newtonsoft.Json;
using NUnit.Services.Interfaces;
using NUnit.Common.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NUnit.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public async Task<WeatherForecastServiceResponse> GetWeatherForecastFor(string query)
        {
            string urlString = "http://api.weatherstack.com/current?access_key=afbb88264b90360e1647e9cbb182d4a3&query={0}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(string.Format(urlString, query));
                string responseAsString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<WeatherForecastServiceResponse>(responseAsString);
            }
        }
    }
}
