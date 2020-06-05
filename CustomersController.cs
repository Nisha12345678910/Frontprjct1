using AutoMapper;
using MVCUdemy1.Dtos;
using MVCUdemy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;

namespace MVCUdemy1.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        private IMapper mapper1, mapper2;
        public CustomersController()
        {
            var config1 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<MembershipType, MembershipTypeDTO>();
            });
          
            mapper1 = config1.CreateMapper();        
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
                    
            var customerDtos = customersQuery.ToList().Select(mapper1.Map<Customer, CustomerDTO>);
            return Ok(customerDtos);
        }
        //public  IEnumerable<CustomerDTO> GetCustomers()
        //{           
        //    return _context.Customers.ToList().Select(mapper.Map<Customer, CustomerDTO>);
        //}
        public CustomerDTO GetCustomer(int id)
        {
            var cust = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (cust == null)
                 throw new HttpResponseException(HttpStatusCode.NotFound);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDTO>();
            });         
            IMapper mapper = config.CreateMapper();
            return mapper.Map<Customer, CustomerDTO>(cust);
        }
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        { 
        
             if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        [HttpPut]
        public void UpdateCustomer(int id,Customer customer)
        {

            if (ModelState.IsValid)
            {
                var cust = _context.Customers.SingleOrDefault(x => x.Id == id);
                if(cust==null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                // cust= customer;
                cust.BirthDate = customer.BirthDate;
                cust.Name = customer.Name;
                cust.IsSubscribedNewSettler = customer.IsSubscribedNewSettler;
                cust.MembershipType = customer.MembershipType;
                cust.MembershipTypeId = customer.MembershipTypeId;
                // Mapper.Map(customer, cust);
                _context.SaveChanges();

                
            }
            else
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
                var cust = _context.Customers.SingleOrDefault(x => x.Id == id);
                if (cust == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(cust);
                _context.SaveChanges();
             
        }
    }
}
