using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class Producto
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string CodigoBarra { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string nombre { get; set; }
        public int taman_porcion { get; set; }
        public int energia { get; set; }
        public int grasa { get; set; }
        public int sodio { get; set; }
        public int carbohidratos { get; set; }
        public int proteina { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string vitaminas { get; set; }
        public int calcio { get; set; }
        public int hierro { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string descripcion { get; set; }
        public Boolean EstadoProducto { get; set; }
       
        [JsonIgnore]
        public ICollection<EstadoProducto> EstadosProducto { get; set; }
        [JsonIgnore]
        public ICollection<ProductoPlan> ProductosPlan { get; set; }
        [JsonIgnore]
        public ICollection<Receta> Recetas { get; set; }
    }
}
