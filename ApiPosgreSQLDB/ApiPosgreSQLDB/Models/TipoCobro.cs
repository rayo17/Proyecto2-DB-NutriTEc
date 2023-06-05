using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class TipoCobro
    {
        public int id { get; set; }
        public string nombretipocobro { get; set; }
        public ICollection<Nutricionista> Nutricionistas { get; set; }  // Propiedad de navegación
        public ICollection<ReporteCobro> ReporteCobros { get; set; }  // Propiedad de navegación
    }
}
