using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models
{
    public class Producto
    {
        [Key]
        public int codigo_barra { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string nombre { get; set; }
        public int grasa { get; set; }
        public int taman_porcion { get; set; }
        public int energia { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string descripcion { get; set; }
        public int proteina { get; set; }
        public int sodio { get; set; }
        public int hierro { get; set; }
        public int calcio { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string vitaminas { get; set; }
        public int carbohidratos { get; set; }
    }
}
