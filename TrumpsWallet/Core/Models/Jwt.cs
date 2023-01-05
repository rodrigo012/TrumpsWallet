using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Core.Models
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public JwtSecurityToken CreateToken(Jwt _jwt, User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", user.Email),
                new Claim("password", user.Password)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                  _jwt.Issuer,
                  _jwt.Audience,
                  claims,
                  expires: DateTime.Now.AddMinutes(240),
                  signingCredentials: credentials
            );

            return token;
        }

        public static dynamic ValidateToken(ClaimsIdentity identity, WalletDbContext context)
        {
            if (identity.Claims.Count() == 0)
            {
                return new
                {
                    message = "El token no es valido",
                    success = false,
                    result = ""
                };
            }

            // leer el valor del claims
            var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
            var user = (from t in context.Set<User>() where t.Email.Equals(id) select t).FirstOrDefault();

            if (user == null)
            {
                return new
                {
                    message = "Usuario no es valido",
                    success = false,
                    result = ""
                };
            }
            else
            {
                return new
                {
                    message = "Usuario es valido",
                    success = true,
                    result = user
                };
            }
        }
    }
}
