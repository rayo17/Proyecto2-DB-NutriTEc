using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models
{
    public class Administrador
    {
        [Key]
        public string correo { get; set; }
        public string contrasena { get; set; }
    }
}
