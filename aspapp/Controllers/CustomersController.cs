using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using aspapp.Models;

namespace aspapp.Controllers
{
    public class CustomersController : Controller
    {
        private AspAppContext _context;
        public CustomersController()
        {
            _context = new AspAppContext();
        }

        [Route("customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        
        [Route("customers/details/{id}")]
        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return new HttpNotFoundResult();
            }
        }
    }
}