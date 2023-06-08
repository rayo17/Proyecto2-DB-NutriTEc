namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class PlanAlimentacionDataJson
    {
        public string PlanNombre { get; set; }
        public int NutricionistaId { get; set; }
        public Dictionary<string, List<ItemAlimentacion>> TiemposComida { get; set; }

    }

}
