using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models
{
    public class Plan
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string nombre_plan { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string desayuno { get; set;}
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string merienda_m { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string almuerzo { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string merienda_t { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        public string cena { get; set; }
    }
}
