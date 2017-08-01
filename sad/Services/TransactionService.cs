using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AndersenTrainee1.Domain;
using AndersenTrainee1.Interfaces;

namespace AndersenTrainee1.Services
{
    class TransactionService : IDbService<Transaction>
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Documents\Visual Studio 2017\Projects\Andersen-Trainee-1\Andersen-Trainee-1\App_Data\db.mdf;Integrated Security=True;Connect Timeout=30";
        private const string TableName = "Transactions";

        public void Create(Transaction transaction)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {TableName} ({Transaction.SqlKeysString()}) " +
                            $"VALUES ({transaction.SqlValuesString()});";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<Transaction> Get()
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

        public Transaction Get(int id)
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

        public void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}