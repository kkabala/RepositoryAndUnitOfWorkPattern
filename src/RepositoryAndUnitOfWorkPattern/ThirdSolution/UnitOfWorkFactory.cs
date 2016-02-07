using RepositoryAndUnitOfWorkPattern.ThirdSolution.Interfaces;
using RepositoryAndUnitOfWorkPattern.Utilities;
using RepositoryAndUnitOFWorkPattern.ThirdSolution;
using RepositoryAndUnitOFWorkPattern.ThirdSolution.Interfaces;

namespace RepositoryAndUnitOfWorkPattern.ThirdSolution
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