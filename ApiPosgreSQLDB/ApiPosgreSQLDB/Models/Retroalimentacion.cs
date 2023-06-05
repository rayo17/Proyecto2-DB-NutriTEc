using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class Retroalimentacion
    {
        public int id { get; set; }
        public string nutricionistaid { get; set; }
        public int clienteid { get; set; }
        public DateTime fecha { get; set; }
        public string comentario { get; set; }
        public Nutricionista Nutricionista { get; set; }  // Propiedad de navegación
        public Cliente Cliente { get; set; }  // Propiedad de navegación
    }
}
