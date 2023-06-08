namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class PlanAlimentacionData
    {
        public string NombrePlan { get; set; }
        public string NutricionistaId { get; set; }
        public List<string> DesayunoProductoIds { get; set; }
        public List<string> MeriendaMananaProductoIds { get; set; }
        public List<string> AlmuerzoProductoIds { get; set; }
        public List<string> MeriendaTardeProductoIds { get; set; }
        public List<string> CenaProductoIds { get; set; }
    }
}
