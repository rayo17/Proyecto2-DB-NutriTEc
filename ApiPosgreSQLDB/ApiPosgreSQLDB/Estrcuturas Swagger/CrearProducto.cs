namespace ApiPosgreSQLDB.Estrcuturas_Swagger
{
    public class CrearProducto
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
        public string idcreador { get; set; }
    }

}
