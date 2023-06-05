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

namespace ApiPosgreSQLDB.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly NutriTecDBContext _context;

        public ClienteController(NutriTecDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult RegistrarCliente([FromBody] Cliente c)
        {
            
            try
            {
                var parameters = new NpgsqlParameter[]
                    {
                        new NpgsqlParameter("p_Nombre", NpgsqlDbType.Varchar) { Value = c.nombre },
                        new NpgsqlParameter("p_Apellido1", NpgsqlDbType.Varchar) { Value = c.apellido1 },
                        new NpgsqlParameter("p_Apellido2", NpgsqlDbType.Varchar) { Value = c.apellido2 },
                        new NpgsqlParameter("p_Edad", NpgsqlDbType.Integer) { Value = c.edad },
                        new NpgsqlParameter("p_FechaNacimiento", NpgsqlDbType.Date) { Value = c.fechanacimiento },
                        new NpgsqlParameter("p_Peso", NpgsqlDbType.Integer) { Value = c.peso },
                        new NpgsqlParameter("p_IMC", NpgsqlDbType.Integer) { Value = c.imc },
                        new NpgsqlParameter("p_PaisResidencia", NpgsqlDbType.Varchar) { Value = c.paisresidencia },
                        new NpgsqlParameter("p_PesoActual", NpgsqlDbType.Integer) { Value = c.pesoactual },
                        new NpgsqlParameter("p_Cintura", NpgsqlDbType.Integer) { Value = c.cintura },
                        new NpgsqlParameter("p_PorcentajeMusculos", NpgsqlDbType.Integer) { Value = c.porcentajemusculos },
                        new NpgsqlParameter("p_Cuello", NpgsqlDbType.Integer) { Value = c.cuello },
                        new NpgsqlParameter("p_Caderas", NpgsqlDbType.Integer) { Value = c.caderas },
                        new NpgsqlParameter("p_PorcentajeGrasa", NpgsqlDbType.Integer) { Value = c.porcentajegrasa },
                        new NpgsqlParameter("p_ConsumoDiarioCalorias", NpgsqlDbType.Integer) { Value = c.consumodiariocalorias },
                        new NpgsqlParameter("p_CorreoElectronico", NpgsqlDbType.Varchar) { Value = c.correoelectronico },
                        new NpgsqlParameter("p_Contrasena", NpgsqlDbType.Varchar) { Value = c.contrasena }
                    };
                // Lógica para validar y procesar los datos recibidos del cliente

                // Llamar al procedimiento almacenado para registrar el cliente
                NpgsqlConnection connection = new NpgsqlConnection("PostgreSQLConnection");
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.CommandText = "registrarcliente";
                cmd.Parameters.AddWithValue(parameters);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                //var result = _context.Database.ExecuteSqlInterpolated($"CALL public.registrarcliente({cliente.id}, {cliente.nombre}, {cliente.apellido1}, {cliente.apellido2}, {cliente.edad}, {cliente.fechanacimiento}, {cliente.peso}, {cliente.imc}, {cliente.paisresidencia}, {cliente.pesoactual}, {cliente.cintura}, {cliente.porcentajemusculos}, {cliente.cuello}, {cliente.caderas}, {cliente.porcentajegrasa}, {cliente.consumodiariocalorias}, {cliente.correoelectronico}, {cliente.contrasena})");

                // Si es necesario, generar una respuesta adecuada
                var response = new
                {
                    Message = "Cliente registrado exitosamente",
                    Cliente = c,
                    //Result = result
                };

                // Devolver una respuesta HTTP exitosa (código 200) con la información de respuesta
                return Ok(response);

            }
            catch (Exception ex)
            {
                // Manejo de errores aquí
               

                // Devolver una respuesta de error con detalles
                return Results.Problem(detail: ex.Message, title: "Error al registrar el cliente") as IActionResult;

            }
            
        }
    }
}
