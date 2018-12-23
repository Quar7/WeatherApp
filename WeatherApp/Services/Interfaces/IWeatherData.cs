using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Entities;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherData
    {
        List<Weather> GetWeather();
    }
}
