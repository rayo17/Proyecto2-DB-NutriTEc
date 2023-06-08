using ApiPosgreSQLDB.Extra;
using ApiPosgreSQLDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;
using NpgsqlTypes;

namespace ApiPosgreSQLDB.Data
{
    public class NutriTecDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public NutriTecDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("PostgreSQLConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
        public string GetApiBaseUrl()
        {
            return _configuration["AppSettings:ApiBaseUrl"];
        }

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
        public DbSet<VisualizarPlanesPacientesResult> planes_v { get; set; }

        
        
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
            modelBuilder.Entity < PlanAlimentacion>()
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
                .HasKey(r => r.id);
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
            modelBuilder.Entity<ObtenerCedulaNutricionista>()
                .HasNoKey();
            modelBuilder.Entity<ClientesDisponibles>()
                .HasNoKey();
            modelBuilder.Entity<AsignarPlanCliente>()
                .HasNoKey();
            modelBuilder.Entity<MedidasPorClienteYPeriodoRequest>()
                .HasNoKey();
        }
    }
}
