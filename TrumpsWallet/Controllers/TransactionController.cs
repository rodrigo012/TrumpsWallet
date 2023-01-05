using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.DTOs;
using TrumpsWallet.Core.Services.Interfaces;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly IMapper mapper;
        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            this.transactionService = transactionService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] TransactionDTO transactionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entity = mapper.Map<Transaction>(transactionDTO);
                await transactionService.Insert(entity);
                return CreatedAtRoute("GetTransaction", new { id = entity.Id }, entity);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {

                var entity = await transactionService.GetAllTransactionsAsync();
                var results = mapper.Map<IList<TransactionDTO>>(entity);

                return Ok(results);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno de Servidor");
            }
        }

        [HttpGet("{id:int}", Name ="GetTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await transactionService.GetTransactionAsync(id);
                var result = mapper.Map<TransactionDTO>(entity);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor{0}",ex.Message));
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                var entity = await transactionService.GetTransactionAsync(id);
                if(entity == null)
                {
                    return BadRequest("Los datos no son correctos");
                }
                await transactionService.DeleteTransactionAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor{0}", ex.Message));
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] TransactionDTO transactionDTO)
        {
            if(!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var entity = await transactionService.GetTransactionAsync(id);

                if (entity == null)
                {
                    return BadRequest("Los datos no son correctos.");
                }
                mapper.Map(transactionDTO, entity);
                await transactionService.UpdateTransactionAsync(entity);

                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ($"Error interno del Servidor{0}", ex.Message));
            }
        }
    }
}
