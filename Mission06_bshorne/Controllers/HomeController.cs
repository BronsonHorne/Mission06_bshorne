using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_bshorne.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_bshorne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieApplicationContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieApplicationContext x)
        {
            _logger = logger;
            _movieContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movie(ApplicationResponse ar)
        {
            _movieContext.Add(ar);
            _movieContext.SaveChanges();
            return View("Confirmation", ar);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
