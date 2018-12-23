using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Entities;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class WeatherData : IWeatherData
    {
        public List<Weather> GetWeather()
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://pogoda.interia.pl/prognoza-dlugoterminowa-gdynia,cId,8052");

            var dateStringList = new List<string>();
            var dateNodeList = doc.DocumentNode.SelectNodes("//span[@class='date']").ToList();
            dateNodeList.ForEach(d => dateStringList.Add(d.InnerText));

            var dayOfWeekStringList = new List<string>();
            var dayOfWeekNodeList = doc.DocumentNode.SelectNodes("//span[@class='day']").ToList();
            dayOfWeekNodeList.ForEach(d => dayOfWeekStringList.Add(d.InnerText));

            var tempStringList = new List<string>();
            var tempNodeList = doc.DocumentNode.SelectNodes("//span[@class='weather-forecast-longterm-list-entry-forecast-temp']").ToList();
            tempNodeList.ForEach(d => tempStringList.Add(d.InnerText));

            var windStringList = new List<string>();
            var windNodeList = doc.DocumentNode.SelectNodes("//span[@class='weather-forecast-longterm-list-entry-wind-value']").ToList();
            windNodeList.ForEach(d => windStringList.Add(d.InnerText));

            var cloudsStringList = new List<string>();
            var cloudsNodeList = doc.DocumentNode.SelectNodes("//span[@class='weather-forecast-longterm-list-entry-cloudy-cloudy-value']").ToList();
            cloudsNodeList.ForEach(d => cloudsStringList.Add(d.InnerText));

            var rainStringList = new List<string>();
            var rainNodeList = doc.DocumentNode.SelectNodes("//span[@class='weather-forecast-longterm-list-entry-precipitation-value']").ToList();
            rainNodeList.ForEach(d => rainStringList.Add(d.InnerText));

            var pressureStringList = new List<string>();
            var pressureNodeList = doc.DocumentNode.SelectNodes("//span[@class='weather-forecast-longterm-list-entry-pressure-value']").ToList();
            pressureNodeList.ForEach(d => pressureStringList.Add(d.InnerText));

            var uvStringList = new List<string>();
            var uvNodeList = doc.DocumentNode.SelectNodes("//span[@class='weather-forecast-longterm-list-entry-sun-uv-value']").ToList();
            uvNodeList.ForEach(d => uvStringList.Add(d.InnerText));


            var weatherList = new List<Weather>();
            for (int i = 0; i < dateStringList.Count; i++)
            {
                var weather = new Weather();
                weather.Date = dateStringList[i];
                weather.DayOfWeek = dayOfWeekStringList[i];
                weather.Temp = tempStringList[i];
                weather.Wind = windStringList[i];
                weather.Clouds = cloudsStringList[i];
                weather.Rain = rainStringList[i];
                weather.Pressure = pressureStringList[i];
                weather.UV = uvStringList[i];

                weatherList.Add(weather);
            }
            return weatherList;
        }
    }
}
