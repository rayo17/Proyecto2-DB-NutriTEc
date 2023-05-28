﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models
{
    public class TipoCobro
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        [ForeignKey("Nutricionista")]
        public string cedula { get; set; }
        
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string tipo_cobro { get; set; }

        public Nutricionista Nutricionista { get; set; }
    }
}
