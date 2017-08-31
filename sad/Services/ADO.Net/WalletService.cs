using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AndersenTrainee1.Domain.ADONet;

namespace AndersenTrainee1.Services.ADONet
{
    class WalletService : BaseDbService<Wallet>
    {
        public override List<Wallet> Get()
        {
            var entity = new Wallet();
            var walletList = new List<Wallet>();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"select Id, {entity.SqlKeysString()} from {entity.TableName()}";
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
                        walletList.Add(wallet);
                    }
                }
                cn.Close();
                return walletList;
            }
        }

        public List<Wallet> GetByCustomerId(int CustomerId)
        {
            var entity = new Wallet();
            var walletList = new List<Wallet>();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"select Id, {entity.SqlKeysString()} from {entity.TableName()} where CustomerID={CustomerId}";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Wallet wallet = new Wallet()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            CustomerId = Convert.ToInt32(reader["CustomerID"]),
                            Status = Convert.ToBoolean(reader["Status"]),
                            Currency = reader["Currency"].ToString(),
                            Amount = Convert.ToInt32(reader["Amount"])
                        };
                        walletList.Add(wallet);
                    }
                }
                cn.Close();
                return walletList;
            }
        }

        public override Wallet Get(int id)
        {
            var wallet = new Wallet();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"SELECT Id, {wallet.SqlKeysString()} FROM {wallet.TableName()} WHERE Id={id};";
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

        public void DeleteByCustomerID(int CustomerID)
        {
            var entity = new Wallet();
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                var query = $"DELETE FROM {entity.TableName()} WHERE Id={CustomerID};";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public override void Delete(int id)
        {
            var wallet = new Wallet();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"DELETE FROM {wallet.TableName()} WHERE Id={id};";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}