using System;
using System.Collections.Generic;
using AndersenTrainee1.Interfaces;
using System.Data.SqlClient;
using AndersenTrainee1.Domain;

namespace AndersenTrainee1.Services
{
    public abstract class BaseDbService<T> : IDbService<T> where T : BaseEntity                                                     
    {
        protected const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Source\Repos\andersen-trainee-1\sad\App_Data\db.mdf;Integrated Security=True;Connect Timeout=30";

        public virtual void Create(T entity)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {entity.TableName()} ({entity.SqlKeysString()}) " +
                            $"VALUES ({entity.SqlValuesString()});";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //Create new wallet for each currency connected to this CustomerID
        }

        public virtual List<T> Get()
        {
            throw new NotImplementedException();
        }

        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = entity.SqlUpdateString();
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}