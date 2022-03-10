using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Contracts.Provider
{
    public interface IUnitOfWorkProvider
    {
        Task BeginTransaction(IsolationLevel? isolationLevel = null);

        Task Commit();

        Task RollBack();

        Task ExecuteStrategy(Func<Task> p);
    }
}
