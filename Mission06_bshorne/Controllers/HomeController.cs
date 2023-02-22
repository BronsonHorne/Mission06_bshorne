using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieApplicationContext _movieContext { get; set; }

        public HomeController(MovieApplicationContext x)
        {
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
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Movie(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(ar);
                _movieContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else //If Invalid
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View();
            }
            

        }

        public IActionResult MovieList()
        {
            var allMovies = _movieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.ApplicationId)
                .ToList();
            return View(allMovies);
        }
        [HttpGet]
        public IActionResult Edit (int applicationid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View("Movie", movie);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse daResponse)
        {
            _movieContext.Update(daResponse);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var application = _movieContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete (ApplicationResponse deleteResponse)
        {
            _movieContext.Responses.Remove(deleteResponse);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
