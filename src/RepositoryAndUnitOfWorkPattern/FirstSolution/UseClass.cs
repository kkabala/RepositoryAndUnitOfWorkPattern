using RepositoryAndUnitOfWorkPattern.FirstSolution.Interfaces;

namespace RepositoryAndUnitOfWorkPattern.FirstSolution
{
    public class UseClass
    {
        private readonly IUnitOfWork unitOfWork;

        public UseClass(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void DoSomething()
        {
            unitOfWork.SampleDataClassRepository.Insert(new SampleDataClass());
        }
    }
}