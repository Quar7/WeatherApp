using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    public class FileController : Controller
    {
        private IExportData _exportData;

        public FileController(IExportData exportToFile)
        {
            _exportData = exportToFile;
        }


        public IActionResult ExportToTxt()
        {
            var file = _exportData.GetTxtFile();
            return File(file.FileContents, file.ContentType, file.FileName);
        }

        public IActionResult ExportToXlsx()
        {
            var file = _exportData.GetXlsxFile();
            return File(file.FileContents, file.ContentType, file.FileName);
        }
    }
}
