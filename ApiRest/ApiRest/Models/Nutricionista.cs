using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models
{
    public class Nutricionista
    {
        [Key]
        public string cedula { get; set; }
        public int cod_barras { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public byte[]? foto { get; set;}
        public int num_tarj_credi { get; set; }
        public int edad { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string contrasena { get; set; }
        public string correo { get; set; }
        public int imc { get; set; }
        public int peso { get; set; }

        public ICollection<TipoCobro> TipoCobros { get; set; }  // Propiedad de navegación
        public ICollection<Cobro> Cobros { get; set; }  // Propiedad de navegación
        public ICollection<nutricionista_asigna_cliente> NutricionistasAsignados { get; set; }
    }

}

