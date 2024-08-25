using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using proyecto100dias.Models;
using proyecto100dias.DTO.trabajadores;

namespace proyecto100dias.Controllers
{
    [Route("api/trabajadores")]
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
        public async Task<ActionResult<IEnumerable<trabajadoresDTO>>> Gettrabajadores()
        {
            return await _context.trabajadores
                .Select(x => nombreCompletoDTO(x))
                .ToListAsync();
        }

        // PUT: api/trabajadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttrabajadores(long id, ingresarTrabajadorDTO modificarDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var datosAntiguos = await _context.trabajadores.FindAsync(id);

            datosAntiguos.primer_nombre = modificarDatos.primerNombre;
            datosAntiguos.segundo_nombre = modificarDatos.segundoNombre;
            datosAntiguos.primer_apellido = modificarDatos.primerApellido;
            datosAntiguos.segundo_apellido = modificarDatos.segundoApellido;
            datosAntiguos.fecha_nacimiento = modificarDatos.fechaNacimiento;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (ModelState.IsValid)
            {                
                    return NotFound();
            }

            return NoContent();
        }

        // POST: api/trabajadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ingresarTrabajadorDTO>> Posttrabajadores(ingresarTrabajadorDTO datoTrabajador)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var datosIngresados = new trabajadores
            {
                primer_nombre = datoTrabajador.primerNombre,
                segundo_nombre = datoTrabajador.segundoNombre,
                primer_apellido = datoTrabajador.primerApellido,
                segundo_apellido = datoTrabajador.segundoApellido,
                rut_trabajador = datoTrabajador.rutTrabajador,
                fecha_nacimiento = datoTrabajador.fechaNacimiento
            };

            _context.trabajadores.Add(datosIngresados);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Gettrabajadores), new { id = datosIngresados.id }, (datosIngresados));
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

        private static trabajadoresDTO nombreCompletoDTO(trabajadores trabajadores) =>
            new trabajadoresDTO
            {
                nombreCompleto = trabajadores.primer_nombre+ " " + trabajadores.segundo_nombre + " " + trabajadores.primer_apellido + " " + trabajadores.segundo_apellido
            };
        private static ingresarTrabajadorDTO ingresoADTO(trabajadores trabajador) =>
            new ingresarTrabajadorDTO
            {
                primerNombre = trabajador.primer_nombre,
                segundoNombre = trabajador.segundo_nombre,
                primerApellido = trabajador.primer_apellido,
                segundoApellido = trabajador.segundo_apellido,
                rutTrabajador = trabajador.rut_trabajador,
                fechaNacimiento = trabajador.fecha_nacimiento
            };
    }
}
