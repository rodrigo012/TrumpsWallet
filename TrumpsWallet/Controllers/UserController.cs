using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using TrumpsWallet.Core.DTOs;
using TrumpsWallet.Core.Models;
using TrumpsWallet.Core.Services.Intefaces;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly WalletDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, WalletDbContext context, IMapper mapper, IConfiguration config)
        {
            this._userService = userService;
            _mapper = mapper;
            _context = context;
            _config = config;
        }

        // GET: api/<ValuesController>
        /// <summary>
        /// Obtiene una lista de Usuarios.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de Cuentas.
        /// </remarks>
        /// <response code="200">OK. Devuelve una lista de cuentas.</response>        
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var entity = await _userService.GetAllUserAsync();
                var results = _mapper.Map<IList<UserDTO>>(entity);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno de Servidor");
            }
        }

        // GET api/<ValuesController>
        /// <summary>
        /// Obtiene el Usuario especificado.
        /// </summary>
        /// <remarks>
        /// Obtiene el Usuario especificado.
        /// </remarks>
        /// <response code="200">OK. Devuelve el usuario especificado.</response>        
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _userService.GetUserAsync(id);
                var result = _mapper.Map<UserDTO>(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

        // POST api/<ValuesController>
        /// <summary>
        /// Crea un Usuario y lo añade a la Base de Datos.
        /// </summary>
        /// <remarks>
        /// Crea un Usuario y lo añade a la Base de Datos.
        /// 
        /// Sample Request:
        /// 
        ///     Form-Data
        ///     {
        ///        "id": "Numero de identificacion del usuario",
        ///        "firstName": "Nombre",
        ///        "lastName": "Apellido",
        ///        "email": "Email del usuario: user@example.com",
        ///        "password": "Clave de acceso",
        ///        "point": 0
        ///     }
        /// </remarks>
        /// <response code="204">OK. Agrega la nueva cuenta a la base de datos.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entity = _mapper.Map<User>(userDTO);
                await _userService.Insert(entity);
                return CreatedAtRoute("GetUser", new { id = entity.Id }, entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

        // PUT api/<ValuesController>/5
        /// <summary>
        /// Actualiza un Usuario en la Base de Datos.
        /// </summary>
        /// <remarks>
        /// Actualiza un Usuario en la Base de Datos.
        /// </remarks>
        /// <response code="200">OK. Actualiza el usuario en la base de datos.</response>        
        /// <response code="400">BadRequest. Ha ocurrido un error y no se pudo llevar a cabo la peticion.</response>
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entity = await _userService.GetUserAsync(id);

                if (entity == null)
                {
                    return BadRequest("Los datos recibidos no son correctos.");
                }

                // actualizar los valores de los atributos.
                entity.FirstName = userDTO.FirstName == null ? entity.FirstName : userDTO.FirstName;
                entity.LastName = userDTO.LastName == null ? entity.LastName : userDTO.LastName;
                entity.Password = userDTO.Password == null ? entity.Password : userDTO.Password;
                entity.Email = userDTO.Email == null ? entity.Email : userDTO.Email;

                await _userService.UpdateUserAsync(entity);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

        // DELETE api/<ValuesController>/5
        /// <summary>
        /// Elimina un Usuario y lo quita de la Base de Datos a través de un Id.
        /// </summary>
        /// <remarks>
        /// Elimina un Usuario y lo quita de la Base de Datos a través de un Id.
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
                var entity = await _userService.GetUserAsync(id);

                if (entity == null)
                {
                    return BadRequest("Los datos recibidos no son correctos.");
                }

                await _userService.DeleteUserAsync(id);

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }



        // Metodo para el logueo de usuarios
        /// <summary>
        /// Verifica la informacion de los usuarios registrados.
        /// </summary>
        /// <returns>Retorna el JwtToken</returns>
        /// <remarks>
        /// La informacion solicitada es
        /// 
        /// Sample request:
        /// 
        ///     POST / LOGIN
        ///     {
        ///         "email": "User@email.com",  *Required
        ///         "password": "ExamplePassword"  *Required
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">Retorna el JWT.</response>        
        /// <response code="400">BadRequest. Formato del objeto incorrecto.</response>
        /// <response code="500">InternalServerError, Error del servidor</response>
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
                var userList = await _userService.GetAllUserAsync();
                var user = (from t in _context.Set<User>() where t.Email.Equals(userDTO.Email) && t.Password.Equals(userDTO.Password) select t).FirstOrDefault();
                var result = _mapper.Map<UserDTO>(user);

                if (result == null)
                {
                    return Unauthorized(userDTO);
                }

                // las credenciales de acceso son validas, procedemos a construir el JWT con los valores adecuados.

                // leer los parametros Jwt de appsettings.json y asignar al objeto del tipo JWT.
                var jwt = _config.GetSection("Jwt").Get<Jwt>();

                // invocar el metodo que contruye la cadena del token.
                var mitoken = jwt.CreateToken(jwt, result);

                //return new
                //{
                //    message = "Token creado",
                //    success = true,
                //    result = new JwtSecurityTokenHandler().WriteToken(mitoken)
                //};

                return Accepted(new
                {
                    message = "Token creado",
                    success = true,
                    result = new JwtSecurityTokenHandler().WriteToken(mitoken)
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

    }
}