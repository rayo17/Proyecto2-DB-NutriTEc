using ApiPosgreSQLDB.Data;
using ApiPosgreSQLDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

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
                new NpgsqlParameter("@p_Foto", NpgsqlDbType.Bytea) { Value = c.foto },
                new NpgsqlParameter("@p_NumTarjetaCredito", NpgsqlDbType.Varchar) { Value = c.numtarjetacredito },
                new NpgsqlParameter("@p_TipoCobroID", NpgsqlDbType.Integer) { Value = c.tipocobroid },
                new NpgsqlParameter("@p_CorreoElectronico", NpgsqlDbType.Varchar) { Value = c.correoelectronico },
                new NpgsqlParameter("@p_Contrasena", NpgsqlDbType.Varchar) { Value = c.contrasena }
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT registrar_nutricionista(@p_Cedula, @p_Nombre, @p_Apellido1, @p_Apellido2, @p_CodigoBarras, @p_Edad, @p_FechaNacimiento, @p_Peso, @p_IMC, @p_Direccion, @p_Foto, @p_NumTarjetaCredito, @p_TipoCobroID, @p_CorreoElectronico, @p_Contrasena)", parameters);
        }



    }
}
