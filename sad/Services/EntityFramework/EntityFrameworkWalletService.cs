using AndersenTrainee1.EntityFramework.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AndersenTrainee1.EntityFramework.Services
{
    public class EntityFrameworkWalletService : IEntityFrameworkDbService<Wallet>
    {
        public void Create(Wallet wallet)
        {
            using (var db = new Container())
            {
                db.Wallets.Add(wallet);
                db.SaveChanges();
            }
        }

        public List<Wallet> Get()
        {
            using (var db = new Container())
            {
                return db.Wallets.ToList();
            }
        }

        public List<Wallet> GetByCustomerId(int CustomerId)
        {
            using (var db = new Container())
            {
                var query = from wallets in db.Wallets
                            where wallets.CustomerId == CustomerId
                            select wallets;
                return query.ToList();
            }
        }

        public Wallet Get(int id)
        {
            using (var db = new Container())
            {
                return db.Wallets.Find(id);
            }
        }

        public virtual void Update(Wallet wallet)
        {
            using (var db = new Container())
            {
                var target = db.Wallets.Find(wallet.Id);
                if (target != null)
                {
                    target = wallet;
                    db.Entry(target).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteByCustomerID(int CustomerID)
        {
            using (var db = new Container())
            {
                db.Wallets.RemoveRange(db.Wallets.Where(wallet => wallet.CustomerId == CustomerID));
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Container())
            {
                var wallet = db.Wallets.Find(id);
                if (wallet != null)
                {
                    db.Wallets.Remove(wallet);
                    db.SaveChanges();
                }
            }
        }
    }
}
