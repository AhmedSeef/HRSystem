using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DTO;
using HRSystem.Model;
using HRSystem.Repository.Contract.Base;
using HRSystem.Service.Contract;
using HRSystem.Service.Implementation.Base;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Service.Implementation
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IRepository<Employee> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        #region login
        public async Task<Employee> Login(string email, string password)
        {
            var user = await _unitOfWork.EmployeeRepository.GetByEmail(email);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            var transcation = new Transaction
            {
                LoginUserId = user.Employee_ID,
                DateSignIn = DateTime.Now,
                DateSignOut = null
            };
            _unitOfWork.TransactionRepository.Insert(transcation);
            await _unitOfWork.complete();


            return user;
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        #endregion


        #region Register
        public async Task<bool> Register(Employee employee, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            employee.PasswordHash = passwordHash;
            employee.PasswordSalt = passwordSalt;

            _unitOfWork.EmployeeRepository.Insert(employee);

            return await _unitOfWork.complete();
        }


        public async Task<bool> UserExist(string email)
        {
            return await _unitOfWork.EmployeeRepository.UserExist(email);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        #endregion

        public async Task<bool> ResetPassword(string email, string password)
        {
            //default password
            string newPassword = string.IsNullOrEmpty(password)? "P@$$w0rd1991": password;
            var user = await _unitOfWork.EmployeeRepository.GetByEmail(email);
            CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _unitOfWork.EmployeeRepository.Update(user);
            return await _unitOfWork.complete();
        }

        public async Task<List<UserListDto>> GetEncludeManager()
        {
            return await _unitOfWork.EmployeeRepository.GetEncludeManager();
        }

        public async Task<List<UserLookUpDto>> userLookUp()
        {
            var data = await _unitOfWork.EmployeeRepository.GetAll();
            var result = data.Select(x => new UserLookUpDto
            {
                UserName = x.Employee_Name,
                Id = x.Employee_ID
            }).ToList();
            return result;
        }
    }
}
