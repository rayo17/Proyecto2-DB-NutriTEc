namespace ApiPosgreSQLDB.Models
{
    public class VisualizarPlanesPacientesResult
    {
        public string Paciente { get; set; }
        public string Nutricionista { get; set; }
        public string NombrePlan { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public int CaloriasTotales { get; set; }
        public string NombreProducto { get; set; }
        public string NombreReceta { get; set; }
        public string TiempoComida { get; set; }
    }
}
