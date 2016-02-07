using RepositoryAndUnitOfWorkPattern.SecondSolution.Interfaces;
using RepositoryAndUnitOfWorkPattern.Utilities;
using RepositoryAndUnitOFWorkPattern.SecondSolution;
using RepositoryAndUnitOFWorkPattern.SecondSolution.Interfaces;

namespace RepositoryAndUnitOfWorkPattern.SecondSolution
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISQLiteConnectionFactory sqliteConnectionFactory;

        public UnitOfWorkFactory(ISQLiteConnectionFactory sqliteConnectionFactory)
        {
            this.sqliteConnectionFactory = sqliteConnectionFactory;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(sqliteConnectionFactory.GetConnection());
        }
    }
}