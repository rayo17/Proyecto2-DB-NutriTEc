﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPosgreSQLDB.Models;
using ApiPosgreSQLDB.Data;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        [HttpPost("VisualizacionMedidas")]
        public async Task<ActionResult<IEnumerable<Medidas>>> ObtenerMedidasPorClienteYPeriodo(MedidasPorClienteYPeriodoRequest m)
        {
            var sql = "SELECT * FROM ObtenerMedidasPorClienteYPeriodo(@clienteId, @fechaInicio, @fechaFinal)";

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("clienteId", m.ClienteID);
                    cmd.Parameters.AddWithValue("fechaInicio", m.FechaInicio);
                    cmd.Parameters.AddWithValue("fechaFinal", m.FechaFinal);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        var medidasList = new List<Medidas>();

                        while (await reader.ReadAsync())
                        {
                            var medidas = new Medidas
                            {
                                id = reader.GetInt32("MedidaId"),
                                clienteid = reader.GetString("ClienteId"),
                                fecha = reader.GetDateTime("Fecha"),
                                cintura = reader.GetInt32("Cintura"),
                                cuello = reader.GetInt32("Cuello"),
                                caderas = reader.GetInt32("Caderas"),
                                porcentajemusculo = reader.GetInt32("Porcentaje_muscular"),
                                porcentajegrasa = reader.GetInt32("Porcentaje_Grasa"),
                                pesoactual = reader.GetInt32("PesoActual")
                            };

                            medidasList.Add(medidas);
                        }

                        return Ok(medidasList);
                    }
                }
            }
        }


        /*
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
                .FromSqlRaw("SELECT * FROM ObtenerMedidasPorClienteYPeriodo(@p_clienteid, @p_fechainicio, @p_fechafinal)", parameters)
                .ToListAsync();

            return Ok(consulta);
        }*/
        /*
        [HttpPost("PlanesPaciente")]
        public async Task<ActionResult<string>> Post([FromBody] datoEVPA v)
        {
            string result = "";

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM visualizarPlanesPacientes(@p_ClienteID)";
                    command.Parameters.AddWithValue("@p_ClienteID", v.paciente);

                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result += "(";
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result += reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString();
                                if (i < reader.FieldCount - 1)
                                {
                                    result += ",";
                                }
                            }
                            result += ")\n";
                        }
                    }
                }

                connection.Close();
            }

            return result;
        }*/



    }

}
