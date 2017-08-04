using System;
using System.Collections.Generic;
using AndersenTrainee1.Interfaces;
using System.Data.SqlClient;
using AndersenTrainee1.Domain;

namespace AndersenTrainee1.Services
{
    public class BaseDbService<T> : IDbService<T> where T : BaseEntity
                                                     
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bledhard\Source\Repos\andersen-trainee-1\sad\App_Data\db.mdf;Integrated Security=True;Connect Timeout=30";
        protected string TableName;

        public BaseDbService(string tableName)
        {
            this.TableName = tableName;
        }

        public virtual void Create(T entity)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var query = $"INSERT INTO {TableName} ({entity.SqlKeysString()}) " +
                            $"VALUES ({entity.SqlValuesString()});";
                var cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //Create new wallet for each currency connected to this CustomerID
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> Get()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}