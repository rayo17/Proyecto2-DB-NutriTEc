using Newtonsoft.Json;

namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class ProductoEstructura
    {
        public string Codigobarra { get; set; }
        public string Nombre { get; set; }
        public int Taman_porcion { get; set; }
        public int Energia { get; set; }
        public int Grasa { get; set; }
        public int Sodio { get; set; }
        public int Carbohidratos { get; set; }
        public int Proteina { get; set; }
        public string Vitaminas { get; set; }
        public int Calcio { get; set; }
        public int Hierro { get; set; }
        public string Descripcion { get; set; }
        public bool EstadoProducto { get; set; }
    }
}
