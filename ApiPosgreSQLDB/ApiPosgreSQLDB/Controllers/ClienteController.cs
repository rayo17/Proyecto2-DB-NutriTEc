using Microsoft.AspNetCore.Mvc;
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

namespace ApiPosgreSQLDB.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly NutriTecDBContext _context;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(NutriTecDBContext context, ILogger<ClienteController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("validarcliente")]
        public async Task<string> ValidarCliente(string correo, string contrasena)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_correo", NpgsqlDbType.Varchar) { Value = correo },
                new NpgsqlParameter("@p_contrasena", NpgsqlDbType.Varchar) { Value = contrasena }
            };

            var result = await _context.Set<string>().FromSqlRaw("SELECT public.validarlogincliente(@p_correo, @p_contrasena)", parameters).FirstOrDefaultAsync();

            return result;
        }

        [HttpPost("registrarcliente")]
        public async Task RegistrarCliente(int id, string nombre, string apellido1, string apellido2, int edad, DateTime fechaNacimiento, int peso, int imc, string paisResidencia, int pesoActual, int cintura, int porcentajeMusculos, int cuello, int caderas, int porcentajeGrasa, int consumoDiarioCalorias, string correoElectronico, string contrasena)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_ID", NpgsqlDbType.Integer) { Value = id },
                new NpgsqlParameter("@p_Nombre", NpgsqlDbType.Varchar) { Value = nombre },
                new NpgsqlParameter("@p_Apellido1", NpgsqlDbType.Varchar) { Value = apellido1 },
                new NpgsqlParameter("@p_Apellido2", NpgsqlDbType.Varchar) { Value = apellido2 },
                new NpgsqlParameter("@p_Edad", NpgsqlDbType.Integer) { Value = edad },
                new NpgsqlParameter("@p_FechaNacimiento", NpgsqlDbType.Date) { Value = fechaNacimiento },
                new NpgsqlParameter("@p_Peso", NpgsqlDbType.Integer) { Value = peso },
                new NpgsqlParameter("@p_IMC", NpgsqlDbType.Integer) { Value = imc },
                new NpgsqlParameter("@p_PaisResidencia", NpgsqlDbType.Varchar) { Value = paisResidencia },
                new NpgsqlParameter("@p_PesoActual", NpgsqlDbType.Integer) { Value = pesoActual },
                new NpgsqlParameter("@p_Cintura", NpgsqlDbType.Integer) { Value = cintura },
                new NpgsqlParameter("@p_PorcentajeMusculos", NpgsqlDbType.Integer) { Value = porcentajeMusculos },
                new NpgsqlParameter("@p_Cuello", NpgsqlDbType.Integer) { Value = cuello },
                new NpgsqlParameter("@p_Caderas", NpgsqlDbType.Integer) { Value = caderas },
                new NpgsqlParameter("@p_PorcentajeGrasa", NpgsqlDbType.Integer) { Value = porcentajeGrasa },
                new NpgsqlParameter("@p_ConsumoDiarioCalorias", NpgsqlDbType.Integer) { Value = consumoDiarioCalorias },
                new NpgsqlParameter("@p_CorreoElectronico", NpgsqlDbType.Varchar) { Value = correoElectronico },
                new NpgsqlParameter("@p_Contrasena", NpgsqlDbType.Varchar) { Value = contrasena }
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT registrar_cliente(@p_ID, @p_Nombre, @p_Apellido1, @p_Apellido2, @p_Edad, @p_FechaNacimiento, @p_Peso, @p_IMC, @p_PaisResidencia, @p_PesoActual, @p_Cintura, @p_PorcentajeMusculos, @p_Cuello, @p_Caderas, @p_PorcentajeGrasa, @p_ConsumoDiarioCalorias, @p_CorreoElectronico, @p_Contrasena)", parameters);
        }

        










    }
}
