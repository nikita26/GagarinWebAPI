using DataAccess.Interfaces;
using Entities;
using UseCases.Dto;

namespace UseCases
{
    public class UseCasesWeather
    {
        private readonly IWeatherRepository _weatherRepository;

        public UseCasesWeather(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public double GetMoskowWeather(DateTime date)
        {
            return 0;
        }
        public void SaveMoskowWeather(WeatherDto weather)
        {
            var newWeather = new Weather()
            {
                Id = weather.Id,
                Value = weather.Value,
                Date = weather.Date,
            };
            _weatherRepository.Add(newWeather);

        }
    }
}