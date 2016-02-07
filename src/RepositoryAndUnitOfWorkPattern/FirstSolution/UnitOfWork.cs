using RepositoryAndUnitOfWorkPattern;
using RepositoryAndUnitOfWorkPattern.FirstSolution;
using RepositoryAndUnitOfWorkPattern.FirstSolution.Interfaces;
using RepositoryAndUnitOfWorkPattern.Universal;
using RepositoryAndUnitOfWorkPattern.Utilities;
using SQLite.Net;

namespace RepositoryAndUnitOFWorkPattern.FirstSolution
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

        public UnitOfWork(ISQLiteConnectionFactory sqliteConnectionFactory)
        {
            this.connection = sqliteConnectionFactory.GetConnection();
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

        public IRepository<T> GetGenericRepository<T>() where T : class, IEntity, new()
        {
            return new Repository<T>(connection);
        }

        private void BeginTransaction()
        {
            connection.BeginTransaction();
        }
    }
}