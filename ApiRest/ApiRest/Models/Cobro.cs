using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models
{
    public class Cobro
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string id_nutri { get; set; }
        
        public int cod_barras_nutri { get; set; }
        [Column(TypeName = "varchar")]
        public string plan { get; set; }
        
        public int monto_t { get; set; }
        
        public int descuento { get; set; }

    }
}
