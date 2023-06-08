using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class EstadoProducto
    {
        public int id { get; set; }
        public string productoid { get; set; }
        public DateTime fechaaprobacion { get; set; }
        public bool estado { get; set; }
    }
}
