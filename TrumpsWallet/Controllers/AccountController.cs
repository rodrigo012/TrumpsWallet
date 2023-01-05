using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.DTOs;
using TrumpsWallet.Core.Services;
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

                mapper.Map(accountDTO, entity);
                await accountService.UpdateAccountAsync(entity);
                
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

        // Creación de endpoints de tipo operaciones
        [Route("Depositar")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DepositAccount([FromBody] AccountDTO accountDTO)
        {
            HttpClient client = new HttpClient();
            //Hacer...
            /*
                Story # 40
                COMO usuario standard 
                QUIERO realizar un depósito en mi cuenta
                PARA aumentar el saldo de la misma
 
                Criterios de aceptación: 
                POST /accounts/{id}

                se deberá validar el número de cuenta correspondiente al id del usuario (obtenido del token) 
                y aumentar el saldo de la misma según el importe recibido. 
                Adicionalmente se debe loguear la operación en la entidad Transactions.
             */
            try
            {
                var response = await client.GetAsync("http://api/User/Authorize"); // Simulando el Id del usuario (obtenido del token).
                //if (response.IsSuccessStatusCode)
                //{
                //    var user = await response.Content.ReadAsStringAsync();
                //}
                
                if (accountDTO.money <= 0)  // validar el monto a depositar.
                {
                    return BadRequest("El monto del deposito no es valido.");
                }
                else
                {
                    var account = await accountService.GetAccountAsync(1);
                    if (account == null)    // validar si existe la cuenta asociada al Id usuario.
                    {
                        return BadRequest("Usuario no tiene una cuenta disponible.");
                    }
                    if (account.isBlocked) // validar si la cuenta esta activa.
                    {
                        return BadRequest("La cuenta se encuentra bloqueada.");
                    }
                    // incrementar el monto de la cuenta.
                    account.money += accountDTO.money;
                    Transaction trx = new Transaction()
                    {
                        //account_id = account.Id,
                        //to_account_id = account.Id,
                        //user_id = account.user_id,
                        //amount = accountDTO.money,
                        //type = TOPUP,
                        //concept = "Deposito en Cuenta",
                        //date = DateTime.Now
                    };
                    //_unitOfWork.Accounts.Update(account);
                    //await _unitOfWork.Transactions.Insert(trx);
                    //await _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
                // Colocar aqui la respuesta de error. Igual a los otros ActionResult.
                throw;
            }
            return Ok();
        }
    }
}
