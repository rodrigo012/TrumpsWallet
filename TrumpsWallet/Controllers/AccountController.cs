using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.DTOs;
using TrumpsWallet.Core.Services.Interfaces;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
        }

        // GET: /accounts
        /// <summary>
        /// Obtiene una lista de Cuentas.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de Cuentas.
        /// </remarks>
        /// <response code="200">OK. Devuelve una lista de Cuentas.</response>        
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var entity = await accountService.GetAllAccountAsync();
                var results = mapper.Map<IList<AccountDTO>>(entity);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno de Servidor");
            }
        }


        // GET: /account/id
        /// <summary>
        /// Obtiene la Cuenta especificada.
        /// </summary>
        /// <remarks>
        /// Obtiene la Cuenta especificada.
        /// </remarks>
        /// <response code="200">OK. Devuelve la Cuenta especificada.</response>        
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await accountService.GetAccountAsync(id);
                var result = mapper.Map<AccountDTO>(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

        // POST: /account
        /// <summary>
        /// Crea una Cuenta y la añade a la Base de Datos.
        /// </summary>
        /// <remarks>
        /// Crea una Cuenta y la añade a la Base de Datos.
        /// 
        /// Sample Request:
        /// 
        ///     Form-Data
        ///     {
        ///        "id": "Numero de identificacion de la cuenta",
        ///        "creationDate": "Fecha de creacion",
        ///        "money": "Cantidad de dinero",
        ///        "isBlocked": "($binary)",
        ///        "userId": "Numero de identificacion del usuario"
        ///     }
        /// </remarks>
        /// <response code="204">OK. Agrega la nueva cuenta a la base de datos.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] AccountDTO accountDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entity = mapper.Map<Account>(accountDTO);
                await accountService.Insert(entity);
                return CreatedAtRoute("GetAccount", new { id = entity.Id }, entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

        // PUT: /account
        /// <summary>
        /// Actualiza una Cuenta en la Base de Datos.
        /// </summary>
        /// <remarks>
        /// Actualiza una Cuenta en la Base de Datos.
        /// </remarks>
        /// <response code="200">OK. Actualiza la cuenta en la base de datos.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] AccountDTO accountDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entity = await accountService.GetAccountAsync(id);

                // validar si existe el registro en la base de datos.
                if (entity == null)
                {
                    return BadRequest("Los datos recibidos no son correctos.");
                }

                // actualizar los valores de campos.
                entity.isBlocked = accountDTO.isBlocked == true ? accountDTO.isBlocked : entity.isBlocked;
                entity.money = accountDTO.money == 0 ? entity.money : accountDTO.money;

                await accountService.UpdateAccountAsync(entity);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }


        // DELETE: /account/id
        /// <summary>
        /// Elimina una Cuenta y la quita de la Base de Datos a través de un Id.
        /// </summary>
        /// <remarks>
        /// Elimina una Cuenta y la quita de la Base de Datos a través de un Id.
        /// </remarks>
        /// <response code="200">OK. Elimina la cuenta de la base de datos.</response>        
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
                var entity = await accountService.GetAccountAsync(id);

                // validar si existe el registro en la base de datos.
                if (entity == null)
                {
                    return BadRequest("Los datos recibidos no son correctos.");
                }

                await accountService.DeleteAccountAsync(id);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

        
    }
}
