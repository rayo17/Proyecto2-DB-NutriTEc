using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPosgreSQLDB.Models;
using ApiPosgreSQLDB.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiPosgreSQLDB.Controllers
{
   
    [ApiController]
    [Route("Administrador")]
    public class AdministradorController : ControllerBase
    {
        private readonly NutriTecDBContext _context;
        private readonly ILogger<AdministradorController> _logger;
        private readonly string _connectionString;

        public AdministradorController(NutriTecDBContext context, ILogger<AdministradorController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _connectionString = configuration.GetConnectionString("PostgreSQLConnection");
        }


        [HttpGet("validaradministrador")]
        public async Task<int> ValidarAdministrador(string correo, string contrasena)
        {
            int resultado = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT validarloginadministrador(@p_correo, @p_contrasena)";
                    command.Parameters.AddWithValue("@p_correo", correo);
                    command.Parameters.AddWithValue("@p_contrasena", contrasena);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        resultado = Convert.ToInt32(result);
                    }
                }

                connection.Close();
            }

            return resultado;
        }

        [HttpGet("validarproducto")]
        public async Task<string> ValidarProducto(string cod_barras, string validacion)
        {
            string resultado = "";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT validar_producto(@p_codigo_barras, @p_validacion)";
                    command.Parameters.AddWithValue("@p_codigo_barras", cod_barras);
                    command.Parameters.AddWithValue("@p_validacion", validacion);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        resultado = result.ToString();
                    }
                }

                connection.Close();
            }

            return resultado;
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

