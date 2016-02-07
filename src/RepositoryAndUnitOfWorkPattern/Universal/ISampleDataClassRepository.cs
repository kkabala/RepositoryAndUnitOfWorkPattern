namespace RepositoryAndUnitOfWorkPattern.Universal
{
    public interface ISampleDataClassRepository : IRepository<SampleDataClass>
    {
        void DoSomethingAwesome();
    }
}