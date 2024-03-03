using AgenciaViagem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AgenciaViagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly AgenciaDbContext _context;
        public ViagemController(AgenciaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Viagem>GetViagems()
        {
            return _context.viagem;
        }

        [HttpGet("{id}")]
        public IActionResult GetViagemPorId( int id) {
        Viagem viagem= _context.viagem.SingleOrDefault(m =>m.Id ==id);
            if (viagem == null)
            {
                return NotFound();
            }
            return new ObjectResult(viagem);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarViagem(int id, [FromBody] Viagem item)
        {
            if (id!=item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State=EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
            
        }
        [HttpPost]
        public IActionResult AdicionarViagem([FromBody] Viagem item)
        {
            if (item==null)
            {
                return BadRequest();
            }
            _context.viagem.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
               
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarViagem(int id)
        {
            var viagem = _context.viagem.SingleOrDefault(m=> m.Id==id);
            if (viagem == null)
            {
                return BadRequest();
            }
            _context.viagem.Remove(viagem);
            _context.SaveChanges();
            return Ok(viagem);
        }

    }

}
