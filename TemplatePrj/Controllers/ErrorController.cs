using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TemplatePrj.Models;

namespace TemplatePrj.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorController : Controller
    {

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("error/500")]
        public IActionResult Error500()
        {
            return View();
        }
        [Route("error/{code:int}")]
        public IActionResult Error(string code)

        {
            return View(new ErrorViewModel { ErrorStatusCode = code,RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }
    }
}