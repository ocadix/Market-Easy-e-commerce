using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketEasyAPI.Context;
using MarketEasyAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketEasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly AppDbContext context;

        public UsuariosController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/values/3wdee-32323-dsdsde2
        [HttpGet("{UId}", Name = "ObtenerUsuario")]
        public ActionResult<Usuario> Get(string UId)
        {
            var User = context.Usuarios.FirstOrDefault(x => x.UsuarioId == Guid.Parse(UId));

            if(User == null)
            {
                return NotFound();
            }

            return User;

        }
        
        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody]Usuario User)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Los datos del usuario no pueden estar vacios");
            }

            context.Usuarios.Add(User);
            context.SaveChanges();

            return new CreatedAtRouteResult("", new { UId = User.UsuarioId.ToString() });
        }

        // PUT api/values/5
        [HttpPut("{UId}")]
        public ActionResult Put(string UId, [FromBody]Usuario User)
        {
            if (User.UsuarioId != Guid.Parse(UId))
            {
                return BadRequest("La informacion del usuario con concuerda");
            }

            context.Entry(User).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{UId}")]
        public ActionResult Delete(string UId)
        {
            var User = context.Usuarios.FirstOrDefault(x => x.UsuarioId == Guid.Parse(UId));

            if(User == null)
            {
                return NotFound("Usuario no fue encontrado");
            }

            try
            {
                context.Usuarios.Remove(User);
                context.SaveChanges();

                return Ok("Usuario borrado con exito");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
