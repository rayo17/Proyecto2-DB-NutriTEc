using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class TiempoComida
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Nombre { get; set; }
        [ForeignKey("PlanAlimentacion")]
        public int PlanAlimentacionID { get; set; }

        [JsonIgnore]
        public PlanAlimentacion PlanAlimentacion { get; set; }
        [JsonIgnore]
        public ICollection<RegistroDiario> RegistrosDiarios { get; set; }

    }
}
