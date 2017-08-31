using AndersenTrainee1.EntityFramework.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AndersenTrainee1.EntityFramework.Services
{
    public class EntityFrameworkCustomerService : IEntityFrameworkDbService<Customer>
    {
        public virtual void Create(Customer customer)
        {
            using (var db = new Container())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        public List<Customer> Get()
        {
            using (var db = new Container())
            {
                return db.Customers.ToList();
            }
        }

        public Customer Get(int id)
        {
            using (var db = new Container())
            {
                return db.Customers.Find(id);
            }
        }

        public virtual void Update(Customer customer)
        {
            using (var db = new Container())
            {
                var target = db.Customers.Find(customer.Id);
                if (target != null)
                {
                    target = customer;
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new Container())
            {
                var target = db.Customers.Find(id);
                if (target != null)
                {
                    db.Customers.Remove(target);
                    db.SaveChanges();
                }
            }
        }
    }
}
