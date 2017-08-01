using System.Collections.Generic;

namespace Fifth.Interfaces
{
    public interface IDbService<T>
    {
        void Create(T item);

        List<T> Get();

        T Get(int id);

        void Update(T item);

        void Delete(int id);
    }
}
