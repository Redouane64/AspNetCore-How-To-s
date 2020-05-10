using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UploadFile.Models;

namespace UploadFile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UploadFile()
        {
            return View(new UploadModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadFile([FromForm]UploadModel model)
        {
            if (model.File.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError(nameof(model.File), "File is too large.");
                return View();
            }

            if (!model.File.ContentType.StartsWith("text/"))
            {
                ModelState.AddModelError(nameof(model.File), "Invalid file format.");
                return View();
            }

            var content = new StreamReader(model.File.OpenReadStream()).ReadToEnd();
            return View("UploadResult", (model.Title, content));
        }
    }
}
