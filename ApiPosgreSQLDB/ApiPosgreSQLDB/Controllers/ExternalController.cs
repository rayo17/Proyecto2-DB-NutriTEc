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
using ApiPosgreSQLDB.Estrcuturas_Swagger;
using System.Data;

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
        public async Task CrearProducto(CrearProducto productoData)
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
                new NpgsqlParameter("@p_estado_producto", NpgsqlDbType.Boolean) { Value = productoData.estadoproducto },
                new NpgsqlParameter("@p_creador_producto", NpgsqlDbType.Varchar) { Value = productoData.idcreador }

             };

            await _context.Database.ExecuteSqlRawAsync("SELECT crear_producto(@p_codigo_barra, @p_nombre, @p_taman_porcion, @p_energia, @p_grasa, @p_sodio, @p_carbohidratos, @p_proteina, @p_vitaminas, @p_calcio, @p_hierro, @p_descripcion, @p_estado_producto, @p_creador_producto)", parameters);
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
                new NpgsqlParameter("@pTaman_Porcion", NpgsqlDbType.Integer) { Value = producto.GetProperty("taman_porcion").GetInt32() },
                new NpgsqlParameter("@pEnergia", NpgsqlDbType.Integer) { Value = producto.GetProperty("energia").GetInt32() },
                new NpgsqlParameter("@pGrasa", NpgsqlDbType.Integer) { Value = producto.GetProperty("grasa").GetInt32() },
                new NpgsqlParameter("@pSodio", NpgsqlDbType.Integer) { Value = producto.GetProperty("sodio").GetInt32() },
                new NpgsqlParameter("@pCarbohidratos", NpgsqlDbType.Integer) { Value = producto.GetProperty("carbohidratos").GetInt32() },
                new NpgsqlParameter("@pProteina", NpgsqlDbType.Integer) { Value = producto.GetProperty("proteina").GetInt32() },
                new NpgsqlParameter("@pVitaminas", NpgsqlDbType.Varchar) { Value = producto.GetProperty("vitaminas").GetString() },
                new NpgsqlParameter("@pCalcio", NpgsqlDbType.Integer) { Value = producto.GetProperty("calcio").GetInt32() },
                new NpgsqlParameter("@pHierro", NpgsqlDbType.Integer) { Value = producto.GetProperty("hierro").GetInt32() }
            };

                    await _context.Database.ExecuteSqlRawAsync("SELECT crearreceta(@pNombre, @pTaman_Porcion, @pEnergia, @pGrasa, @pSodio, @pCarbohidratos, @pProteina, @pVitaminas, @pCalcio, @pHierro)", parameters);
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

        [HttpGet("RecetasDisponibles")]
        public IActionResult GetRecetasDisponibles()
        {
            List<Receta> recetas = new List<Receta>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                string viewName = "recetasdisponibles";

                using (var command = new NpgsqlCommand($"SELECT * FROM {viewName};", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear un objeto Receta y asignar los valores de cada columna del view
                            Receta receta = new Receta
                            {
                                // Asignar los valores de las columnas según su tipo de datos correspondiente
                                // Por ejemplo:
                                nombre = reader.GetString(0),
                                taman_porcion = reader.GetInt32(1),
                                energia = reader.GetInt32(2),
                                grasa = reader.GetInt32(3),
                                sodio = reader.GetInt32(4),
                                carbohidratos = reader.GetInt32(5),
                                proteina = reader.GetInt32(6),
                                vitaminas = reader.GetString(7),
                                calcio = reader.GetInt32(8),
                                hierro = reader.GetInt32(9),
                                // Asignar las demás propiedades de la Receta según corresponda
                            };

                            // Agregar la receta a la lista
                            recetas.Add(receta);
                        }
                    }
                }
            }

            // Devolver la lista de recetas como resultado de la solicitud
            return Ok(recetas);
        }
        

        [HttpPut("actualizarproducto")]
        public async Task ActualizarProducto(ObtenerProductosCliente productoData)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("@p_CodigoBarra", NpgsqlDbType.Varchar) { Value = productoData.CodigoBarra },
                new NpgsqlParameter("@p_Nombre", NpgsqlDbType.Varchar) { Value = productoData.Nombre },
                new NpgsqlParameter("@p_taman_porcion", NpgsqlDbType.Integer) { Value = productoData.TamanPorcion },
                new NpgsqlParameter("@p_energia", NpgsqlDbType.Integer) { Value = productoData.Energia },
                new NpgsqlParameter("@p_grasa", NpgsqlDbType.Integer) { Value = productoData.Grasa },
                new NpgsqlParameter("@p_sodio", NpgsqlDbType.Integer) { Value = productoData.Sodio },
                new NpgsqlParameter("@p_carbohidratos", NpgsqlDbType.Integer) { Value = productoData.Carbohidratos },
                new NpgsqlParameter("@p_proteina", NpgsqlDbType.Integer) { Value = productoData.Proteina },
                new NpgsqlParameter("@p_vitaminas", NpgsqlDbType.Varchar) { Value = productoData.Vitaminas },
                new NpgsqlParameter("@p_calcio", NpgsqlDbType.Integer) { Value = productoData.Calcio },
                new NpgsqlParameter("@p_hierro", NpgsqlDbType.Integer) { Value = productoData.Hierro },
                new NpgsqlParameter("@p_descripcion", NpgsqlDbType.Varchar) { Value = productoData.Descripcion }
            };

            await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_productos(@p_CodigoBarra, @p_Nombre, @p_taman_porcion, @p_energia, @p_grasa, @p_sodio, @p_carbohidratos, @p_proteina, @p_vitaminas, @p_calcio, @p_hierro, @p_descripcion)", parameters);
        }

        [HttpDelete("eliminarreceta/{nombreReceta}")]
        public async Task<IActionResult> EliminarReceta(string nombreReceta)
        {
            try
            {
                var parameter = new NpgsqlParameter("@p_NombreReceta", NpgsqlDbType.Varchar) { Value = nombreReceta };
                await _context.Database.ExecuteSqlRawAsync("SELECT eliminarreceta(@p_NombreReceta)", parameter);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("eliminarproductos/{codigoBarra}")]
        public async Task<IActionResult> EliminarProductos(string codigoBarra)
        {
            try
            {
                var parameter = new NpgsqlParameter("@p_CodigoBarra", NpgsqlDbType.Varchar) { Value = codigoBarra };
                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_productos_id(@p_CodigoBarra)", parameter);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("mostrarproducto/{id}")]
        public IActionResult MostrarProducto(string id)
        {
            try
            {
                string querySelect = $"SELECT * FROM Productos WHERE CodigoBarra = '{id}'";
                var producto = _context.productos.FromSqlRaw(querySelect).FirstOrDefault();

                if (producto != null)
                {
                    return Ok(producto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        





    }
}
