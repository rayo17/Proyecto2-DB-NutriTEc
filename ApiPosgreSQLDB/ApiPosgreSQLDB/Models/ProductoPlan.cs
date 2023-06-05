using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class ProductoPlan
    {
        public int id { get; set; }
        public string productoid { get; set; }
        public int tiempocomidaid { get; set; }
        public Producto Producto { get; set; }  // Propiedad de navegación
        public TiempoComida TiempoComida { get; set; }  // Propiedad de navegación
    }
}
