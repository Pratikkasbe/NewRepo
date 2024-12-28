using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Pratik!" };

            //ViewData["Movie"] = movie;
            var cutomer = new List<Customers>
            {
                new Customers{Name="Pratik"},
                new Customers{Name="Pratik2"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Customers = cutomer,
                Movie = movie
            };

            return View(viewModel);
            //return Content("123");
            //return new EmptyResult();
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortby)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortby))
                sortby = "Name";
            return Content(String.Format("pageIndex={0}& sortby={1}", pageIndex, sortby));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ViewResult Index1()
        {
            var movies = GetMovies();

            return View(movies);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Cindrella" },
                new Movie { Id = 2, Name = "Honeywell" }
            };

        }
    }
}