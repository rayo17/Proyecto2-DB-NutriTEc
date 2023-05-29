using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models
{
    public class Administrador
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string correo { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string contrasena { get; set; }
    }
}
