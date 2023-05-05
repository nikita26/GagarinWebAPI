namespace WeatherProvider.Interfaces
{
    public interface IWeatherProvider
    {
        Task<double?> GetAsync(DateTime date);
    }
}