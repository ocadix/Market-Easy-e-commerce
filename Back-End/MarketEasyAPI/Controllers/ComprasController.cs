using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketEasyAPI.Context;
using MarketEasyAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketEasyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComprasController : Controller
    {
        private readonly AppDbContext context;

        public ComprasController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<Compras> Get()
        {
            return context.Compras.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
