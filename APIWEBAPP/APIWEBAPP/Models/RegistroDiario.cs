using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class RegistroDiario
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteID { get; set; }
        [ForeignKey("TiempoComida")]
        public int TiempoComidaID { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadComsumida { get; set; }




        [JsonIgnore]
        public Cliente Cliente { get; set; }
        [JsonIgnore]
        public TiempoComida TiempoComida { get; set; }
    }
}
