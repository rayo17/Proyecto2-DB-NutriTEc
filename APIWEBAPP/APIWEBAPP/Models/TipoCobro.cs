using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class TipoCobro
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string NombreTipoCobro { get; set; }


        [JsonIgnore]
        public ICollection<Nutricionista> Nutricionistas { get; set; }  // Propiedad de navegación
        [JsonIgnore]
        public ICollection<ReporteCobro> ReporteCobros { get; set; }  // Propiedad de navegación
    }
}
