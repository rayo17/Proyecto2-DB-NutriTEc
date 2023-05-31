using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Models
{
    public class Nutricionista
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string cedula { get; set; }
        public int cod_barras { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string nombre { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string apellido1 { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string apellido2 { get; set; }
        public byte[]? foto { get; set;}
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string num_tarj_credi { get; set; }
        public int edad { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string contrasena { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string correo { get; set; }
        public int imc { get; set; }
        public int peso { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string direccion { get; set; }

        [JsonIgnore]
        public ICollection<TipoCobro> TipoCobros { get; set; }  // Propiedad de navegación
        [JsonIgnore]
        public ICollection<Cobro> Cobros { get; set; }  // Propiedad de navegación
        [JsonIgnore]
        public ICollection<nutricionista_asigna_cliente> NutricionistasAsignados { get; set; }
    }

}

