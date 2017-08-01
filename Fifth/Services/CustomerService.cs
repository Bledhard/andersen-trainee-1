using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Fifth.Domain;
using Fifth.Interfaces;

namespace Fifth.Services
{
    public class CustomerService : IDbService<Customer>
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Documents\Visual Studio 2017\Projects\Fourth\Data\FourthDB.mdf;Integrated Security=True;Connect Timeout=30";
        private const string TableName = "Customers";

        public void Create(Customer customer)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {TableName} ({Customer.SqlKeysString()}) " +
                            $"VALUES ({customer.SqlValuesString()});";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //Create new wallet for each currency connected to this CustomerID
        }

        public List<Customer> Get()
        {
            var customerList = new List<Customer>();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"SELECT Id, {Customer.SqlKeysString()} FROM {TableName};";
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
                            EMail = reader["E-Mail"].ToString(),
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
                string query = $"SELECT Id, {Customer.SqlKeysString()} FROM {TableName} WHERE Id={id};";
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
                        customer.EMail = reader["E-Mail"].ToString();
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
