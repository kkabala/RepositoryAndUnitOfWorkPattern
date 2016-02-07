using RepositoryAndUnitOfWorkPattern.SecondSolution.Interfaces;

namespace RepositoryAndUnitOfWorkPattern.SecondSolution
{
    public class UseClass
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public UseClass(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void DoSomething()
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var repo = new SampleDataClassRepository(uow);
                repo.Insert(new SampleDataClass());
            }
        }
    }
}