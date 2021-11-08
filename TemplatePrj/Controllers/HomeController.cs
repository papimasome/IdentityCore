using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TemplatePrj.Models;

namespace TemplatePrj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("Home");
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        public IActionResult Index()
        {

          _logger.LogWarning("warning called");
          _logger.LogInformation(MyLogEvents.GetItem, "Hello, this is the index!");
           
            return View();
        }

        public IActionResult Privacy()
        {
            //throw new Exception();
            _logger.LogInformation("Privacy called");
           return View();
           
        }

    }
}
