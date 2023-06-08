using ApiPosgreSQLDB.Data;
using ApiPosgreSQLDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Text.Json.Nodes;
using System.Text.Json;

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
                new NpgsqlParameter("@p_taman_porcion", NpgsqlDbType.Integer) { Value = productoData.taman_porcion },
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


        [HttpGet("VisualizarProductosDisponibles")]
        public async Task<List<Producto>> ObtenerProductosDisponibles()
        {
            List<Producto> productos = new List<Producto>();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM productosdisponibles";

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();
                            producto.codigobarra = reader.GetString(0);
                            producto.nombre = reader.GetString(1);
                            producto.taman_porcion = reader.GetInt32(2);
                            producto.energia = reader.GetInt32(3);
                            producto.grasa = reader.GetInt32(4);
                            producto.sodio = reader.GetInt32(5);
                            producto.carbohidratos = reader.GetInt32(6);
                            producto.proteina = reader.GetInt32(7);
                            producto.vitaminas = reader.GetString(8);
                            producto.calcio = reader.GetInt32(9);
                            producto.hierro = reader.GetInt32(10);
                            producto.descripcion = reader.GetString(11);
                            producto.estadoproducto = reader.GetBoolean(12);
                            // Obtener los demás atributos del producto según su posición en el reader

                            productos.Add(producto);
                        }
                    }
                }

                connection.Close();
            }

            return productos;
        }
        [HttpPost("crearreceta")]
        public async Task<IActionResult> CrearReceta([FromBody] JsonDocument requestData)
        {
            try
            {
                JsonElement rootElement = requestData.RootElement;
                string nombreReceta = rootElement.GetProperty("nombre").GetString();
                JsonElement.ArrayEnumerator productos = rootElement.GetProperty("productos").EnumerateArray();

                Console.WriteLine(nombreReceta);

                foreach (JsonElement producto in productos)
                {
                    var parameters = new[]
                    {
                new NpgsqlParameter("@pNombre", NpgsqlDbType.Varchar) { Value = nombreReceta },
                new NpgsqlParameter("@pTamanPorcion", NpgsqlDbType.Integer) { Value = producto.GetProperty("tamPorcion").GetInt32() },
                new NpgsqlParameter("@pEnergia", NpgsqlDbType.Integer) { Value = producto.GetProperty("energia").GetInt32() },
                new NpgsqlParameter("@pGrasa", NpgsqlDbType.Integer) { Value = producto.GetProperty("grasa").GetInt32() },
                new NpgsqlParameter("@pSodio", NpgsqlDbType.Integer) { Value = producto.GetProperty("sodio").GetInt32() },
                new NpgsqlParameter("@pCarbohidratos", NpgsqlDbType.Integer) { Value = producto.GetProperty("carbohidratos").GetInt32() },
                new NpgsqlParameter("@pProteina", NpgsqlDbType.Integer) { Value = producto.GetProperty("proteina").GetInt32() },
                new NpgsqlParameter("@pVitaminas", NpgsqlDbType.Varchar) { Value = producto.GetProperty("vitaminas").GetString() },
                new NpgsqlParameter("@pCalcio", NpgsqlDbType.Integer) { Value = producto.GetProperty("calcio").GetInt32() },
                new NpgsqlParameter("@pHierro", NpgsqlDbType.Integer) { Value = producto.GetProperty("hierro").GetInt32() }
            };

                    await _context.Database.ExecuteSqlRawAsync("SELECT crearreceta(@pNombre, @pTamanPorcion, @pEnergia, @pGrasa, @pSodio, @pCarbohidratos, @pProteina, @pVitaminas, @pCalcio, @pHierro)", parameters);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("creartipocobro")]
        public async Task CrearTipoCobro(TipoCobro productoData)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_ID", NpgsqlDbType.Integer) { Value = productoData.id },
                new NpgsqlParameter("@p_NombreTipo", NpgsqlDbType.Varchar) { Value = productoData.nombretipocobro },
               
             };

            await _context.Database.ExecuteSqlRawAsync("SELECT insertartipocobro(@p_ID, @p_NombreTipo)", parameters);
        }



    }
}
