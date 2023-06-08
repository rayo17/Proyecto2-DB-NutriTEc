namespace ApiPosgreSQLDB.Models
{
    public class GestionRecetas
    {
        public string clienteid { get; set; }
        public int tiempocomidaid { get; set; }
        public DateTime fecha { get; set; }
        public List<string> productosid { get; set; }
    }
}
