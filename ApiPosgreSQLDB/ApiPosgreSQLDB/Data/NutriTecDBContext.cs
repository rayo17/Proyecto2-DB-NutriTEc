using ApiPosgreSQLDB.Estrcuturas_Swagger;//Contiene las estructuras necesarias para la generación de documentación Swagger.
using ApiPosgreSQLDB.Extra;//Contiene clases adicionales utilizadas en la aplicación.
using ApiPosgreSQLDB.Models;//Contiene las clases de modelos utilizadas para representar entidades en la base de datos.
using Microsoft.EntityFrameworkCore;// Contiene las clases necesarias para trabajar con Entity Framework Core.
using Microsoft.EntityFrameworkCore.Metadata;//Contiene clases para trabajar con metadatos del modelo.
using Npgsql;//Contiene clases para interactuar con la base de datos PostgreSQL.
using NpgsqlTypes;//Contiene tipos de datos específicos de PostgreSQL para su uso en consultas y parámetros.

namespace ApiPosgreSQLDB.Data
{
    /*El código proporcionado muestra la definición de la clase NutriTecDBContext que 
     * extiende la clase DbContext de Entity Framework Core. Esta clase se utiliza para
     * interactuar con la base de datos y mapear las entidades del modelo a tablas en la 
     * base de datos.
     */
    public class NutriTecDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        /*La clase NutriTecDBContext tiene un constructor que acepta una instancia de
         * IConfiguration que se utiliza para obtener la cadena de conexión a la base de datos.
         */
        public NutriTecDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /*El método OnConfiguring se sobrescribe para configurar la conexión a la base de
         *datos utilizando la cadena de conexión obtenida del IConfiguration.
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("PostgreSQLConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
        public string GetApiBaseUrl()
        {
            return _configuration["AppSettings:ApiBaseUrl"];
        }
        /*Se definen propiedades de tipo DbSet<T> para cada una de las entidades del modelo,
         * como administradores, clientes, estadoproductos, etc. Estas propiedades representan
         * las tablas en la base de datos y se utilizan para realizar consultas y operaciones CRUD.
         */
        public DbSet<Administrador> administradores { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<EstadoProducto> estadoproductos { get; set; }
        public DbSet<Nutricionista> nutricionistas { get; set; }
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<PlanAlimentacion> planesalimentacion { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<ProductoPlan> productosplan { get; set; }
        public DbSet<Receta> receta { get; set; }
        public DbSet<RegistroDiario> registrodiario { get; set; }
        public DbSet<ReporteCobro> reportecobro { get; set; }
        public DbSet<Retroalimentacion> retroalimentacion { get; set; }
        public DbSet<TiempoComida> tiempocomida { get; set; }
        public DbSet<TipoCobro> tipocobro { get; set; }
        public DbSet<Medidas> medidas { get; set; }
        public DbSet<ValidacionLogin> validacion { get; set; }
        public DbSet<PlanAlimentacionverCliente> verpplancliente { get; set; }



        /*Se definen métodos con atributos DbFunction que representan llamadas a funciones 
         * almacenadas en la base de datos. Estos métodos se utilizan para ejecutar 
         * procedimientos almacenados o funciones en la base de datos y retornar resultados.
         */
        [DbFunction("public", "registrar_cliente")]
        public virtual int RegistrarCliente(string nombre, string apellido1, string apellido2, int edad, DateTime fechaNacimiento, int peso, int imc, string paisResidencia, int pesoActual, int cintura, int porcentajeMusculos, int cuello, int caderas, int porcentajeGrasa, int consumoDiarioCalorias, string correoElectronico, string contrasena)
        {
            var result = this.Database.ExecuteSqlRaw("SELECT public.registrar_cliente({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17})",
                nombre, apellido1, apellido2, edad, fechaNacimiento, peso, imc, paisResidencia, pesoActual, cintura, porcentajeMusculos, cuello,
                caderas, porcentajeGrasa, consumoDiarioCalorias, correoElectronico, contrasena);

            return result;
        }
        [DbFunction("public", "validarlogincliente")]
        public virtual int ValidarLoginCliente(string correo, string contrasena)
        {
            var parameters = new[]
            {
        new NpgsqlParameter("p_correo", NpgsqlDbType.Varchar) { Value = correo },
        new NpgsqlParameter("p_contrasena", NpgsqlDbType.Varchar) { Value = contrasena }
    };

            var query = this.Database.ExecuteSqlInterpolated($"SELECT public.validarlogincliente({parameters[0]}, {parameters[1]})");
            var result = Convert.ToInt32(query);

            return result;
        }
        /*El método OnModelCreating se sobrescribe para configurar las relaciones y claves 
         * primarias de las entidades del modelo utilizando Fluent API. Se definen las claves 
         * primarias utilizando el método HasKey, y también se definen algunas entidades 
         * sin clave primaria utilizando HasNoKey.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones de entidades y relaciones
            modelBuilder.Entity<Administrador>()
                .HasKey(a => a.id);
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.correoelectronico);
            modelBuilder.Entity<EstadoProducto>()
                .HasKey(e => e.id);
            modelBuilder.Entity<Nutricionista>()
                .HasKey(n => n.cedula);
            modelBuilder.Entity<Paciente>()
                .HasNoKey();
            modelBuilder.Entity<PlanAlimentacion>()
                .HasKey(p => p.id);
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.codigobarra);
            modelBuilder.Entity<ProductoPlan>()
                .HasKey(p => p.id);
            modelBuilder.Entity<Receta>()
                .HasKey(r => r.nombre);
            modelBuilder.Entity<RegistroDiario>()
                .HasKey(r => r.id);
            modelBuilder.Entity<ReporteCobro>()
                .HasKey(r => r.TipoCobroID);
            modelBuilder.Entity<Retroalimentacion>()
                .HasKey(r => r.id);
            modelBuilder.Entity<TiempoComida>()
                .HasKey(t => t.id);
            modelBuilder.Entity<TipoCobro>()
                .HasKey(t => t.id);
            modelBuilder.Entity<Medidas>()
                .HasKey(m => m.id);
            modelBuilder.Entity<ValidacionLogin>()
                .HasKey(v => v.correoelectronico);
            modelBuilder.Entity<ValidarProducto>()
                .HasKey(v => v.cod_barras);
            modelBuilder.Entity<ConsultaPeriodoMedidas>()
                .HasNoKey();
            modelBuilder.Entity<PlanAlimentacionverCliente>()
                .HasNoKey();
            
        }
    }
}
