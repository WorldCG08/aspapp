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

        [Route("customers/details")]
        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer != null)
                return View(customer);
            
            return HttpNotFound();
        }
        
        [Route("customers/add")]
        public ActionResult CustomerForm()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // TryUpdateModel(customerInDb);
                // TryUpdateModel(customerInDb, "", new string[] {"Name", "Email"});
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}