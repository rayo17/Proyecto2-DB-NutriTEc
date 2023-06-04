﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIWEBAPP.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Apellido1 { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(40)]
        public string Apellido2 { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Peso { get; set; }
        public int IMC { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string PaisResidencia { get; set; }
        public int PesoActual { get; set; }
        public int Cintura { get; set; }
        public int PorcentajeMusculos { get; set; }
        public int Cuello { get; set; }
        public int Caderas { get; set; }
        public int PorcentajeGrasa { get; set; }
        public int ConsumoDiarioCalorias { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string CorreoElectronico { get; set; }
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Contrasena { get; set; }
        
        [JsonIgnore]
        public ICollection<RegistroDiario> RegistrosDiarios { get; set; }
        [JsonIgnore]
        public ICollection<Retroalimentacion> Retroalimentaciones { get; set; }
        [JsonIgnore]
        public ICollection<Paciente> Pacientes { get; set; }

    }
}
