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

        

        // GET: api/<ValuesController>
        /// <summary>
        /// Obtiene una lista de Transacciones.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de Transacciones.
        /// </remarks>
        /// <response code="200">OK. Devuelve una lista de transacciones.</response>        
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <returns></returns>
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


        // GET api/<ValuesController>
        /// <summary>
        /// Obtiene la Transaccion especificada.
        /// </summary>
        /// <remarks>
        /// Obtiene la Transaccion especificada.
        /// </remarks>
        /// <response code="200">OK. Devuelve la transaccion especificada.</response>        
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <returns></returns>
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

        // POST api/<ValuesController>
        /// <summary>
        /// Crea una Transaccion y la añade a la Base de Datos.
        /// </summary>
        /// <remarks>
        /// Crea una Transaccion y la añade a la Base de Datos.
        /// 
        /// Sample Request:
        /// 
        ///     Form-Data
        ///     {
        ///        "id": "Numero de identificacion de la transaccion",
        ///        "amount": "Cantidad de dinero",
        ///        "concept": "Concepto",
        ///        "date": "Fecha de creacion",
        ///        "type": "Deposito/Transferencia",
        ///        "accountID": "id de la cuenta desde la que se realiza",
        ///        "toAccountID": "id de la cuenta hacia la que se realiza"
        ///     }
        /// </remarks>
        /// <response code="204">OK. Agrega la nueva cuenta a la base de datos.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor.</response>
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
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }


        // PUT api/<ValuesController>/5
        /// <summary>
        /// Actualiza una Transaccion en la Base de Datos.
        /// </summary>
        /// <remarks>
        /// Actualiza una Transaccion en la Base de Datos.
        /// </remarks>
        /// <response code="200">OK. Actualiza la transaccion en la base de datos.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
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

        // DELETE api/<ValuesController>/5
        /// <summary>
        /// Elimina una Transaccion y la quita de la Base de Datos a través de un Id.
        /// </summary>
        /// <remarks>
        /// Elimina una Transaccion y la quita de la Base de Datos a través de un Id.
        /// </remarks>
        /// <response code="200">OK. Elimina la transaccion de la base de datos.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
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
                if (entity == null)
                {
                    return BadRequest("Los datos no son correctos");
                }
                await transactionService.DeleteTransactionAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor{0}", ex.Message));
            }
        }
    }
}
