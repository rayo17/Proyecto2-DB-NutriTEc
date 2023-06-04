using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class Retroalimentacion
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Nutricionista")]
        [Column(TypeName = "varchar")]
        [MaxLength(12)]
        public string NutricionistaID { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(5000)]
        public string Comentario { get; set; }


        [JsonIgnore]
        public Nutricionista Nutricionista { get; set;}
        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
