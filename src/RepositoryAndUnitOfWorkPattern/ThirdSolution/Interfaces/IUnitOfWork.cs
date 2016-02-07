using RepositoryAndUnitOfWorkPattern;
using RepositoryAndUnitOfWorkPattern.Universal;
using System;

namespace RepositoryAndUnitOFWorkPattern.ThirdSolution.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetGenericRepository<T>() where T : class, IEntity, new();

        ISampleDataClassRepository SampleDataClassRepository { get; }

        void Commit();

        void Rollback();
    }
}