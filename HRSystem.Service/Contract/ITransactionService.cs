using System.Collections.Generic;
using System.Threading.Tasks;
using HRSystem.DTO;
using HRSystem.Model;
using HRSystem.Service.Contract.Base;

namespace HRSystem.Service.Contract
{
    public interface ITransactionService : IBaseService<Transaction>
    {
        Task<bool> UpdateLogOut(int userId);
        Task<List<TransctionDto>> GetAllTransActionsUserId(int userId);
    }
}