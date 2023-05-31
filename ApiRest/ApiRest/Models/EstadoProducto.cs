using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiRest.Models
{
    public class EstadoProducto
    {
        [Key]
        [ForeignKey("Producto")]
        public int codigo_barra { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string estado { get; set; }
        [JsonIgnore]
        public Producto Producto { get; set; }

    }
}
