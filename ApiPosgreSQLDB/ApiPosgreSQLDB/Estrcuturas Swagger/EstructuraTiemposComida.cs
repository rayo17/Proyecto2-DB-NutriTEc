using ApiPosgreSQLDB.Models;
using Newtonsoft.Json;

namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class EstructuraTiemposComida
    {
        public List<ProductoEstructura> Desayuno { get; set; }
        public List<ProductoEstructura> MeriendaManana { get; set; }
        public List<ProductoEstructura> Almuerzo { get; set; }
        public List<ProductoEstructura> MeriendaTarde { get; set; }
        public List<ProductoEstructura> Cena { get; set; }
    }
}
