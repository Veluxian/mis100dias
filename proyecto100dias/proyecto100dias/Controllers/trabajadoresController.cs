using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto100dias.Models;

namespace proyecto100dias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class trabajadoresController : ControllerBase
    {
        private readonly pieroDbContext _context;

        public trabajadoresController(pieroDbContext context)
        {
            _context = context;
        }

        // GET: api/trabajadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<trabajadores>>> Gettrabajadores()
        {
            return await _context.trabajadores.ToListAsync();
        }

        // GET: api/trabajadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<trabajadores>> Gettrabajadores(long id)
        {
            var trabajadores = await _context.trabajadores.FindAsync(id);

            if (trabajadores == null)
            {
                return NotFound();
            }

            return trabajadores;
        }

        // PUT: api/trabajadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttrabajadores(long id, trabajadores trabajadores)
        {
            if (id != trabajadores.id)
            {
                return BadRequest();
            }

            _context.Entry(trabajadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!trabajadoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/trabajadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<trabajadores>> Posttrabajadores(trabajadores trabajadores)
        {
            _context.trabajadores.Add(trabajadores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettrabajadores", new { id = trabajadores.id }, trabajadores);
        }

        // DELETE: api/trabajadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetrabajadores(long id)
        {
            var trabajadores = await _context.trabajadores.FindAsync(id);
            if (trabajadores == null)
            {
                return NotFound();
            }

            _context.trabajadores.Remove(trabajadores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool trabajadoresExists(long id)
        {
            return _context.trabajadores.Any(e => e.id == id);
        }
    }
}
