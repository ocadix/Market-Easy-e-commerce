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
    public class ProductosController : Controller
    {
        private readonly AppDbContext context;

        public ProductosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/productos
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return context.Productos.ToList();
        }

        // GET api/productos/Producto
        [HttpGet("{PId}")]
        public ActionResult<Producto> Get(string PId)
        {

            var producto = context.Productos.FirstOrDefault(x => x.ProductoId == Guid.Parse(PId));

            if(producto == null)
            {
                return NotFound("Producto no encontrado");
            }

            return producto;
        }

        // POST api/producto
        [HttpPost]
        public ActionResult Post([FromBody]Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Los datos del rpoducto son erroneos");
            }


            context.Productos.Add(producto);
            context.SaveChanges();

            return Ok("Producto creado correctamente");
        }

        // PUT api/values/5
        [HttpPut("{PId}")]
        public ActionResult Put(string PId, [FromBody]Producto producto)
        {
            if(producto.ProductoId != Guid.Parse(PId))
            {
                return BadRequest("El producto a modificar no concuerda");
            }

            context.Entry(producto).State = EntityState.Modified;
            context.SaveChanges();

            return Ok("Producto modificado exitosamente");
        }

        // DELETE api/values/5
        [HttpDelete("{PId}")]
        public ActionResult Delete(string PId)
        {
            var producto = context.Productos.FirstOrDefault(x => x.ProductoId == Guid.Parse(PId));

            if(producto == null)
            {
                return NotFound("Producto no encontrado");
            }

            context.Productos.Remove(producto);
            context.SaveChanges();

            return Ok("Producto eliminado con exito");
        }
    }
}
