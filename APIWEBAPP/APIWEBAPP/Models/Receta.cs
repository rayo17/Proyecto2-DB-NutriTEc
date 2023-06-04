using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class Receta
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Nombre { get; set; }
        public int CaloriasTotalesReceta { get; set; }
        [ForeignKey("Producto")]
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string ProductoID { get; set; }


        [JsonIgnore]
        public Producto Producto { get; set; }
    }
}
