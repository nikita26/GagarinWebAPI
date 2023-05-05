using System.Net.Http;
using System.Text.Json;
using WeatherProvider.Interfaces;

namespace WeatherProvider.Implementation
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly HttpClient _httpClient;

        public WeatherProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<double?> GetAsync(DateTime date)
        {
            var dateFormat = date.ToString("yyyy-MM-dd");
            string url = $"https://api.open-meteo.com/v1/forecast?latitude=55.75&longitude=37.62&hourly=temperature_2m&start_date={dateFormat}&end_date={dateFormat}";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            var openMeteoResponse = JsonSerializer.Deserialize<OpenMeteoResponse>(json);
            if (!openMeteoResponse.IsError)
                return openMeteoResponse.Hourly.Temperature[12];

            return null;
        }
    }
}