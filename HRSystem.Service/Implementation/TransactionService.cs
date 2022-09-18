using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.DTO;
using HRSystem.Model;
using HRSystem.Repository.Contract.Base;
using HRSystem.Service.Contract;
using HRSystem.Service.Implementation.Base;

namespace HRSystem.Service.Implementation
{
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        private readonly IRepository<Transaction> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IRepository<Transaction> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> UpdateLogOut(int userId)
        {
            var trans = await _unitOfWork.TransactionRepository.getUserTransaction(userId);
            trans.DateSignOut = DateTime.Now;
            _unitOfWork.TransactionRepository.Update(trans);
            return await _unitOfWork.complete();
        }

        public async Task<List<TransctionDto>> GetAllTransActionsUserId(int userId)
        {
          var data =  await _unitOfWork.TransactionRepository.GetWhere(x => x.LoginUserId == userId);
          var result = data.Select(x => new TransctionDto
          {
              SignInDate = x.DateSignIn.ToShortDateString(),
              SignInTime = x.DateSignIn.ToString("hh:mm tt"),
              SignOutTime = x.DateSignOut==null? null: x.DateSignIn.ToString("hh:mm tt"),
              Status = x.DateSignOut == null ? "in progress" : (x.DateSignOut - x.DateSignIn).ToString(),
              WorkingHours = (TimeSpan)(x.DateSignOut == null ? TimeSpan.Zero : x.DateSignOut - x.DateSignIn),
          }).ToList();
          return (List<TransctionDto>)result;
        }
    }
}