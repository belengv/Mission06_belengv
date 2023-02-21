using Mission06_belengv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission06_belengv.Controllers
{
    public class HomeController : Controller
    {
        
        //Adding private instance
        private AddMovieContext DaContext { get; set; }

        public HomeController(AddMovieContext tempname)
        {           
            DaContext = tempname;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            //this holds our models and our category list items
            ViewBag.Categories = DaContext.Categories.ToList();
         
            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(ApplicationResponse ar)
        {
            //Making sure our entries are valid, the required field are filled out. If so, save changes
            if (ModelState.IsValid)
            {
                DaContext.Add(ar);
                DaContext.SaveChanges();
                return View("MovieAdded", ar);
            }
            else
            {
                ViewBag.Categories = DaContext.Categories.ToList();
                return View();
            }           
        }
        
        public IActionResult Podcast()
        {
            //view that contains the podcast link
            return View();
        }
        [HttpGet] //our movie collection view that contaings a table that dispalys our movie entries
        public IActionResult Collection()
        {
            var movies = DaContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title) //Alphabetical order on Title
                .ToList();          
            return View(movies); //returns our database responses
        }
        [HttpGet]
        public IActionResult Edit(int entryid) //receives and entry ID to make sure we edit the chosen entry
        {
            ViewBag.Categories = DaContext.Categories.ToList();
            var movie = DaContext.Responses.Single(x => x.EntryId == entryid);
            return View("AddMovies", movie); //direct us to our add movies view and displays the info that enty contains so we can edit it.
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            //Change fields info and save changes
            DaContext.Update(blah);
            DaContext.SaveChanges();

            return RedirectToAction("Collection"); //redirect to our movie collection view and show the entry updated.
        }
        [HttpGet]
        public IActionResult Delete(int entryid) //the entry ID selected for deletion is passed
        {
            var movied = DaContext.Responses.Single(x => x.EntryId == entryid);
            return View(movied);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            //Delete chosen entry and save changes 
            DaContext.Responses.Remove(ar);
            DaContext.SaveChanges();
            return RedirectToAction("Collection"); //redirect to our movie collection view and show the table updated.
        }

    }
}
