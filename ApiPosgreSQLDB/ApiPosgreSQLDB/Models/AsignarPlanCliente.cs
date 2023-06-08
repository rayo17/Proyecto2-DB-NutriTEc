namespace ApiPosgreSQLDB.Models
{
    public class AsignarPlanCliente
    {
        public string pacienteid { get; set; }
        public string nutricionistaid { get; set; }
        public string planid { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafinalizacion { get; set; }
    }
}
