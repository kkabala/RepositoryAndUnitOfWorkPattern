using RepositoryAndUnitOfWorkPattern.ThirdSolution.Interfaces;

namespace RepositoryAndUnitOfWorkPattern.ThirdSolution
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
                uow.SampleDataClassRepository.Insert(new SampleDataClass());
            }
        }
    }
}