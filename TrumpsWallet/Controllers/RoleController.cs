using TrumpsWallet.Core;
using TrumpsWallet.Entities;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrumpsWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService _service)
        {
            roleService = _service;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<List<Role>> Get()
        {
            return await roleService.GetAllRoles();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            return await roleService.GetById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post(Role role)
        {
            {
                await roleService.InsertAsync(role);
                return new CreatedAtRouteResult("getRole", new { id = role.Id }, role);
            }
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Role role)
        {
            await roleService.UpdateRole(id, role);
            return NoContent();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await roleService.DeleteById(id);
            return Ok();
        }

    }
}
