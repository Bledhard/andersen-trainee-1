using System.Collections.Generic;
using AndersenTrainee1.Domain.EntityFramework;

namespace AndersenTrainee1.Interfaces.EntityFramework
{
    public interface IEntityFrameworkDbService<T> where T : IEntityFramewokBaseEntity

    {
        void Create(T item);

        List<T> Get();

        T Get(int id);

        void Update(T item);

        void Delete(int id);
    }
}