using System.Collections.Generic;
using System.Threading.Tasks;
using HRSystem.DTO;
using HRSystem.Model;
using HRSystem.Repository.Contract.Base;

namespace HRSystem.Repository.Contract
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<bool> UserExist(string email);
        Task<Employee> GetByEmail(string email);
        Task<List<UserListDto>> GetEncludeManager();
    }
}