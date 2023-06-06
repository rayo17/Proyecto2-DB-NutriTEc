using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPosgreSQLDB.Models
{
    public class Paciente
    {
        public int id { get; set; }
        public int clienteid { get; set; }
        public string nutricionistaid { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }  // Propiedad de navegación
        [JsonIgnore]
        public Nutricionista Nutricionista { get; set; }  // Propiedad de navegación
    }
}
