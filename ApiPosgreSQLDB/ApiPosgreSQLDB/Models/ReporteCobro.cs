using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class ReporteCobro
    {
        public int id { get; set; }
        public string nutricionistaid { get; set; }
        public int tipocobroid { get; set; }
        public int montototal { get; set; }
        public int descuento { get; set; }
        public int montocobrar { get; set; }
        public Nutricionista Nutricionista { get; set; }  // Propiedad de navegación
        public TipoCobro TipoCobro { get; set; }  // Propiedad de navegación
    }
}
