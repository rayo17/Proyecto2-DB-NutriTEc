using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class Receta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int caloriastotalesreceta { get; set; }
        public string productoid { get; set; }
        public Producto Producto { get; set; }  // Propiedad de navegación
    }
}
