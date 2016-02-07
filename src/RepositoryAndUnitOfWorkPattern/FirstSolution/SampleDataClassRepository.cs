using RepositoryAndUnitOfWorkPattern.Universal;
using SQLite.Net;
using System;

namespace RepositoryAndUnitOfWorkPattern.FirstSolution
{
    public class SampleDataClassRepository : Repository<SampleDataClass>, ISampleDataClassRepository
    {
        public SampleDataClassRepository(SQLiteConnection sqliteConnection) : base(sqliteConnection)
        {
        }

        public void DoSomethingAwesome()
        {
            throw new NotImplementedException();
        }
    }
}