using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        
        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {

            // var movies = await _movieService.GetHighestGrossingMovies();
            // return View(movies);
            // return /Views/Home/Index.cshtml
            // Alternatively, you can do View("abc");
            // It will find the file with name abc
            var testdata = "dude";
            ViewBag.myproperty = testdata;
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
    }
}
