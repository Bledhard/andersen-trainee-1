using Microsoft.VisualStudio.TestTools.UnitTesting;
using AndersenTrainee1.Controllers;
using AndersenTrainee1.EntityFramework.Entities;
using System.Collections.Generic;

namespace AndersenTrainee1.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void GetCustomerNotNull()
        {
            var controller = new CustomerController();

            var customer = controller.Get(1) as Customer;

            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void GetListCustomerNotNull()
        {
            var controller = new CustomerController();

            var customers = controller.Get() as List<Customer>;

            Assert.IsNotNull(customers);
        }
    }
}