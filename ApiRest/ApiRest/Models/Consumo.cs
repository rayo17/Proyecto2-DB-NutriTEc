using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models
{
    public class Consumo
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string correo_cliente { get; set; }

        public DateTime fecha { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string desayuno { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string merienda_m { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string almuerzo { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string merienda_t { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string cena { get; set; }

        [ForeignKey("correo_cliente")]
        public Cliente Cliente { get; set; }

    }
}
