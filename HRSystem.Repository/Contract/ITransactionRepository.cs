using System.Threading.Tasks;
using HRSystem.Model;
using HRSystem.Repository.Contract.Base;

namespace HRSystem.Repository.Contract
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<Transaction> getUserTransaction(int userId);
    }
}