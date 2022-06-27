using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using UCity.Data.Dtos.Account;
using UCity.Data.Models.Auth;
using UCity.Logic;

namespace UCity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : UCityControllerBase
    {
        private readonly IAccountsLogic _accountsLogic;

        public AccountsController(IAccountsLogic accountsLogic)
        {
            _accountsLogic = accountsLogic;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AccountAuthenticateResponse>> Authenticate(AccountAuthenticateRequest request)
        {
            var response = await _accountsLogic.Authenticate(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AccountReadDto>> Create(AccountCreateDto model)
        {
            if (model.Role == Role.Admin)
            {
                throw new ForbiddenException("You cannot create the admin user.");
            }

            var account = await _accountsLogic.Create(model);
            return Ok(account);
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountReadDto>>> GetAll()
        {
            var accounts = await _accountsLogic.GetAll();
            return Ok(accounts);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            await _accountsLogic.Delete(id);
            return Ok($"Account with id: '{id}' deleted successfully");
        }
    }
}