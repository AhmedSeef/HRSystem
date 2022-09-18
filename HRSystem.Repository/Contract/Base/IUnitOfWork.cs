using System;
using System.Threading.Tasks;

namespace HRSystem.Repository.Contract.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task<bool> complete();
    }
}