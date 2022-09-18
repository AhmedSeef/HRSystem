using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.Data;
using HRSystem.DTO;
using HRSystem.DTO.Enums;
using HRSystem.Model;
using HRSystem.Repository.Contract;
using HRSystem.Repository.Implementation.Base;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Repository.Implementation
{
    public class EmployeeRepository : Repository<Employee>,IEmployeeRepository

    {
        private HRSystemContext _context;
        public EmployeeRepository(HRSystemContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> UserExist(string email)
        {
            return await _context.Employees.AnyAsync(x => x.Employee_EmailAddress == email);
        }

        public async Task<Employee> GetByEmail(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Employee_EmailAddress == email);
        }

        public async Task<List<UserListDto>> GetEncludeManager()
        {
            return await _context.Employees.Include(x => x.Manager)
                .Select(x=>new UserListDto
                {
                    Email = x.Employee_EmailAddress,
                    Username= x.Employee_Name,
                    Id = x.Employee_ID,
                    Address = x.Employee_Address,
                    Mobile = x.Employee_Mobile,
                    BirthDate = x.Employee_BithDate.ToShortDateString(),
                   ManagerId = x.ManagerId,
                   Manager = x.Manager.Employee_Name

                })
                .ToListAsync();
        }
    }
}