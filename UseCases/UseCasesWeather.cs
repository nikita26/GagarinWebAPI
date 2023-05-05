using DataAccess.Interfaces;
using Entities;
using System.Text.Json;
using UseCases.Dto;
using WeatherProvider.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UseCases
{
    public class UseCasesWeather
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IWeatherProvider _weatherProvider;
        private readonly HttpClient _httpClient;
        public UseCasesWeather(IWeatherRepository weatherRepository,IWeatherProvider weatherProvider)
        {
            _weatherRepository = weatherRepository;
            _weatherProvider = weatherProvider;
        }

        public async Task<GetMoskowWeatherResultDto> GetMoskowWeatherAsync(string dateStr)
        {
            var result = new GetMoskowWeatherResultDto();
            try
            {
                var date = DateTime.ParseExact(dateStr, "dd.MM.yyyy", null).Date;
                var temp = await _weatherProvider.GetAsync(date);
                if(temp != null) 
                    result.Value = (double)temp;
                else
                {
                    result.IsError = true;
                    result.ErrorMessage = "Error API request";
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public async Task<GetMoskowWeatherResultDto> SaveMoskowWeatherAsync(string dateStr)
        {
            var result = new GetMoskowWeatherResultDto();
            try
            {
                var date = DateTime.ParseExact(dateStr, "dd.MM.yyyy", null).Date;
                var temp = await _weatherProvider.GetAsync(date);
                if (temp != null)
                {
                    result.Value = (double)temp;
                    var entity = _weatherRepository.Add(new Weather() { Value = (double)temp, Date = date.ToUniversalTime() });
                    await _weatherRepository.SaveAsync();
                }
                else
                {
                    result.IsError = true;
                    result.ErrorMessage = "Error API request";
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}