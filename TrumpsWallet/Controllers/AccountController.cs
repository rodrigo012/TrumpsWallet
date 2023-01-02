using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.Models;
using TrumpsWallet.Core.Services;
using TrumpsWallet.Core.Services.Interfaces;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(AccountDto account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                await accountService.Insert(account);
                return Ok(account);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountDto>>> Get()
        {
            return await accountService.GetAllAccountAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> Get(int id)
        {
            return await accountService.GetAccountAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await accountService.DeleteAccountAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(AccountDto accountDto)
        {
            await accountService.UpdateAccountAsync(accountDto);
            return Ok();
        }
    }
}
