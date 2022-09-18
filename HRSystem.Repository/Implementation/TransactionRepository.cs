using System.Linq;
using System.Threading.Tasks;
using HRSystem.Data;
using HRSystem.Model;
using HRSystem.Repository.Contract;
using HRSystem.Repository.Implementation.Base;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Repository.Implementation
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private HRSystemContext _context;
        public TransactionRepository(HRSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Transaction> getUserTransaction(int userId)
        {
            return await _context.Transactions.Where(x => x.LoginUserId == userId && x.DateSignOut == null)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

        }
    }
}