using System;
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
        
        [Route("movies/add")]
        public ActionResult Add()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = new MultiSelectList(null, "ID", "Name", null)
            };
            return View("MovieForm", viewModel);
        }
        
        [HttpPost]
        public ActionResult Save(MovieFormViewModel movieForm)
        {
            if (movieForm.Movie.Id == 0)
                _context.Movies.Add(movieForm.Movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movieForm.Movie.Id);
                var selectedGenres = _context.Genres.Where(g => movieForm.SelectedGenres.Contains(g.Id)).ToList();
                movieInDb.Name = movieForm.Movie.Name;
                movieInDb.Genres = selectedGenres;
                movieInDb.ReleaseDate = movieForm.Movie.ReleaseDate;
                movieInDb.DateAdded = DateTime.Now;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genres).SingleOrDefault(c => c.Id == id);
            var allGenres = _context.Genres.ToList();

            if (movie == null)
                return HttpNotFound();
            
            // var items = new List<Genre>();
            // These items would be set from your db
            var items = new List<Genre>();

            foreach (var genre in allGenres)
            {
                items.Add(new Genre { Id = genre.Id, Name = genre.Name });
            }
            
            var selectedItems = new List<Genre>();
            
            foreach (var genre in movie.Genres)
            {
                selectedItems.Add(new Genre { Id = genre.Id, Name = genre.Name });
            }
            
            // project the selected indexs to an array of ints
            int[] selectedGenresArray = selectedItems.Select(s => s.Id).ToArray();
            
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = new MultiSelectList(items, "ID", "Name", selectedGenresArray),
                SelectedGenres = selectedGenresArray
            };
            return View("MovieForm", viewModel);
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
            var movie = _context.Movies.Include(m => m.Genres).SingleOrDefault(c => c.Id == id);
            if (movie != null)
                return View(movie);
            return new HttpNotFoundResult();
        }
    }
}