using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPosgreSQLDB.Models
{
    public class Nutricionista
    {
        
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string codigobarras { get; set; }
        public int edad { get; set; }
        public DateTime fechanacimiento { get; set; }
        public int peso { get; set; }
        public int imc { get; set; }
        public string direccion { get; set; }
        public string foto { get; set; }
        public string numtarjetacredito { get; set; }
        public int tipocobroid { get; set; }
        public string correoelectronico { get; set; }
        public string contrasena { get; set; }
        
    }
}
