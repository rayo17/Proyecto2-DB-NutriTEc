using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class EstadoProducto
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Producto")]
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string ProductoID { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public DateTime FechaAprobacion { get; set; }
        public Boolean Estado { get; set; }
        [JsonIgnore]
        public Producto Producto { get; set; }
    }
}
