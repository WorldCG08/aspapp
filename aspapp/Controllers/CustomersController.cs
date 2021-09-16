using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using aspapp.Models;
using aspapp.ViewModels;

namespace aspapp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppContext _context;

        public CustomersController()
        {
            _context = new AppContext();
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
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer != null)
                return View(customer);
            return new HttpNotFoundResult();
        }
        
        [Route("customers/add")]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}