using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPosgreSQLDB.Models
{
    public class Receta
    {
        public string nombre { get; set; }
        public int taman_porcion { get; set; }
        public  int energia { get; set; }
        public int grasa { get; set; }
        public int sodio { get; set; }
        public int carbohidratos { get; set; }
        public int proteina { get; set; }
        public string vitaminas { get; set; }
        public int calcio { get; set; }
        public int hierro { get; set; }
    }
}
