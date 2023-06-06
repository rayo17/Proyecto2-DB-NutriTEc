using ApiPosgreSQLDB.Data;
using ApiPosgreSQLDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace ApiPosgreSQLDB.Controllers
{
    [ApiController]
    [Route("Externos")]
    public class ExternalController : ControllerBase
    {
        private readonly NutriTecDBContext _context;
        private readonly ILogger<ExternalController> _logger;
        private readonly string _connectionString;

        public ExternalController(NutriTecDBContext context, ILogger<ExternalController> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _connectionString = configuration.GetConnectionString("PostgreSQLConnection");
        }

        [HttpPost("registrartiempocomida")]
        public async Task RegistrarTiempoComida(TiempoComida tc)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_ID", NpgsqlDbType.Integer) { Value = tc.id },
                new NpgsqlParameter("@p_NombreTiempo", NpgsqlDbType.Varchar) { Value = tc.nombre },
                

            };

            await _context.Database.ExecuteSqlRawAsync("SELECT insertartiempocomida(@p_ID, @p_NombreTiempo)", parameters);
        }
    }
}
