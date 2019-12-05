using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MarketEasyAPI.Context;
using MarketEasyAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketEasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public LoginController(AppDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }


        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        public  ActionResult Post([FromBody]Login login)
        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.Correo == login.Correo && x.Contrasena == login.Contrasena);

            if(usuario == null)
            {
                return Unauthorized();
            }



            return Ok(new { token = GenerarTokenJWT(usuario)});
        }




        private string GenerarTokenJWT(Usuario usuario)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );

            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );

            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UsuarioId.ToString()),
                new Claim("nombre", usuario.Nombres),
                new Claim("apellidos", usuario.Apellidos),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Correo)
            };


            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );


            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );


            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
