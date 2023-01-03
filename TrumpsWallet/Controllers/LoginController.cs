using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrumpsWallet.Core.Models;
using TrumpsWallet.Core.Services.Intefaces;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUserService userService;
        private readonly WalletDbContext context;

        public LoginController(IConfiguration configuration, IUserService userService, WalletDbContext context)
        {
            this.configuration = configuration;
            this.userService = userService;
            this.context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<dynamic> Post([FromBody] Login login)
        {
            var name = login.user;
            var password = login.password;

            // se busca en la BD la existencia de las credenciales
            var userList = await userService.GetAll();
            var user = (from t in context.Set<User>() where t.FirstName.Equals(name) && t.Password.Equals(password) select t).FirstOrDefault();

            if (user == null)
            {
                return new
                {
                    success = false,
                    message = "Usuario o Contraseña no son validas.",
                    result = ""
                };
            }

            return new
            {
                message = "Usuario logueado.",
                success = true,
            };
        }
    }
}
