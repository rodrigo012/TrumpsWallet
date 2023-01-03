using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.Models;
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
    }
}
