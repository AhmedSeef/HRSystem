using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HRSystem.Repository.Contract.Base;
using HRSystem.Service.Contract.Base;

namespace HRSystem.Service.Implementation.Base
{
    public class BaseService<T> : IBaseService<T> where T:class,new()
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return  await  _repository.GetAll();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetWhere(predicate);
        }

        public async Task<bool> Insert(T entity)
        {
            _repository.Insert(entity);
            return await  _unitOfWork.complete();
        }

        public async Task<bool> Update(T entity)
        {
            _repository.Update(entity);
            return await _unitOfWork.complete();
        }

        public async Task<bool> Delete(T entity)
        {
            _repository.Delete(entity);
            return await _unitOfWork.complete();
        }
    }
}