using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class TiempoComida
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int planalimentacionid { get; set; }
        public PlanAlimentacion PlanAlimentacion { get; set; }  // Propiedad de navegación
    }
}
