using TrumpsWallet.Core;
using TrumpsWallet.Entities;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.Services.Interfaces;
using AutoMapper;
using TrumpsWallet.Core.Services;
using TrumpsWallet.Core.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrumpsWallet.Controllers
{
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


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
