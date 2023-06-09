using ApiPosgreSQLDB.Models;

namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class PlanAlimentacionverCliente
    {
        public string NombrePlan { get; set; }
        public int CaloriasTotalPlan { get; set; }
        public string NombreTiempoComida { get; set; }
        public string NombreNutricionista { get; set; }
        public List<string> ProductosUtilizados { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
    }
}