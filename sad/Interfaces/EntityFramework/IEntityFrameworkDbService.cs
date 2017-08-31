using System.Collections.Generic;
using AndersenTrainee1.EntityFramework.Entities;

namespace AndersenTrainee1.EntityFramework.Services
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