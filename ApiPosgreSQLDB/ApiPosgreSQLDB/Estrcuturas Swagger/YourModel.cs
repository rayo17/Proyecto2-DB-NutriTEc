using Newtonsoft.Json;

namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{//Estructura para el body de ingreso registro diario
    public class YourModel
    {
        public string idCliente { get; set; }
        public List<Comida> desayuno { get; set; }
        public List<Comida> meriendaManana { get; set; }
        public List<Comida> almuerzo { get; set; }
        public List<Comida> meriendaTarde { get; set; }
        public List<Comida> cena { get; set; }
    }

    public class Comida
    {
        public List<Alimento> alimento { get; set; }
        public string tiempoComida { get; set; }
        public string fecha { get; set; }
    }

    public class Alimento
    {
        public string codigobarra { get; set; }
        public string nombre { get; set; }
        public int taman_porcion { get; set; }
        public int energia { get; set; }
        public int grasa { get; set; }
        public int sodio { get; set; }
        public int carbohidratos { get; set; }
        public int proteina { get; set; }
        public string vitaminas { get; set; }
        public int calcio { get; set; }
        public int hierro { get; set; }
        public string descripcion { get; set; }
        public bool estadoproducto { get; set; }
    }
}
