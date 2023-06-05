using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPosgreSQLDB.Models;
using ApiPosgreSQLDB.Data;

namespace ApiPosgreSQLDB.Controllers
{
   
    [ApiController]
    [Route("Administrador")]
    public class AdministradorController : ControllerBase
    {
        private readonly NutriTecDBContext _context;

        public AdministradorController(NutriTecDBContext context)
        {
            _context = context;
        }

        // GET: api/Administrador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradores()
        {
            return await _context.administradores.ToListAsync();
        }

        // GET: api/Administrador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var administrador = await _context.administradores.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // POST: api/Administrador
        [HttpPost]
        public async Task<ActionResult<Administrador>> CreateAdministrador(Administrador administrador)
        {
            _context.administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdministrador), new { id = administrador.id }, administrador);
        }

        // PUT: api/Administrador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdministrador(int id, Administrador administrador)
        {
            if (id != administrador.id)
            {
                return BadRequest();
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // DELETE: api/Administrador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var administrador = await _context.administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.administradores.Remove(administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.administradores.Any(a => a.id == id);
        }
    }
}

