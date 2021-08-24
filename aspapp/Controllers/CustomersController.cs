using System.Collections.Generic;
using System.Web.Mvc;
using aspapp.Models;

namespace aspapp.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> Customers = new List<Customer>
        {
            new Customer {Id = 1, Name = "John Smith"},
            new Customer {Id = 2, Name = "John Travolta"},
            new Customer {Id = 3, Name = "Kael Freeman"},
            new Customer {Id = 4, Name = "Test user"}
        };

        [Route("customers")]
        public ActionResult Index()
        {
            
            return View(Customers);
        }
        
        [Route("customers/details/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            
            return View(Customers[id - 1]);
        }

    }
}