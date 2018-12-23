using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Entities;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class ExportData : IExportData
    {
        private IWeatherData _weatherData;
        public ExportData(IWeatherData weatherData)
        {
            _weatherData = weatherData;
        }

        public CustomFile GetTxtFile()
        {
            var weatherList = _weatherData.GetWeather();

            var filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Downloads\\Pogoda.txt";
            using (var sw = new StreamWriter(filePath))
            {
                foreach (var w in weatherList)
                {
                    sw.WriteLine(($"{w.Date}, {w.DayOfWeek}, {w.Temp}, {w.Wind}, {w.Clouds}, {w.Rain}, {w.Pressure}, {w.UV}"));
                }
            }

            var newFile = new CustomFile
            {
                FileContents = File.ReadAllBytes(filePath),
                ContentType = "text/plain",
                FileName = "Pogoda.txt"
            };
            return newFile;
        }

        public CustomFile GetXlsxFile()
        {
            var weatherList = _weatherData.GetWeather();

            var filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Downloads\\Pogoda.xlsx";

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Pogoda");

            ws.Cell(1, 1).Value = "Dzień";
            ws.Cell(1, 2).Value = "Dzień tygodnia";
            ws.Cell(1, 3).Value = "Średnia temperatura";
            ws.Cell(1, 4).Value = "Wiatr";
            ws.Cell(1, 5).Value = "Zachmurzenie";
            ws.Cell(1, 6).Value = "Opady";
            ws.Cell(1, 7).Value = "Ciśnienie";
            ws.Cell(1, 8).Value = "Promieniowanie UV";
            ws.Cell(2, 1).Value = weatherList.AsEnumerable();

            ws.Range(1, 1, 1, 8).AddToNamed("Titles");
            var titlesStyle = wb.Style;
            titlesStyle.Font.Bold = true;
            titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            wb.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;
            ws.Columns().AdjustToContents();

            wb.SaveAs(filePath);

            var newFile = new CustomFile
            {
                FileContents = File.ReadAllBytes(filePath),
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                FileName = "Pogoda.xlsx"
            };
            return newFile;
        }
    }
}
