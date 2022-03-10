using Dukkantek.Domain.Contracts.Provider;
using Dukkantek.Shared.UnitOfWork;
using System;
using System.Data;
using System.Threading.Tasks; 

namespace Dukkantek.Managers.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;

        public UnitOfWorkManager(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public async Task BeginTransaction(IsolationLevel? isolationLevel = null)
        {
            await _unitOfWorkProvider.BeginTransaction(isolationLevel);
        }

        public async Task Commit()
        {
            await _unitOfWorkProvider.Commit();
        }

        public async Task RollBack()
        {
            await _unitOfWorkProvider.RollBack();
        }

        public async Task ExecuteStrategy(Func<Task> p)
        {
            await _unitOfWorkProvider.ExecuteStrategy(p);
        }
    }
}
