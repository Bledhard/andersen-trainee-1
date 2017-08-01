using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AndersenTrainee1.Domain;
using AndersenTrainee1.Interfaces;

namespace AndersenTrainee1.Services
{
    class WalletService : IDbService<Wallet>
    {
        public const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Documents\Visual Studio 2017\Projects\Andersen-Trainee-1\Andersen-Trainee-1\App_Data\db.mdf;Integrated Security=True;Connect Timeout=30";
        public const string TableName = "Wallets";

        public void Create(Wallet wallet)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"insert into {TableName}({Wallet.SqlKeysString()})" +
                               $"values ({wallet.SqlValuesString()})";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<Wallet> Get()
        {
            var tempList = new List<Wallet>();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"select Id, {Wallet.SqlKeysString()} from {TableName}";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var wallet = new Wallet()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            CustomerId = Convert.ToInt32(reader["CustomerID"]),
                            Status = Convert.ToBoolean(reader["Status"]),
                            Currency = reader["Currency"].ToString(),
                            Amount = Convert.ToInt32(reader["Amount"])
                        };
                        tempList.Add(wallet);
                    }
                }
                cn.Close();
                return tempList;
            }
        }

        public List<Wallet> GetByCustomerId(int CustomerId)
        {
            var tempList = new List<Wallet>();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"select Id, {Wallet.SqlKeysString()} from {TableName} where CustomerID={CustomerId}";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Wallet temp = new Wallet()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            CustomerId = Convert.ToInt32(reader["CustomerID"]),
                            Status = Convert.ToBoolean(reader["Status"]),
                            Currency = reader["Currency"].ToString(),
                            Amount = Convert.ToInt32(reader["Amount"])
                        };
                        tempList.Add(temp);
                    }
                }
                cn.Close();
                return tempList;
            }
        }

        public Wallet Get(int id)
        {
            var wallet = new Wallet();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"SELECT Id, {Customer.SqlKeysString()} FROM {TableName} WHERE Id={id};";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        wallet.Id = Convert.ToInt32(reader["id"]);
                        wallet.CustomerId = Convert.ToInt32(reader["CustomerID"]);
                        wallet.Status = Convert.ToBoolean(reader["Status"]);
                        wallet.Currency = reader["Currency"].ToString();
                        wallet.Amount = Convert.ToInt32(reader["Amount"]);
                    }
                }
                cn.Close();
                return wallet;
            }
        }

        public void Update(Wallet wallet)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = wallet.SqlUpdateString();
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void DeleteByCustomerID(int CustomerID)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                var query = $"DELETE FROM {TableName} WHERE Id={CustomerID};";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Delete(int id)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"DELETE FROM {TableName} WHERE Id={id};";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}