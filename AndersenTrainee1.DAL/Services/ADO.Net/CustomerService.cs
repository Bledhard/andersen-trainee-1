using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AndersenTrainee1.Domain.ADONet;

namespace AndersenTrainee1.Services.ADONet
{
    public class CustomerService : BaseDbService<Customer>
    {
        public override List<Customer> Get()
        {
            var entity = new Customer();
            var customerList = new List<Customer>();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"SELECT Id, {entity.SqlKeysString()} FROM {entity.TableName()};";
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
                            eMail = reader["eMail"].ToString(),
                            Phone = reader["Phone"].ToString()
                        };

                        customerList.Add(customer);
                    }
                }
                cn.Close();
                return customerList;
            }
        }

        public override Customer Get(int id)
        {
            var customer = new Customer();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"SELECT Id, {customer.SqlKeysString()} FROM {customer.TableName()} WHERE Id={id};";
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
                        customer.eMail = reader["eMail"].ToString();
                    }
                }
                cn.Close();
                return customer;
            }
        }

        public override void Delete(int id)
        {
            var customer = new Customer();
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"DELETE FROM {customer.TableName()} WHERE Id={id};";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}