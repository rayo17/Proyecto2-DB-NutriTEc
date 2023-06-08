using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class Administrador
    {
        
        public int id { get; set; }
        public string correoelectronico { get; set; }
        public string contrasena { get; set; }
    }
}
