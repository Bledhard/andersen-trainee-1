using System.Collections.Generic;
using AndersenTrainee1.Domain;

namespace AndersenTrainee1.Interfaces
{
    public interface IDbService<T> where T: BaseEntity
                                      
    {
        void Create(T item);

        List<T> Get();

        T Get(int id);

        void Update(T item);

        void Delete(int id);
    }
}