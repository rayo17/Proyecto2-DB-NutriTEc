﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Models
{
    public class Cobro
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        [ForeignKey("Nutricionista")]
        public string id_nutri { get; set; }
        
        
        [Column(TypeName = "varchar")]
        public string plan { get; set; }
        
        public int monto_t { get; set; }
        
        public int descuento { get; set; }

        [JsonIgnore]
        public Nutricionista Nutricionista { get; set; }
    }
}
