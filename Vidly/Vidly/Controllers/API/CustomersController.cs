using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTOS;
using Vidly.Models;
namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET API/CUSTOMERS
        public IHttpActionResult GetCustomers()
        {
            var customerDto = _context.Customers
                .Include(x => x.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customers, CustomerDto>);
            return Ok(customerDto);
        }

        //GET API/CUSTOMERS/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)

                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Customers, CustomerDto>(customer));

        }
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)

                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customers>(customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;
            return Created(Request.RequestUri + "/" + customer.Id, customerdto);
        }

        //PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customers>(customerdto, customerInDb);
            //customerInDb.Name = customerdto.Name;
            //customerInDb.BirthDate = customerdto.BirthDate;
            //customerInDb.IsSubscribedToNewsLetter = customerdto.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customerdto.MembershipTypeId;
            _context.SaveChanges();

        }

        //Delete api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}