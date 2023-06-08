using ApiPosgreSQLDB.Models;
using Newtonsoft.Json;

namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class EstructuraPlanAlimentacion
    {
        [JsonProperty("plan_nombre")]
        public string PlanNombre { get; set; }

        [JsonProperty("nutricionista")]
        public int Nutricionista { get; set; }

        [JsonProperty("tiempos_comida")]
        public EstructuraTiemposComida TiemposComida { get; set; }
    }
}
