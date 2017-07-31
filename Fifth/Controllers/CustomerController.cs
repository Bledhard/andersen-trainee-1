using Microsoft.AspNetCore.Mvc;
using Fifth.Services;
using System;
using Fifth.Domain;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Fifth.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private CustomerService customerService;

        public CustomerController()
        {
            this.customerService = new CustomerService();
        }

        //GET: api/customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return customerService.ReadCustomer(id);
        }

        //GET: api/customer
        [HttpGet]
        public List<Customer> Get()
        {
            return customerService.ReadTable();
        }

        //PATCH: api/customer/3
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody]JObject jsonData)
        {
            customerService.Update(id, jsonData);
        }

        //POST: api/customer
        [HttpPost]
        public void Post([FromBody]JToken jsonData)
        {
            customerService.Create(new Customer(jsonData));
        }

        //DELETE: api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerService.Delete(id);
        }
    }
}