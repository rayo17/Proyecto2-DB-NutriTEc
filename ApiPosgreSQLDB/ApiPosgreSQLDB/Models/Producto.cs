using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class Producto
    {
        public string codigobarra { get; set; }
        public string nombre { get; set; }
        public int tamanioporcion { get; set; }
        public int energia { get; set; }
        public int grasa { get; set; }
        public int sodio { get; set; }
        public int carbohidratos { get; set; }
        public int proteina { get; set; }
        public string vitaminas { get; set; }
        public int calcio { get; set; }
        public int hierro { get; set; }
        public string descripcion { get; set; }
        public bool estadoproducto { get; set; }
        public ICollection<EstadoProducto> EstadoProductos { get; set; }  // Propiedad de navegación
        public ICollection<ProductoPlan> ProductosPlan { get; set; }  // Propiedad de navegación
        public ICollection<Receta> Recetas { get; set; }  // Propiedad de navegación
    }
}
