using SQLite.Net;
using System;

namespace RepositoryAndUnitOFWorkPattern.SecondSolution.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        SQLiteConnection Connection { get; }

        void Commit();

        void Rollback();
    }
}