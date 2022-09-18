using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Data;
using HRSystem.Repository.Contract;
using HRSystem.Repository.Contract.Base;

namespace HRSystem.Repository.Implementation.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRSystemContext _context;
        public UnitOfWork(HRSystemContext context)
        {
            this._context = context;
        }
        public void Dispose()
        {
           _context.Dispose();
        }

        public IEmployeeRepository employeeRepository { get; }
        public IEmployeeRepository EmployeeRepository => employeeRepository ?? new EmployeeRepository(_context);

        public ITransactionRepository transactionRepository { get; }
        public ITransactionRepository TransactionRepository => transactionRepository ?? new TransactionRepository(_context);

        public async Task<bool> complete()
        {
            return await _context.SaveChangesAsync()>0;
        }
    }
}
