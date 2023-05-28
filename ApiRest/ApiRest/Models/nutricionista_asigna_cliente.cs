using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models
{
    public class nutricionista_asigna_cliente
    {
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [ForeignKey("Nutricionista")]
        public string id_nutricionista { get; set; }
        
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [ForeignKey("Cliente")]
        public string correo_cliente { get; set; }
        public DateTime fecha_i { get; set; }
        public DateTime fecha_f { get; set; }
        
        
        
        public Cliente Cliente { get; set; }
        
        public Nutricionista Nutricionista { get; set; }
    }
}
