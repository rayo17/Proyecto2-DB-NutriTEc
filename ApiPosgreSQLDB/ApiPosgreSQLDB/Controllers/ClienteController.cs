using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPosgreSQLDB.Models;
using ApiPosgreSQLDB.Data;
using ApiPosgreSQLDB.Estrcuturas_Swagger;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Microsoft.Extensions.Logging;

namespace ApiPosgreSQLDB.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly NutriTecDBContext _context;
        private readonly ILogger<ClienteController> _logger;
        private readonly string _connectionString;

        public ClienteController(NutriTecDBContext context, ILogger<ClienteController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _connectionString = configuration.GetConnectionString("PostgreSQLConnection");
        }



        [HttpPost("validarcliente")]
        public async Task<int> ValidarCliente([FromBody] ValidacionLogin v)
        {
            int resultado = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT validarlogincliente(@p_correo, @p_contrasena)";
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





        [HttpPost("registrarcliente")]
        public async Task RegistrarCliente(Cliente c)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_CorreoElectronico", NpgsqlDbType.Varchar) { Value = c.correoelectronico },
                new NpgsqlParameter("@p_Nombre", NpgsqlDbType.Varchar) { Value = c.nombre },
                new NpgsqlParameter("@p_Apellido1", NpgsqlDbType.Varchar) { Value = c.apellido1 },
                new NpgsqlParameter("@p_Apellido2", NpgsqlDbType.Varchar) { Value = c.apellido2 },
                new NpgsqlParameter("@p_Edad", NpgsqlDbType.Integer) { Value = c.edad },
                new NpgsqlParameter("@p_FechaNacimiento", NpgsqlDbType.Date) { Value = c.fechanacimiento },
                new NpgsqlParameter("@p_Peso", NpgsqlDbType.Integer) { Value = c.peso },
                new NpgsqlParameter("@p_IMC", NpgsqlDbType.Integer) { Value = c.imc },
                new NpgsqlParameter("@p_PaisResidencia", NpgsqlDbType.Varchar) { Value = c.paisresidencia },
                new NpgsqlParameter("@p_ConsumoDiarioCalorias", NpgsqlDbType.Integer) { Value = c.consumodiariocalorias },
                new NpgsqlParameter("@p_Contrasena", NpgsqlDbType.Varchar) { Value = c.contrasena }
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT registrar_cliente(@p_CorreoElectronico, @p_Nombre, @p_Apellido1, @p_Apellido2, @p_Edad, @p_FechaNacimiento, @p_Peso, @p_IMC, @p_PaisResidencia, @p_ConsumoDiarioCalorias, @p_Contrasena)", parameters);
        }

        [HttpPost("registrarmedidas")]
        public async Task RegistrarMedidas(Medidas c)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_ID", NpgsqlDbType.Integer) { Value = c.id },
                new NpgsqlParameter("@p_ClienteID", NpgsqlDbType.Varchar) { Value = c.clienteid },
                new NpgsqlParameter("@p_Fecha", NpgsqlDbType.Date) { Value = c.fecha },
                new NpgsqlParameter("@p_Cintura", NpgsqlDbType.Integer) { Value = c.cintura },
                new NpgsqlParameter("@p_Cuello", NpgsqlDbType.Integer) { Value = c.cuello },
                new NpgsqlParameter("@p_Caderas", NpgsqlDbType.Integer) { Value = c.caderas },
                new NpgsqlParameter("@p_PorcentajeMusculo", NpgsqlDbType.Integer) { Value = c.porcentajemusculo },
                new NpgsqlParameter("@p_PorcentajeGrasa", NpgsqlDbType.Integer) { Value = c.porcentajegrasa },
                new NpgsqlParameter("@p_PesoActual", NpgsqlDbType.Integer) { Value = c.pesoactual },
                
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT registrar_medidas(@p_ID, @p_ClienteID, @p_Fecha, @p_Cintura, @p_Cuello, @p_Caderas, @p_PorcentajeMusculo, @p_PorcentajeGrasa, @p_PesoActual)", parameters);
        }

        [HttpDelete("eliminarcliente")]
        public async Task EliminarCliente(string correo)
        {
            var parameters = new[]
            {
                
                new NpgsqlParameter("@p_CorreoElectronico", NpgsqlDbType.Varchar) { Value = correo }
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_cliente(@p_CorreoElectronico)", parameters);
        }

        [HttpPost("ingresarregistrodiario")]
        public async Task IngresarRegistroDiario(RegistroDiario rd)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_ID", NpgsqlDbType.Integer) { Value = rd.id },
                new NpgsqlParameter("@p_ClienteID", NpgsqlDbType.Varchar) { Value = rd.clienteid },
                new NpgsqlParameter("@p_TiempoComidaID", NpgsqlDbType.Integer) { Value = rd.tiempocomidaid },
                new NpgsqlParameter("@p_Fecha", NpgsqlDbType.Date) { Value = rd.fecha },
                new NpgsqlParameter("@p_ProductoID", NpgsqlDbType.Varchar) { Value = rd.productoid },
                

            };

            await _context.Database.ExecuteSqlRawAsync("SELECT insertar_registro_diario(@p_ID, @p_ClienteID, @p_TiempoComidaID, @p_Fecha, @p_ProductoID)", parameters);
        }

        [HttpPost("Consulta_por_Periodo_medidas")]
        
        public async Task<IActionResult> Consultaperiodoregistro(ConsultaPeriodoMedidas cpm)
        {
            var parameters = new[]
            {
        new NpgsqlParameter("@p_clienteid", NpgsqlDbType.Varchar) { Value = cpm.correocliente },
        new NpgsqlParameter("@p_fechainicio", NpgsqlDbType.Date) { Value = cpm.fechainicio },
        new NpgsqlParameter("@p_fechafinal", NpgsqlDbType.Date) { Value = cpm.fechafinal }
    };

            var consulta = await _context.medidas
                .FromSqlRaw("SELECT * FROM obtenremedidas(@p_clienteid, @p_fechainicio, @p_fechafinal)", parameters)
                .ToListAsync();

            return Ok(consulta);
        }

        [HttpGet("obtenerproductoscliente/{id}")]
        public IActionResult ObtenerProductosCliente(string id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT p.CodigoBarra, p.Nombre, p.taman_porcion, p.energia, p.grasa, p.sodio, p.carbohidratos, p.proteina, p.vitaminas, p.calcio, p.hierro, p.descripcion FROM Productos p JOIN CreadorProductos cp ON p.CodigoBarra = cp.ProductosID WHERE cp.ClienteID = @id AND p.EstadoProducto = false";
                        command.Parameters.AddWithValue("id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            var productos = new List<ObtenerProductosCliente>();

                            while (reader.Read())
                            {
                                var producto = new ObtenerProductosCliente
                                {
                                    CodigoBarra = reader.GetString(0),
                                    Nombre = reader.GetString(1),
                                    TamanPorcion = reader.GetInt32(2),
                                    Energia = reader.GetInt32(3),
                                    Grasa = reader.GetInt32(4),
                                    Sodio = reader.GetInt32(5),
                                    Carbohidratos = reader.GetInt32(6),
                                    Proteina = reader.GetInt32(7),
                                    Vitaminas = reader.GetString(8),
                                    Calcio = reader.GetInt32(9),
                                    Hierro = reader.GetInt32(10),
                                    Descripcion = reader.GetString(11)
                                };

                                productos.Add(producto);
                            }

                            return Ok(productos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al obtener los productos del cliente.");
                    return StatusCode(500);
                }
            }
        }

        [HttpGet("ObtenerPlanCliente{clienteId}")]
        public IActionResult ObtenerPlanAlimentacion(string clienteId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("SELECT ObtenerPlanAlimentacion2(@p_ClienteID)::jsonb", connection))
                {
                    command.Parameters.AddWithValue("p_ClienteID", clienteId);
                    command.CommandType = CommandType.Text;

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string jsonResult = reader[0].ToString();
                        return Ok(jsonResult);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        /*
        public IActionResult ObtenerPlanAlimentacion(string clienteId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("SELECT ObtenerPlanAlimentacion2(@p_ClienteID)", connection))
                {
                    command.Parameters.AddWithValue("p_ClienteID", clienteId);
                    command.CommandType = CommandType.Text;

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string jsonResult = result.ToString();
                        return Ok(jsonResult);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }
        */











    }
}
