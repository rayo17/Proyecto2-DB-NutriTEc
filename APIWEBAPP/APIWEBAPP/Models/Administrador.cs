using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIWEBAPP.Models
{
    public class Administrador
    {
        [Key]
        public int ID{ get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(320)]
        public string CorreoElectronico { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Contrasena { get; set; }
    }
}
