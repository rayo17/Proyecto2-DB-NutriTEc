using ApiPosgreSQLDB.Models;
using Newtonsoft.Json;

namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class EstructuraTiemposComida
    {
        [JsonProperty("desayunoP")]
        public List<ProductoEstructura> DesayunoP { get; set; }

        [JsonProperty("desayunoR")]
        public List<RecetaEstructura> DesayunoR { get; set; }

        [JsonProperty("meriendaMananaP")]
        public List<ProductoEstructura> MeriendaMananaP { get; set; }

        [JsonProperty("meriendaMananaR")]
        public List<RecetaEstructura> MeriendaMananaR { get; set; }

        [JsonProperty("almuerzoP")]
        public List<ProductoEstructura> AlmuerzoP { get; set; }

        [JsonProperty("almuerzoR")]
        public List<RecetaEstructura> AlmuerzoR { get; set; }

        [JsonProperty("meriendaTardeP")]
        public List<ProductoEstructura> MeriendaTardeP { get; set; }

        [JsonProperty("meriendaTardeR")]
        public List<RecetaEstructura> MeriendaTardeR { get; set; }

        [JsonProperty("cenaP")]
        public List<ProductoEstructura> CenaP { get; set; }

        [JsonProperty("cenaR")]
        public List<RecetaEstructura> CenaR { get; set; }
    }
}
