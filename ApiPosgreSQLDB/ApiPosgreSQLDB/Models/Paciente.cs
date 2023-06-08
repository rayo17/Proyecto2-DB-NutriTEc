using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPosgreSQLDB.Models
{
    public class Paciente
    {
        
        public string clienteid { get; set; }
        public string nutricionistaid { get; set; }
        
    }
}
