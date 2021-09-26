using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastosManzia.Models;

namespace GastosManzia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly GastosManziaContext _context;

        public GastosController(GastosManziaContext context)
        {
            _context = context;
        }

        // GET: api/Gastos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGastos()
        {
            var gastos = await _context.Gastos.ToListAsync();

            if (gastos.Count() == 0 )
            {
                return NotFound("No hay gastos disponibles...");
            }
            return gastos;
        }

        // GET: api/Gastos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gasto>> GetGasto(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);

            if (gasto == null)
            {
                return NotFound();
            }

            return gasto;
        }

        // PUT: api/Gastos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGasto(int id, Gasto gasto)
        {
            if (id != gasto.Id)
            {
                return BadRequest();
            }

            _context.Entry(gasto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastoExists(id))
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

        // POST: api/Gastos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gasto>> PostGasto(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGasto", new { id = gasto.Id }, gasto);
        }

        // DELETE: api/Gastos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGasto(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null)
            {
                return NotFound();
            }

            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GastoExists(int id)
        {
            return _context.Gastos.Any(e => e.Id == id);
        }
    }
}
