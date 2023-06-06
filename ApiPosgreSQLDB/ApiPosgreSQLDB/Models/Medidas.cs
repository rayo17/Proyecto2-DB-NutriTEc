using System.Text.Json.Serialization;

namespace ApiPosgreSQLDB.Models
{
    public class Medidas
    {
        public int id { get; set; }
        public int clienteid { get; set; }
        public DateTime fecha { get; set; }
        public int cintura { get; set; }
        public int cuello { get; set; }
        public int caderas { get; set; }
        public int porcentajemusculo { get; set; }
        public int porcentajegrasa { get; set; }
        public int pesoactual { get; set; }
        
    }
}
