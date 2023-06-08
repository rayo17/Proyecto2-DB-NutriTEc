namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class PlanAlimentacionData
    {
        public string NombrePlan { get; set; }
        public string NutricionistaId { get; set; }
        public string[] DesayunoProductoIds { get; set; }
        public string[] DesayunoRecetaIds { get; set; }
        public string[] MeriendaMananaProductoIds { get; set; }
        public string[] MeriendaMananaRecetaIds { get; set; }
        public string[] AlmuerzoProductoIds { get; set; }
        public string[] AlmuerzoRecetaIds { get; set; }
        public string[] MeriendaTardeProductoIds { get; set; }
        public string[] MeriendaTardeRecetaIds { get; set; }
        public string[] CenaProductoIds { get; set; }
        public string[] CenaRecetaIds { get; set; }
    }
}
