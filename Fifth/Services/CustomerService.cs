using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Fifth.Domain;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Fifth.Services
{
    class CustomerService
    {
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Source\Repos\andersen-trainee-1\Fifth\App_Data\db.mdf;Integrated Security=True;Connect Timeout=30";
            
        public void Create(Customer obj)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "insert into Customers(FirstName, Surname, BirthDate, Phone, [E-Mail]) values (" + "\'" + obj.firstName + "\'," + "\'" + obj.surname + "\',"
                     + "\'" + obj.birthDate + "\'," + "\'" + obj.phone + "\'," + "\'" + obj.eMail + "\');";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //Create new wallet for each currency connected to this CustomerID
        }

        public List<Customer> ReadTable()
        {
            List < Customer > tempList= new List< Customer >();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "select * from Customers";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer temp = new Customer();
                        temp.id = Convert.ToInt32(reader["id"]);
                        temp.firstName = reader["FirstName"].ToString();
                        temp.surname = reader["Surname"].ToString();
                        temp.birthDate = Convert.ToDateTime(reader["BirthDate"]).Date.ToString();
                        temp.phone = reader["Phone"].ToString();
                        temp.eMail = reader["E-Mail"].ToString();

                        tempList.Add(temp);
                    }
                }
                cn.Close();
                return tempList;
            }
        }

        public Customer ReadCustomer(int id)
        {
            Customer temp = new Customer();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "select * from Customers where id=" + id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp.firstName = reader["FirstName"].ToString();
                        temp.surname = reader["Surname"].ToString();
                        temp.birthDate = Convert.ToDateTime(reader["BirthDate"]).Date.ToString();
                        temp.phone = reader["Phone"].ToString();
                        temp.eMail = reader["E-Mail"].ToString();
                    }
                }
                cn.Close();
                return temp;
            }
        }

        public void Update(int id, Customer customer)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                foreach (PropertyInfo prop in customer.GetType().GetProperties())
                {
                    string query = "update Customers set " + prop.Name + "=\'" + prop.GetValue(customer, null) + "\' where id=" + id;
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "delete from Customers where id=" + id;
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
