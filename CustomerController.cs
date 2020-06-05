using MVCUdemy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace MVCUdemy1.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: Customer
       
        public ViewResult Index()
        {

            if(User.IsInRole("CanManageMovies"))
            return View("Index");
            return View("ReadOnlyList");
        }
      //  [Authorize(Roles = "CanManageMovies")]
        public ActionResult Create()
        {
            var membership = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membership

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var customers = _context.MembershipTypes.ToList();
            if (customers == null)
                return HttpNotFound();
            return View(customers);
        }
        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Edit(int id)
        {
            var customers = _context.Customers.SingleOrDefault(x=>x.Id==id);
            var viewmodel = new NewCustomerViewModel
            {
                Customer = customers,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                var cust = _context.Customers.SingleOrDefault(x => x.Id == customer.Id);

                // cust= customer;
                cust.BirthDate = customer.BirthDate;
                cust.Name = customer.Name;
                cust.IsSubscribedNewSettler = customer.IsSubscribedNewSettler;
                cust.MembershipType = customer.MembershipType;
                cust.MembershipTypeId = customer.MembershipTypeId;
               // Mapper.Map(customer, cust);
                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}