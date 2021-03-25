using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDbContext context { get; set; }

        private iMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, iMovieRepository repository, MovieDbContext con)
        {
            _logger = logger;
            _repository = repository;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieInfo movieInfo)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(movieInfo);
                context.SaveChanges();
            }
            return View("Confirmation", movieInfo);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(MovieInfo movieInfo)
        {
            return View();
        }
        public IActionResult MovieCollection()
        {            
            return View(context.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
