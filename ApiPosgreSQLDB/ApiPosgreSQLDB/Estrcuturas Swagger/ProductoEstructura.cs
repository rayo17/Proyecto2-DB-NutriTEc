using Newtonsoft.Json;

namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class ProductoEstructura
    {
        [JsonProperty("codigo_barra")]
        public string CodigoBarra { get; set; }
    }
}
