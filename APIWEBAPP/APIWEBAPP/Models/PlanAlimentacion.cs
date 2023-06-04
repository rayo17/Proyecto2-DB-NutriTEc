using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class PlanAlimentacion
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string NombrePlan { get; set; }
        
        [ForeignKey("Nutricionista")]
        [Column(TypeName = "varchar")]
        [MaxLength(12)]
        public string NutricionistaID { get; set; }
        public int CaloriasTotalPlan { get; set; }

        [JsonIgnore]
        public ICollection<TiempoComida> TiempoComidas { get; set; }
        [JsonIgnore]
        public Nutricionista Nutricionista { get; set; }
    }
}
