using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Fifth.Domain;
using Newtonsoft.Json.Linq;

namespace Fifth.Services
{
    class WalletService
    {
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Documents\Visual Studio 2017\Projects\Fifth\Fifth\App_Data\db.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(Wallet obj)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "insert into Wallets(CustomerID, Status, Currency, Amount) values (\'" + obj.CustomerID + "\',"
                     + "\'" + (obj.Status ? 1 : 0) + "\'," + "\'" + obj.Currency + "\'," + "\'" + obj.Amount + "\');";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<Wallet> ReadTable()
        {
            List<Wallet> tempList = new List<Wallet>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "select * from Wallets";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Wallet temp = new Wallet();
                        temp.id = Convert.ToInt32(reader["id"]);
                        temp.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                        temp.Status = Convert.ToBoolean(reader["Status"]);
                        temp.Currency = reader["Currency"].ToString();
                        temp.Amount = Convert.ToInt32(reader["Amount"]);

                        tempList.Add(temp);
                    }
                }
                cn.Close();
                return tempList;
            }
        }

        public List<Wallet> ReadAllCustomersWallets(int CustomerID)
        {
            List<Wallet> tempList = new List<Wallet>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "select * from Wallets where CustomerID=" + CustomerID;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Wallet temp = new Wallet();
                        temp.id = Convert.ToInt32(reader["id"]);
                        temp.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                        temp.Status = Convert.ToBoolean(reader["Status"]);
                        temp.Currency = reader["Currency"].ToString();
                        temp.Amount = Convert.ToInt32(reader["Amount"]);

                        tempList.Add(temp);
                    }
                }
                cn.Close();
                return tempList;
            }
        }

        public Wallet ReadWallet(int id)
        {
            Wallet temp = new Wallet();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "select * from Wallets where id=" + id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp.id = Convert.ToInt32(reader["id"]);
                        temp.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                        temp.Status = Convert.ToBoolean(reader["Status"]);
                        temp.Currency = reader["Currency"].ToString();
                        temp.Amount = Convert.ToInt32(reader["Amount"]);
                    }
                }
                cn.Close();
                return temp;
            }
        }

        public void Update(int id, JObject jsonData)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                foreach (var obj in jsonData)
                {
                    string query = "update Wallets set " + obj.Key + "=\'" + obj.Value + "\' where id=" + id;
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        public void Delete(int CustomerID)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "delete from Wallets where CustomerID=" + CustomerID;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
