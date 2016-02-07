using RepositoryAndUnitOfWorkPattern;
using RepositoryAndUnitOfWorkPattern.ThirdSolution;
using RepositoryAndUnitOfWorkPattern.Universal;
using RepositoryAndUnitOFWorkPattern.ThirdSolution.Interfaces;
using SQLite.Net;

namespace RepositoryAndUnitOFWorkPattern.ThirdSolution
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLiteConnection connection;

        private ISampleDataClassRepository sampleDataClassRepository;

        public ISampleDataClassRepository SampleDataClassRepository
        {
            get
            {
                if (sampleDataClassRepository == null)
                {
                    sampleDataClassRepository = new SampleDataClassRepository(connection);
                }
                return sampleDataClassRepository;
            }
        }

        public UnitOfWork(SQLiteConnection sqliteConnection)
        {
            this.connection = sqliteConnection;
            BeginTransaction();
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        private void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public IRepository<T> GetGenericRepository<T>() where T : class, IEntity, new()
        {
            return new Repository<T>(connection);
        }
    }
}