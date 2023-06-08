using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class PlanAlimentacion
    {
        public int id { get; set; }
        public string nombreplan { get; set; }
        public string nutricionistaid { get; set; }
        public int caloriastotalplan { get; set; }
        public Nutricionista Nutricionista { get; set; }  // Propiedad de navegación
    }
}
