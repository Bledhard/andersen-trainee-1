using AndersenTrainee1.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AndersenTrainee1.EntityFramework.Services
{
    public class EntityFrameworkTransactionService : IEntityFrameworkDbService<Transaction>
    {
        public void Create(Transaction transaction)
        {
            using (var db = new Container())
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }

        public List<Transaction> Get()
        {
            using (var db = new Container())
            {
                return db.Transactions.ToList();
            }
        }

        public Transaction Get(int id)
        {
            using (var db = new Container())
            {
                return db.Transactions.Find(id);
            }
        }

        public List<Transaction> GetByWalletId(int WalletId)
        {
            using (var cn = new Container())
            {
                var query = from ta in cn.Transactions
                                  where (ta.From == WalletId || ta.To == WalletId)
                                  select ta;
                return query.ToList();
            }
        }

        public List<Transaction> GetByCustomerId(int CustomerId)
        {
            var walletService = new EntityFrameworkWalletService();
            var walletList = walletService.GetByCustomerId(CustomerId);
            var transactionList = new List<Transaction>();
            foreach (var wallet in walletList)
            {
                transactionList.AddRange(GetByWalletId(wallet.Id));
            }
            return transactionList;
        }

        public List<TaLog> GetLogByWalletId(int id)
        {
            var transactionLog = new List<TaLog>();
            using (var db = new Container())
            {
                var query = from ca in db.Customers
                            join wa in db.Wallets on ca.Id equals wa.CustomerId
                            join t in db.Transactions on wa.Id equals t.From
                            join wb in db.Wallets on t.To equals wb.Id
                            join cb in db.Customers on wb.CustomerId equals cb.Id
                            where ca.Id == id
                            select new
                            {
                                fn = ca.FirstName,
                                fs = ca.Surname,
                                tn = cb.FirstName,
                                ts = cb.Surname,
                                Amount = t.Amount,
                                Currency = t.Currency,
                                Date = t.Date
                            };
                var taList = query.ToList();
                foreach (var taLog in taList)
                {
                    transactionLog.Add(new TaLog(taLog.fn, taLog.fs, taLog.tn, taLog.ts, taLog.Amount, taLog.Currency, taLog.Date));
                }
                return transactionLog;
            }
        }

        public virtual void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
