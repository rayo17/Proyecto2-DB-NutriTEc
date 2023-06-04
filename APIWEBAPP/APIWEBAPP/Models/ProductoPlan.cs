using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class ProductoPlan
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Producto")]
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string ProductoID { get; set; }
        [ForeignKey("TiempoComida")]
        public int TiempoComidaID { get; set; }

        [JsonIgnore]
        public Producto Producto { get; set; }
        [JsonIgnore]
        public TiempoComida TiempoComida { get; set; }
    }
}
