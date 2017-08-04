using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AndersenTrainee1.Domain;
using AndersenTrainee1.Interfaces;

namespace AndersenTrainee1.Services
{
    public class CustomerService : BaseDbService<Customer>
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Source\Repos\andersen-trainee-1\sad\App_Data\db.mdf;Integrated Security=True;Connect Timeout=30";
        
        public CustomerService(string tableName) : base(tableName)
        {
        }

        public List<Customer> Get()
        {
            var customerList = new List<Customer>();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"SELECT Id, {new Customer().SqlKeysString()} FROM {this.TableName};";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customer = new Customer()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            FirstName = reader["FirstName"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                            EMail = reader["eMail"].ToString(),
                            Phone = reader["Phone"].ToString()
                        };

                        customerList.Add(customer);
                    }
                }
                cn.Close();
                return customerList;
            }
        }

        public Customer Get(int id)
        {
            var customer = new Customer();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"SELECT Id, {Customer.SqlKeysString()} FROM {TableName} WHERE Id={id};";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customer.FirstName = reader["FirstName"].ToString();
                        customer.Surname = reader["Surname"].ToString();
                        customer.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                        customer.Phone = reader["Phone"].ToString();
                        customer.EMail = reader["eMail"].ToString();
                    }
                }
                cn.Close();
                return customer;
            }
        }

        public void Update(Customer customer)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = customer.SqlUpdateString();
                var cmd = new SqlCommand(query, cn);
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