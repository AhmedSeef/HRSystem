using System.Collections.Generic;
using System.Threading.Tasks;
using HRSystem.DTO;
using HRSystem.Model;
using HRSystem.Service.Contract.Base;

namespace HRSystem.Service.Contract
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<bool> Register(Employee employee, string password);
        Task<bool> UserExist(string email);
        Task<Employee> Login(string email,string password);
        Task<bool> ResetPassword(string email,string password);
        Task<List<UserListDto>> GetEncludeManager();
        Task<List<UserLookUpDto>> userLookUp();
    }
}