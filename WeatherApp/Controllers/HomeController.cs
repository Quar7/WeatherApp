using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherData _weatherData;
        public HomeController(IWeatherData weatherData)
        {
            _weatherData = weatherData;
        }


        public IActionResult Index()
        {
            var model = new WeatherViewModel();
            model.WeatherList = _weatherData.GetWeather();
            model.CurrentDate = DateTime.Now.ToShortDateString();
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
