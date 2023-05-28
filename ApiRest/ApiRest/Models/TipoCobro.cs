using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models
{
    public class TipoCobro
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string cedula { get; set; }
        public int cod_barras_nutri { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string tipo_cobro { get; set; }
    }
}
