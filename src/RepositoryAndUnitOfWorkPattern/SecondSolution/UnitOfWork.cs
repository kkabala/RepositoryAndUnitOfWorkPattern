using RepositoryAndUnitOFWorkPattern.SecondSolution.Interfaces;
using SQLite.Net;

namespace RepositoryAndUnitOFWorkPattern.SecondSolution
{
    public class UnitOfWork : IUnitOfWork
    {
        public SQLiteConnection Connection
        {
            get; private set;
        }

        public UnitOfWork(SQLiteConnection sqliteConnection)
        {
            this.Connection = sqliteConnection;
            BeginTransaction();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }

        public void Commit()
        {
            Connection.Commit();
        }

        public void Rollback()
        {
            Connection.Rollback();
        }

        private void BeginTransaction()
        {
            Connection.BeginTransaction();
        }
    }
}