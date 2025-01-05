using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

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
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var MembershipViewModel = new NewMembershipViewModel()
            {
                Customers = new Customers(),
                MembershipTypes = membershipTypes
            };
            return View("New", MembershipViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMembershipViewModel
                {
                    Customers = customers,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            if (customers.Id == 0)
            {
                _context.Customers.Add(customers);
            }

            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == customers.Id);
                customerInDb.Name = customers.Name;
                customerInDb.BirthDate = customers.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customers.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customers.MembershipTypeId;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();
            var viewModel = new NewMembershipViewModel()
            {
                Customers = customers,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }
        public ViewResult Index()
        {

            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                HttpNotFound();
            }

            return View(customer);

        }
    }
}