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
        public int cantidadconsumida { get; set; }
        public Cliente Cliente { get; set; }  // Propiedad de navegación
        public TiempoComida TiempoComida { get; set; }  // Propiedad de navegación
    }
}
