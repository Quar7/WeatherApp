using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Entities
{
    public class Weather
    {
        public string Date { get; set; }
        public string DayOfWeek { get; set; }
        public string Temp { get; set; }
        public string Wind { get; set; }
        public string Clouds { get; set; }
        public string Rain { get; set; }
        public string Pressure { get; set; }
        public string UV { get; set; }
    }
}
