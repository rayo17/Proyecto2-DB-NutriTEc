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

        [HttpPost("crearproducto")]
        public async Task CrearProducto(Producto productoData)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_codigo_barra", NpgsqlDbType.Varchar) { Value = productoData.codigobarra },
                new NpgsqlParameter("@p_nombre", NpgsqlDbType.Varchar) { Value = productoData.nombre },
                new NpgsqlParameter("@p_taman_porcion", NpgsqlDbType.Integer) { Value = productoData.tamanioporcion },
                new NpgsqlParameter("@p_energia", NpgsqlDbType.Integer) { Value = productoData.energia },
                new NpgsqlParameter("@p_grasa", NpgsqlDbType.Integer) { Value = productoData.grasa },
                new NpgsqlParameter("@p_sodio", NpgsqlDbType.Integer) { Value = productoData.sodio },
                new NpgsqlParameter("@p_carbohidratos", NpgsqlDbType.Integer) { Value = productoData.carbohidratos },
                new NpgsqlParameter("@p_proteina", NpgsqlDbType.Integer) { Value = productoData.proteina },
                new NpgsqlParameter("@p_vitaminas", NpgsqlDbType.Varchar) { Value = productoData.vitaminas },
                new NpgsqlParameter("@p_calcio", NpgsqlDbType.Integer) { Value = productoData.calcio },
                new NpgsqlParameter("@p_hierro", NpgsqlDbType.Integer) { Value = productoData.hierro },
                new NpgsqlParameter("@p_descripcion", NpgsqlDbType.Varchar) { Value = productoData.descripcion },
                new NpgsqlParameter("@p_estado_producto", NpgsqlDbType.Boolean) { Value = productoData.estadoproducto }
             };

            await _context.Database.ExecuteSqlRawAsync("SELECT crear_producto(@p_codigo_barra, @p_nombre, @p_taman_porcion, @p_energia, @p_grasa, @p_sodio, @p_carbohidratos, @p_proteina, @p_vitaminas, @p_calcio, @p_hierro, @p_descripcion, @p_estado_producto)", parameters);
        }

    }
}
