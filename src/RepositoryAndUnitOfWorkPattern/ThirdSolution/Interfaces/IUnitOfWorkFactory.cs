using RepositoryAndUnitOFWorkPattern.ThirdSolution.Interfaces;

namespace RepositoryAndUnitOfWorkPattern.ThirdSolution.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}