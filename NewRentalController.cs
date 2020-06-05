using MVCUdemy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCUdemy1.Controllers.API1
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
         public NewRentalController()
        { 
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRental(Rental rental)
        {
            var cust = _context.Customers.Single(x => x.Id == rental.Id);
            rental.Customer = cust;
            rental.DateRented = DateTime.Now;
            _context.Rentals.Add(rental);
            return Ok();
        }
    }
}
