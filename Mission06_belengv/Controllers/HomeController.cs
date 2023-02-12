using Mission06_belengv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_belengv.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Adding private instance
        private AddMovieContext _MovieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, AddMovieContext tempname)
        {
            _logger = logger;
            _MovieContext = tempname;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovies(ApplicationResponse ar)
        {
            //This would save the information that is filledout in the form
            _MovieContext.Add(ar);
            try //Used try and catch to display the data validation errors
            {
                _MovieContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving changes: " + ex.Message);
            }
            //This will pass our variables
            return View( ar);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Podcast()
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
