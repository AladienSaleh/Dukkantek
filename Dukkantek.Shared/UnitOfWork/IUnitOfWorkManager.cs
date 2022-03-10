using System;
using System.Data;
using System.Threading.Tasks; 

namespace Dukkantek.Shared.UnitOfWork
{
    public interface IUnitOfWorkManager
    {
        Task BeginTransaction(IsolationLevel? isolationLevel = null);

        Task Commit();

        Task RollBack();

        Task ExecuteStrategy(Func<Task> p);
    }
}
