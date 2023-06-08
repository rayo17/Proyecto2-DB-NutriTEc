using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class RegistroDiario
    {
        public int id { get; set; }
        public string clienteid { get; set; }
        public int tiempocomidaid { get; set; }
        public DateTime fecha { get; set; }
        public string productoid { get; set; }
        
    }
}
