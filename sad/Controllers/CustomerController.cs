using AndersenTrainee1.Services;
using AndersenTrainee1.Domain;
using System.Collections.Generic;
using System.Web.Http;

namespace AndersenTrainee1.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private CustomerService customerService;

        public CustomerController()
        {
            this.customerService = new CustomerService();
        }

        //GET: api/customer/5
        [HttpGet]
        public Customer Get(int id)
        {
            return customerService.Get(id);
        }

        //GET: api/customer
        [HttpGet]
        public List<Customer> Get()
        {
            return customerService.Get();
        }

        //PATCH: api/customer/3
        [HttpPatch]
        public void Patch([FromBody] Customer customer)
        {
            customerService.Update(customer);
        }

        //POST: api/customer
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            customerService.Create(customer);
        }

        //DELETE: api/customer/5
        [HttpDelete]
        public void Delete(int id)
        {
            customerService.Delete(id);
        }
    }
}