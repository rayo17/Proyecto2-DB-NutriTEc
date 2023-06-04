using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class Nutricionista
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(12)]
        public string Cedula { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Apellido1 { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Apellido2 { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(127)]
        public string CododigoBarras { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Peso { get; set; }
        public int IMC { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Direccion { get; set; }
        public byte[]? Foto { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(16)]
        public string NumTarjetaCredito { get; set; }
        
        [ForeignKey("TipoCobro")]
        public int TipoCobroID { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(320)]
        public string CorreoElectronico { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Contrasena { get; set; }



        [JsonIgnore]
        public TipoCobro TipoCobro { get; set; }
        [JsonIgnore]
        public ICollection<ReporteCobro> Cobros { get; set; }  // Propiedad de navegación
        [JsonIgnore]
        public ICollection<PlanAlimentacion> PlanesAlimentacion { get; set; }  // Propiedad de navegación
        
        [JsonIgnore]
        public ICollection<Retroalimentacion> Retroalimentaciones { get; set; } // Propiedad de navegación
    }
}
