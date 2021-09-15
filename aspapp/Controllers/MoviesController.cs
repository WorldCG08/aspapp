using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using aspapp.Models;
using aspapp.ViewModels;

namespace aspapp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppContext _context;

        public MoviesController()
        {
            _context = new AppContext();
        }

        [Route("movies")]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genres).ToList();

            return View(movies);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "John"},
                new Customer {Name = "Jamie"},
                new Customer {Name = "Travolta"},
                new Customer {Name = "Scott"},
                new Customer {Name = "Travis"},
                new Customer {Name = "Trevor"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            // return new ViewResult();
            // return Content("Hello world!!!");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // // Movies
        // public ActionResult Index(int? pageIndex, string sortBy)
        // {
        //     if (!pageIndex.HasValue)
        //         pageIndex = 1;
        //
        //     if (String.IsNullOrWhiteSpace(sortBy))
        //         sortBy = "name";
        //
        //     return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        // }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(month + "/" + year);
        }

        [Route("movies/details/{id}")]
        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie != null)
                return View(movie);
            return new HttpNotFoundResult();
        }
    }
}