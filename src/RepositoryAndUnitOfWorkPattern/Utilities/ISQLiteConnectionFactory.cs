using SQLite.Net;

namespace RepositoryAndUnitOfWorkPattern.Utilities
{
    public interface ISQLiteConnectionFactory
    {
        SQLiteConnection GetConnection();
    }
}