using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class ReporteCobro
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [ForeignKey("Nutricionista")]
        public string NutricionistaID { get; set; }
        [ForeignKey("TipoCobro")]
        public int TipoCobroID { get; set; }
        public int MontoTotal { get; set; }
        public int Descuento { get; set; }
        public int MontoCobrar { get; set; }
       

        [JsonIgnore]
        public Nutricionista Nutricionista { get; set; }
        [JsonIgnore]
        public TipoCobro TipoCobro { get; set; }
    }
}
