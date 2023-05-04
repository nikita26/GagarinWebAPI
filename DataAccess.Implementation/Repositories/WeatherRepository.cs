using DataAccess.Interfaces;
using Entities;

namespace DataAccess.Implementation
{
    public class WeatherRepository : Repository<Weather,long>,IWeatherRepository
    {
        public WeatherRepository(DataBaseContext contex)
            : base(contex) { }
    }
}