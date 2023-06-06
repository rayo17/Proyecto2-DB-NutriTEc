﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPosgreSQLDB.Models
{
    public class Cliente
    {
        public string correoelectronico { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public int edad { get; set; }
        public DateTime fechanacimiento { get; set; }
        public int peso { get; set; }
        public int imc { get; set; }
        public string paisresidencia { get; set; }
        public int consumodiariocalorias { get; set; }
        public string contrasena { get; set; }
        

    }
}
