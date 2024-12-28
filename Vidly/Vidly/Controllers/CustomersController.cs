using System.Linq;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Customers
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public ViewResult Index()
        {
            var customer = _context.Customers.ToList();
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                HttpNotFound();
            }

            return View(customer);

        }
    }
}