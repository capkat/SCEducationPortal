using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCEducationPortal.Business.IEngines;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEducationEngine _educationEngine;
        private readonly ICategoryEngine _categoryEngine;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IEducationEngine educationEngine, ICategoryEngine categoryEngine)
        
        {
            _logger = logger;
            _educationEngine = educationEngine;
            _categoryEngine = categoryEngine;
        }



        public IActionResult Index()
        {
            ViewBag.CategoryList = _categoryEngine.GetCategories();
            var dataList = _educationEngine.GetEducations(0,50);

            return View(dataList);
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
    }
}
