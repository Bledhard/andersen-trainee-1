using AndersenTrainee1.Domain.EntityFramework;
using AndersenTrainee1.Interfaces.EntityFramework;
using AndersenTrainee1.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndersenTrainee1.Services.EntityFramework
{
    public class EntityFrameworkTransactionService : IEntityFrameworkDbService<Transaction>
    {
        public void Create(Transaction transaction)
        {
            using (var db = new AT1Context())
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }

        public List<Transaction> Get()
        {
            using (var db = new AT1Context())
            {
                return db.Transactions.ToList();
            }
        }

        public Transaction Get(int id)
        {
            using (var db = new AT1Context())
            {
                return db.Transactions.Find(id);
            }
        }

        public List<Transaction> GetByWalletId(int WalletId)
        {
            using (var cn = new AT1Context())
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
            using (var db = new AT1Context())
            {
                var query = from ca in db.Customers
                            join wa in db.Wallets on ca.Id equals wa.CustomerId
                            join t in db.Transactions on wa.Id equals t.From
                            join wb in db.Wallets on t.To equals wb.Id
                            join cb in db.Customers on wb.CustomerId equals cb.Id
                            where wa.Id == id
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

        public void Generate()
        {
            //Method is created for testing purposes, to enlarge DB so its possible to train some specific SQL queries
            using (var db = new AT1Context())
            {
                var WalletList = db.Wallets.ToList();
                var WalletIdList = new List<int>();
                var rand = new Random();
                foreach (Wallet wallet in WalletList)
                {
                    WalletIdList.Add(wallet.Id);
                }
                var TransactionList = new Transaction[100];
                for (int i = 0; i < TransactionList.Length; i++)
                {
                    int tID;
                    var fID = rand.Next(WalletIdList.Count - 1);
                    do {
                        tID = rand.Next(WalletIdList.Count - 1);
                    }
                    while (tID == fID);

                    TransactionList[i] = new Transaction()
                    {
                        Id = rand.Next(10000, 20000),
                        From = WalletIdList[fID],
                        To = WalletIdList[tID],
                        Amount = rand.Next(1000),
                        Currency = WalletList[fID].Currency,
                        Date = DateTime.Now
                    };
                }

                db.Transactions.AddRange(TransactionList);
                db.SaveChanges();
            }
        }
    }
}
