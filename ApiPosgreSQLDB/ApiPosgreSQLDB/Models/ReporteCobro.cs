using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class ReporteCobro
    {
        public string NutricionistaID { get; set; }
        public int TipoCobroID { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoCobrar { get; set; }

    }
}
