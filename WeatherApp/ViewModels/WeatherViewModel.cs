using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Entities;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel
    {
        public List<Weather> WeatherList { get; set; }
        public string CurrentDate { get; set; }
    }
}
