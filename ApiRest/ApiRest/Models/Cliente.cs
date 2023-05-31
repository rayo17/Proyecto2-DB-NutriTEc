using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Models
{
    public class Cliente
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string correo { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string nombre { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string apellido1 { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string apellido2 { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string contrasena { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int edad { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string paisresidencia { get; set; }
        public int peso { get; set; }
        public int imc { get; set; }
        public int cintura { get; set; }
        public int pmuslos { get; set; }
        public int cuello { get; set; }
        public int caderas { get; set; }
        public int pgrasa { get; set; }
        public int consumo_diario_c { get; set;}
        public DateTime fecha_medicion { get; set; }


        [JsonIgnore]
        public ICollection<Consumo> Consumos { get; set; }
        [JsonIgnore]
        public ICollection<nutricionista_asigna_cliente> NutricionistasAsignados { get; set; }
    }
}
