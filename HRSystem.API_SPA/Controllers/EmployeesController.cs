using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRSystem.API_SPA.Token;
using HRSystem.DTO;
using HRSystem.Model;
using HRSystem.Repository.Contract.Base;
using HRSystem.Repository.Implementation.Base;
using HRSystem.Service.Contract;
using HRSystem.Service.Contract.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.API_SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        
        private readonly IEmployeeService _employeeService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public EmployeesController(IEmployeeService employeeService,IMapper mapper, ITokenService tokenService, ITransactionService transactionService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _tokenService = tokenService;
            _transactionService = transactionService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var employees = await _employeeService.GetEncludeManager();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("lookUp")]
        public async Task<ActionResult> lookUp()
        {
            try
            {
                var employees = await _employeeService.userLookUp();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> register(UserRegisterDto userRegister)
        {
            if (ModelState.IsValid)
            {
                if (await _employeeService.UserExist(userRegister.Email))
                {
                    return BadRequest("Email already exists");
                }

                var emp = _mapper.Map<Employee>(userRegister);
                return Ok(await _employeeService.Register(emp, userRegister.Password));
            }

            return BadRequest(ModelState.ToString());
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> login(UserLoginDto userLogin)
        {
            if (!(await _employeeService.UserExist(userLogin.Email)))
            {
                return BadRequest("There is no user with email  "+ userLogin.Email);
            }

            var login = await _employeeService.Login(userLogin.Email, userLogin.Password);
            if (login != null)
            {
                var user = _mapper.Map<UserDataBrowseDto>(login);
                user.Token = _tokenService.GetToken(login);
                return Ok(user);
            }
            else
            {
                return Unauthorized("Password is wrong");
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(UserLoginDto userLogin)
        {
            if (!(await _employeeService.UserExist(userLogin.Email)))
            {
                return BadRequest("There is no user with email  " + userLogin.Email);
            }

            return Ok(await _employeeService.ResetPassword(userLogin.Email,userLogin.Password));
        }

        [HttpGet("LogOut/{userId}")]
        public async Task<ActionResult> LogOut(int userId)
        {
           
            return  Ok(await _transactionService.UpdateLogOut(userId));
        }
    }
}
