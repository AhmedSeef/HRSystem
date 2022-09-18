using HRSystem.Service.Contract;
using HRSystem.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace HRSystem.API_SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<ActionResult> Get(int userId)
        {
            try
            {
                var employees = await _transactionService.GetAllTransActionsUserId(userId);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
