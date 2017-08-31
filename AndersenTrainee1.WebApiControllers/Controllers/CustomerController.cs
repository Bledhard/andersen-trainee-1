using System.Collections.Generic;
using System.Web.Http;
using AndersenTrainee1.Services.EntityFramework;
using AndersenTrainee1.Domain.EntityFramework;

namespace AndersenTrainee1.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private EntityFrameworkCustomerService customerService;

        public CustomerController()
        {
            this.customerService = new EntityFrameworkCustomerService();
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