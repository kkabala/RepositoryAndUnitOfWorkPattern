using RepositoryAndUnitOfWorkPattern.Universal;
using SQLite.Net;
using System;

namespace RepositoryAndUnitOfWorkPattern.ThirdSolution
{
    public class SampleDataClassRepository : Repository<SampleDataClass>, ISampleDataClassRepository
    {
        public SampleDataClassRepository(SQLiteConnection connection) : base(connection)
        {
        }

        public void DoSomethingAwesome()
        {
            throw new NotImplementedException();
        }
    }
}