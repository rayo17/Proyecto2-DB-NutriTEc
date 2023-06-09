using ApiPosgreSQLDB.Data;
using ApiPosgreSQLDB.Estrcuturas_Swagger;
using ApiPosgreSQLDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;
using System.Data;



namespace ApiPosgreSQLDB.Controllers
{
    [ApiController]
    [Route("Nutricionista")]
    public class NutricionistaController : ControllerBase
    {
        private readonly NutriTecDBContext _context;
        private readonly ILogger<NutricionistaController> _logger;
        private readonly string _connectionString;

        public NutricionistaController(NutriTecDBContext context, ILogger<NutricionistaController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _connectionString = configuration.GetConnectionString("PostgreSQLConnection");
        }

        [HttpPost("RegistarNutricionista")]
        public async Task RegistrarNutricionista(Nutricionista c)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_Cedula", NpgsqlDbType.Varchar) { Value = c.cedula },
                new NpgsqlParameter("@p_Nombre", NpgsqlDbType.Varchar) { Value = c.nombre },
                new NpgsqlParameter("@p_Apellido1", NpgsqlDbType.Varchar) { Value = c.apellido1 },
                new NpgsqlParameter("@p_Apellido2", NpgsqlDbType.Varchar) { Value = c.apellido2 },
                new NpgsqlParameter("@p_CodigoBarras", NpgsqlDbType.Varchar){Value = c.codigobarras},
                new NpgsqlParameter("@p_Edad", NpgsqlDbType.Integer) { Value = c.edad },
                new NpgsqlParameter("@p_FechaNacimiento", NpgsqlDbType.Date) { Value = c.fechanacimiento },
                new NpgsqlParameter("@p_Peso", NpgsqlDbType.Integer) { Value = c.peso },
                new NpgsqlParameter("@p_IMC", NpgsqlDbType.Integer) { Value = c.imc },
                new NpgsqlParameter("@p_Direccion", NpgsqlDbType.Varchar) { Value = c.direccion },
                new NpgsqlParameter("@p_Foto", NpgsqlDbType.Varchar) { Value = c.foto },
                new NpgsqlParameter("@p_NumTarjetaCredito", NpgsqlDbType.Varchar) { Value = c.numtarjetacredito },
                new NpgsqlParameter("@p_TipoCobroID", NpgsqlDbType.Integer) { Value = c.tipocobroid },
                new NpgsqlParameter("@p_CorreoElectronico", NpgsqlDbType.Varchar) { Value = c.correoelectronico },
                new NpgsqlParameter("@p_Contrasena", NpgsqlDbType.Varchar) { Value = c.contrasena }
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT registrar_nutricionista(@p_Cedula, @p_Nombre, @p_Apellido1, @p_Apellido2, @p_CodigoBarras, @p_Edad, @p_FechaNacimiento, @p_Peso, @p_IMC, @p_Direccion, @p_Foto, @p_NumTarjetaCredito, @p_TipoCobroID, @p_CorreoElectronico, @p_Contrasena)", parameters);
        }
        [HttpPost("validarnutricionista")]
        public async Task<int> ValidarNutricionista([FromBody] ValidacionLogin v)
        {
            int resultado = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT validarloginnutricionista(@p_correo, @p_contrasena)";
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
        [HttpPost("obtener_cedula_nutricionista")]
        public async Task<string> ObtenerCedulaNutricionista([FromBody] ObtenerCedulaNutricionista ocn)
        {
            string cedulaNutricionista = string.Empty;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT ObtenerCedulaNutricionista(@p_correo)";
                    command.Parameters.AddWithValue("@p_correo", ocn.correo);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        cedulaNutricionista = result.ToString();
                    }
                }

                connection.Close();
            }

            return cedulaNutricionista;
        }
        [HttpPost("AsosiarPaciente")]
        public async Task AsosiarPaciente(Paciente p)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_clienteId", NpgsqlDbType.Varchar) { Value = p.clienteid },
                new NpgsqlParameter("@p_nutricionistaId", NpgsqlDbType.Varchar) { Value = p.nutricionistaid },
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT CrearNuevoPaciente(@p_clienteId, @p_nutricionistaId)", parameters);
        }
        [HttpGet("VisualizarClientesDisponiblesAsociacion")]
        public async Task<List<ClientesDisponibles>> ObtenerClientesDisponiblesAsociacion()
        {
            List<ClientesDisponibles> clientes = new List<ClientesDisponibles>();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM clientesdisponibles";

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientesDisponibles cliente = new ClientesDisponibles();
                            cliente.correoelectronico = reader.GetString(0);
                            cliente.nombre = reader.GetString(1);
                            cliente.apellido1 = reader.GetString(2);
                            cliente.apellido2 = reader.GetString(3);

                            // Obtener los demás atributos del producto según su posición en el reader

                            clientes.Add(cliente);
                        }
                    }
                }

                connection.Close();
            }

            return clientes;
        }
        [HttpPost("AsosiarPacienteaPlan")]
        public async Task AsosiarPacienteaPlan(AsignarPlanCliente apc)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@cliente_id", NpgsqlDbType.Varchar) { Value = apc.pacienteid },
                new NpgsqlParameter("@nutricionista_id", NpgsqlDbType.Varchar) { Value = apc.nutricionistaid },
                new NpgsqlParameter("@plan_id", NpgsqlDbType.Varchar) { Value = apc.planid },
                new NpgsqlParameter("@p_fechainicio", NpgsqlDbType.Date) { Value = apc.fechainicio },
                new NpgsqlParameter("@p_fechafinal", NpgsqlDbType.Date) { Value = apc.fechafinalizacion },
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT AsignarPlanCliente(@cliente_id, @nutricionista_id, @plan_id, @p_fechainicio, @p_fechafinal)", parameters);
        }
        [HttpGet("ObtenerPacientesPorCedula/{id}")]
        public IActionResult ObtenerPacientesPorCedula(string id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT nombre, correoelectronico FROM clientes " +
                                              "INNER JOIN pacientes ON clientes.correoelectronico = pacientes.clienteid " +
                                              "WHERE pacientes.nutricionistaid = @cedula";
                        command.Parameters.AddWithValue("@cedula", id);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            List<ObtenerPacientePorNutri> pacientes = new List<ObtenerPacientePorNutri>();

                            while (reader.Read())
                            {
                                ObtenerPacientePorNutri paciente = new ObtenerPacientePorNutri
                                {
                                    Nombre = reader.GetString(0),
                                    CorreoElectronico = reader.GetString(1)
                                };

                                pacientes.Add(paciente);
                            }

                            return Ok(pacientes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("planes/{id}")]
        public IActionResult ObtenerPlanesPorNutricionista(string id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT NombrePlan FROM PlanesAlimentacion WHERE NutricionistaID = @NutricionistaID";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NutricionistaID", id);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> nombresPlanes = new List<string>();

                            while (reader.Read())
                            {
                                string nombrePlan = reader.GetString(0);
                                nombresPlanes.Add(nombrePlan);
                            }

                            return Ok(nombresPlanes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("CrearPlanAlimentacion")]
        public IActionResult CrearPlanAlimentacion([FromBody] PlanAlimentacionData data)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT CrearPlanAlimentacion(@nombrePlan, @nutricionistaId, @desayunoProductoIds, @meriendaMananaProductoIds, @almuerzoProductoIds, @meriendaTardeProductoIds, @cenaProductoIds);", connection))
                {
                    // Asignar valores a los parámetros del comando
                    command.Parameters.AddWithValue("nombrePlan", data.PlanNombre);
                    command.Parameters.AddWithValue("nutricionistaId", data.Nutricionista);
                    command.Parameters.AddWithValue("desayunoProductoIds", data.TiemposComida.Desayuno.Select(p => p.Codigobarra).ToArray());
                    command.Parameters.AddWithValue("meriendaMananaProductoIds", data.TiemposComida.MeriendaManana.Select(p => p.Codigobarra).ToArray());
                    command.Parameters.AddWithValue("almuerzoProductoIds", data.TiemposComida.Almuerzo.Select(p => p.Codigobarra).ToArray());
                    command.Parameters.AddWithValue("meriendaTardeProductoIds", data.TiemposComida.MeriendaTarde.Select(p => p.Codigobarra).ToArray());
                    command.Parameters.AddWithValue("cenaProductoIds", data.TiemposComida.Cena.Select(p => p.Codigobarra).ToArray());


                    command.ExecuteNonQuery();
                }
            }

            return Ok();
        }

    }



}

