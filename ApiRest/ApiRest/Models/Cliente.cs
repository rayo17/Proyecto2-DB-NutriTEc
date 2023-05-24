using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models
{
    public class Cliente
    {
        [Key]
        public string correo { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string contrasena { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int edad { get; set; }
        public int peso { get; set; }
        public int imc { get; set; }
        public int cintura { get; set; }
        public int pmuslos { get; set; }
        public int cuello { get; set; }
        public int caderas { get; set; }
        public int pgrasa { get; set; }
        public int consumo_diario_c { get; set;}
        public DateTime fecha_medicion { get; set; }
    }
}
