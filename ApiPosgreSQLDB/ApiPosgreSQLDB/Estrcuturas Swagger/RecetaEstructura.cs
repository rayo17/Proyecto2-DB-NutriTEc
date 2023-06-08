using Newtonsoft.Json;

namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class RecetaEstructura
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
    }
}
