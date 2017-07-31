using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Fifth.Domain;
using Newtonsoft.Json.Linq;

namespace Fifth.Services
{
    class TransactionService
    {
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Source\Repos\andersen-trainee-1\Fifth\App_Data\db.mdf;Integrated Security=True;Connect Timeout=30";

        public void Create(Transaction obj)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "insert into Transactions ([From], [To], Currency, Amount, Date) values (" + "\'" + obj.From + "\'," + "\'" + obj.To + "\',"
                     + "\'" + obj.Currency + "\'," + "\'" + obj.Amount + "\'," + "\'" + obj.Date + "\');";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<Transaction> ReadTable()
        {
            List<Transaction> tempList = new List<Transaction>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "select * from Transactions";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction temp = new Transaction();
                        temp.id = Convert.ToInt32(reader["id"]);
                        temp.From = Convert.ToInt32(reader["From"]);
                        temp.To = Convert.ToInt32(reader["To"]);
                        temp.Currency = reader["Currency"].ToString();
                        temp.Amount = Convert.ToInt32(reader["Amount"]);
                        temp.Date = Convert.ToDateTime(reader["Date"]);

                        tempList.Add(temp);
                    }
                }
                cn.Close();
                return tempList;
            }
        }

        public List<Transaction> ReadWalletsTransactions(int WalletID)
        {
            List<Transaction> tempList = new List<Transaction>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "select * from Transactions where [From]=" + WalletID + " or [To]=" + WalletID;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction temp = new Transaction();
                        temp.id = Convert.ToInt32(reader["id"]);
                        temp.From = Convert.ToInt32(reader["From"]);
                        temp.To = Convert.ToInt32(reader["To"]);
                        temp.Currency = reader["Currency"].ToString();
                        temp.Amount = Convert.ToInt32(reader["Amount"]);
                        temp.Date = Convert.ToDateTime(reader["Date"]);

                        tempList.Add(temp);
                    }
                }
                cn.Close();
                return tempList;
            }
        }

        public List<Transaction> ReadCustomersTransactions(int CustomerID)
        {
            WalletService walletService = new WalletService();
            List<Wallet> walletList = new List<Wallet>();
            walletList = walletService.ReadAllCustomersWallets(CustomerID);
            List<Transaction> taList = new List<Transaction>();
            foreach (Wallet wallet in walletList)
            {
                taList.AddRange(ReadWalletsTransactions(wallet.id));
            }
            return taList;
        }

        public Transaction ReadTransaction(int id)
        {
            Transaction temp = new Transaction();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "select * from Transactions where id=" + id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp.id = Convert.ToInt32(reader["id"]);
                        temp.From = Convert.ToInt32(reader["From"]);
                        temp.To = Convert.ToInt32(reader["To"]);
                        temp.Currency = reader["Currency"].ToString();
                        temp.Amount = Convert.ToInt32(reader["Amount"]);
                        temp.Date = Convert.ToDateTime(reader["Date"]);
                    }
                }
                cn.Close();
                return temp;
            }
        }
    }
}
