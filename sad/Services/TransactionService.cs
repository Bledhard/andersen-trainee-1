using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AndersenTrainee1.Domain;

namespace AndersenTrainee1.Services
{
    class TransactionService : BaseDbService<Transaction>
    {
        public override List<Transaction> Get()
        {
            var transactionList = new List<Transaction>();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = "select * from Transactions";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction transaction = new Transaction()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            From = Convert.ToInt32(reader["From"]),
                            To = Convert.ToInt32(reader["To"]),
                            Currency = reader["Currency"].ToString(),
                            Amount = Convert.ToInt32(reader["Amount"]),
                            Date = Convert.ToDateTime(reader["Date"])
                        };
                        transactionList.Add(transaction);
                    }
                }
                cn.Close();
                return transactionList;
            }
        }

        public List<Transaction> GetByWalletId(int WalletId)
        {
            var transactionList = new List<Transaction>();
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                var query = "select * from Transactions where [From]=" + WalletId + " or [To]=" + WalletId;
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction transaction = new Transaction()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            From = Convert.ToInt32(reader["From"]),
                            To = Convert.ToInt32(reader["To"]),
                            Currency = reader["Currency"].ToString(),
                            Amount = Convert.ToInt32(reader["Amount"]),
                            Date = Convert.ToDateTime(reader["Date"])
                        };
                        transactionList.Add(transaction);
                    }
                }
                cn.Close();
                return transactionList;
            }
        }

        public List<Transaction> GetByCustomerId(int CustomerId)
        {
            var walletService = new WalletService();
            var walletList = new List<Wallet>();
            walletList = walletService.GetByCustomerId(CustomerId);
            var transactionList = new List<Transaction>();
            foreach (var wallet in walletList)
            {
                transactionList.AddRange(GetByWalletId(wallet.Id));
            }
            return transactionList;
        }

        public override Transaction Get(int id)
        {
            var transaction = new Transaction();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = "select * from Transactions where id=" + id;
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transaction.Id = Convert.ToInt32(reader["id"]);
                        transaction.From = Convert.ToInt32(reader["From"]);
                        transaction.To = Convert.ToInt32(reader["To"]);
                        transaction.Currency = reader["Currency"].ToString();
                        transaction.Amount = Convert.ToInt32(reader["Amount"]);
                        transaction.Date = Convert.ToDateTime(reader["Date"]);
                    }
                }
                cn.Close();
                return transaction;
            }
        }

        public override void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}