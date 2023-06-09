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
using Newtonsoft.Json;

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


        [HttpPost("validaradministrador")]
        public async Task<int> ValidarAdministrador([FromBody] ValidacionLogin v)
        {
            int resultado = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT validarloginadministrador(@p_correo, @p_contrasena)";
                    command.Parameters.AddWithValue("@p_correo", v.correoelectronico);
                    command.Parameters.AddWithValue("@p_contrasena", v.contrasena);

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

        [HttpPost("validarproducto")]
        public async Task<string> ValidarProducto([FromBody] ValidarProducto v)
        {
            string resultado = "";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT validar_producto(@p_codigo_barras, @p_validacion)";
                    command.Parameters.AddWithValue("@p_codigo_barras", v.cod_barras);
                    command.Parameters.AddWithValue("@p_validacion", v.validacion);

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

        [HttpGet]
        public async Task<ActionResult<string>> ObtenerReporteCobro()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT GenerarReporteCobro()";

                var result = await command.ExecuteScalarAsync();

                // Comprueba si el resultado no es nulo y es de tipo string
                if (result != null && result != DBNull.Value && result is string json)
                {
                    return Ok(json);
                }
            }

            return BadRequest("No se pudo generar el reporte de cobro.");
        }





    }
}

