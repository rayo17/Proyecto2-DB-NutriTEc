namespace ApiPosgreSQLDB.Models
{
    public class MedidasPorClienteYPeriodoRequest
    {
        public string ClienteID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}
