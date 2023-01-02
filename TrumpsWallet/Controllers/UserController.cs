//using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.Services.Intefaces;
using TrumpsWallet.Entities;
//using TrumpsWallet.Core.Models;
using Microsoft.AspNetCore.Http;
using TrumpsWallet.Repositories.Interfaces;
using TrumpsWallet.Repositories;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrumpsWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        //private readonly IMapper _mapper;
        
        public UserController(IUserService userService)
        {
            this._userService = userService;
            //this._mapper = mapper;
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
    }
}
