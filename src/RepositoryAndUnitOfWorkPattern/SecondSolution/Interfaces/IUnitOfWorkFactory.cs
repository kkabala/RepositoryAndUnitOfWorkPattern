using RepositoryAndUnitOFWorkPattern.SecondSolution.Interfaces;

namespace RepositoryAndUnitOfWorkPattern.SecondSolution.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}