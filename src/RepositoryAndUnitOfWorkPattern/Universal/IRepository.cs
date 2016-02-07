using System.Collections.Generic;

namespace RepositoryAndUnitOfWorkPattern.Universal
{
    public interface IRepository<T> where T : class, IEntity
    {
        int Count();

        IEnumerable<T> GetAll();

        int Insert(T item);

        T GetById(string idValue);

        void InsertOrReplace(T item);

        void Delete(T item);

        void InsertAll(IEnumerable<T> items);

        void InsertOrReplaceAll(IEnumerable<T> items);

        void Update(T item);

        void UpdateAll(IEnumerable<T> items);

        void ClearTable();
    }
}