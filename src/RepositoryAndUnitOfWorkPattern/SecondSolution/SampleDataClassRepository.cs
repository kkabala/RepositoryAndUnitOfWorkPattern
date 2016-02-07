using RepositoryAndUnitOfWorkPattern.Universal;
using RepositoryAndUnitOFWorkPattern.SecondSolution.Interfaces;
using System;

namespace RepositoryAndUnitOfWorkPattern.SecondSolution
{
    public class SampleDataClassRepository : Repository<SampleDataClass>, ISampleDataClassRepository
    {
        public SampleDataClassRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DoSomethingAwesome()
        {
            throw new NotImplementedException();
        }
    }
}