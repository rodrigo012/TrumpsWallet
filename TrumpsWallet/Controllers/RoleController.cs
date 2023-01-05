using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.DTOs;
using TrumpsWallet.Core.Services.Interfaces;

namespace TrumpsWallet.Controllers
{
    /// <summary>
    /// WebApi Gestion de Activities
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;


        public RoleController(IRoleService _service, IMapper _mapper)
        {
            roleService = _service;
            mapper = _mapper;
        }



        // GET: /roles
        /// <summary>
        /// Obtiene una lista de Roles.
        /// </summary>
        /// <remarks>
        /// Obtiene una lista de Roles.
        /// </remarks>
        /// <response code="200">OK. Devuelve una lista de Roles.</response>        
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await roleService.GetAllRoles();
                var results = mapper.Map<IList<RoleDTO>>(roles);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno de Servidor");
            }
        }



        // GET: /roles/id
        /// <summary>
        /// Obtiene el Rol especificado.
        /// </summary>
        /// <remarks>
        /// Obtiene el Rol especificado.
        /// </remarks>
        /// <response code="200">OK. Devuelve el Rol especificado.</response>        
        /// <response code="500">InternalServerError, Error del servidor.</response>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var example = await roleService.GetById(id);
                var result = mapper.Map<RoleDTO>(example);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ($"Error Interno del Servidor {0}", ex.Message));
            }
        }


    }
}
