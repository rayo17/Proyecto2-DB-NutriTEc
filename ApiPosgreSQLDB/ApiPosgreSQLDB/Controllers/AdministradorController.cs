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
using System.Data;

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

        // Endpoint para validar el administrador recibe correo electronico y contraseña de administrador y compara a la base de datos
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
        // Endpoint para validar el producto, recibe el codigo barras y la aceptaciono negacion por parte de admin
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
        // Endpoint para obtener el reporte de cobro, lo realiza a partir de un store procedure que contiene un select
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

        [HttpGet("inactivos")]
        public async Task<IActionResult> ObtenerProductosInactivos()
        {
            
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM Productos WHERE EstadoProducto = False", connection))
                {
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        List<Producto> productos = new List<Producto>();
                        while (await reader.ReadAsync())
                        {
                            Producto producto = new Producto
                            {
                                codigobarra = reader.GetString("CodigoBarra"),
                                nombre = reader.GetString("Nombre"),
                                taman_porcion = reader.GetInt32("taman_porcion"),
                                energia = reader.GetInt32("energia"),
                                grasa = reader.GetInt32("grasa"),
                                sodio = reader.GetInt32("sodio"),
                                carbohidratos = reader.GetInt32("carbohidratos"),
                                proteina = reader.GetInt32("proteina"),
                                vitaminas = reader.GetString("vitaminas"),
                                calcio = reader.GetInt32("calcio"),
                                hierro = reader.GetInt32("hierro"),
                                descripcion = reader.GetString("descripcion"),
                                estadoproducto = reader.GetBoolean("EstadoProducto")
                            };
                            productos.Add(producto);
                        }

                        return Ok(productos);
                    }
                }
            }
        }



    }
}

