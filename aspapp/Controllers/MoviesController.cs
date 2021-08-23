using System.Web.Mvc;
using aspapp.Models;

namespace aspapp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);
        }
    }
}