using HRSystem.Repository.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRSystem.Data;

namespace HRSystem.Repository.Implementation.Base
{
    public class Repository<T> : IRepository<T> where T : class,new()
    {
        private readonly HRSystemContext _context;
        public Repository(HRSystemContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return  await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
