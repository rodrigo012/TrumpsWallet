using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.Services.Interfaces;
using TrumpsWallet.Entities;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrumpsWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        
        public TransactionController(ITransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> Get()
        {
            return await _transactionService.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> Get(int id)
        {
            return await _transactionService.GetTransaction(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post(Transaction transaction)
        {
            {
                await _transactionService.InsertAsync(transaction);
                return new CreatedAtRouteResult("getTransaction", new { id = transaction.Id }, transaction);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Transaction transaction)
        {
            await _transactionService.UpdateTransaction(id, transaction);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _transactionService.DeleteById(id);
            return Ok();
        }
    }
}
