﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        // DELETE api/<ValuesController>/5
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

        // PUT api/<ValuesController>/5
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

                return Accepted(new JwtSecurityTokenHandler().WriteToken(mitoken));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }

    }
}