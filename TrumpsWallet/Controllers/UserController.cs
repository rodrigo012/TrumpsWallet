//using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.Services.Intefaces;
using TrumpsWallet.Entities;
//using TrumpsWallet.Core.Models;
using Microsoft.AspNetCore.Http;
using TrumpsWallet.Repositories.Interfaces;
using TrumpsWallet.Repositories;
using TrumpsWallet.Core.DTOs;
using TrumpsWallet.DataAccess;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrumpsWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly WalletDbContext _context;
        private readonly IMapper _mapper;
        
        public UserController(IUserService userService, WalletDbContext context, IMapper mapper)
        {
            this._userService = userService;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _userService.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await _userService.GetUser(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {

            await _userService.InsertAsync(user);
            return new CreatedAtRouteResult("getUser", new { id = user.Id }, user);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, User user)
        {
            await _userService.UpdateUser(id, user);
            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteById(id);
            return Ok();
        }

        // Metodo para el logueo de usuarios
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // se busca en la BD la existencia de las credenciales
                var userList = await _userService.GetAll();
                var user = (from t in _context.Set<User>() where t.Email.Equals(userDTO.Email) && t.Password.Equals(userDTO.Password) select t).FirstOrDefault();
                var result = _mapper.Map<UserDTO>(user);

                if (result == null)
                {
                    return Unauthorized(userDTO);
                }

                return Accepted();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }
    }
}
