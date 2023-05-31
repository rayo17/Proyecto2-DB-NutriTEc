using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Data
{
    public class NutriTecDB : DbContext
    {

        private readonly IConfiguration configuration;

        public NutriTecDB(DbContextOptions<NutriTecDB> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }
        public string GetApiBaseUrl()
        {
            return configuration["AppSettings:ApiBaseUrl"];
        }

        public DbSet<Nutricionista> Nutricionistas => Set<Nutricionista>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Administrador> Administradores => Set<Administrador>();
        public DbSet<Cobro> Cobros => Set<Cobro>();
        public DbSet<Consumo> Consumos => Set<Consumo>();
        public DbSet<EstadoProducto> EstadoProductos => Set<EstadoProducto>();
        public DbSet<nutricionista_asigna_cliente> nutricionista_asigna_clientes => Set<nutricionista_asigna_cliente>();
        public DbSet<Plan> Planes => Set<Plan>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<TipoCobro> TipoCobros => Set<TipoCobro>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoCobro>()
                .HasKey(tc => new { tc.cedula});

            modelBuilder.Entity<TipoCobro>()
                .HasOne(tc => tc.Nutricionista)
                .WithMany()
                .HasForeignKey(tc => new { tc.cedula})
                .HasPrincipalKey(n => new { n.cedula})
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cobro>()
                .HasKey(c => new { c.id_nutri});

            modelBuilder.Entity<Cobro>()
                .HasOne(c => c.Nutricionista)
                .WithMany(n => n.Cobros)
                .HasForeignKey(c => new { c.id_nutri})
                .HasPrincipalKey(n => new { n.cedula})
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consumo>()
                .HasKey(c => c.correo_cliente);

            modelBuilder.Entity<Consumo>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Consumos)
                .HasForeignKey(c => c.correo_cliente)
                .HasPrincipalKey(c => c.correo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EstadoProducto>()
                .HasKey(ep => ep.codigo_barra);

            modelBuilder.Entity<EstadoProducto>()
                .HasOne(ep => ep.Producto)
                .WithMany()
                .HasForeignKey(ep => ep.codigo_barra)
                .HasPrincipalKey(p => p.codigo_barra)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<nutricionista_asigna_cliente>()
                .HasKey(nac => new { nac.id_nutricionista, nac.correo_cliente });

            modelBuilder.Entity<nutricionista_asigna_cliente>()
                .HasOne(nac => nac.Cliente)
                .WithMany()
                .HasForeignKey(nac => nac.correo_cliente)
                .HasPrincipalKey(c => c.correo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<nutricionista_asigna_cliente>()
                .HasOne(nac => nac.Nutricionista)
                .WithMany()
                .HasForeignKey(nac => new { nac.id_nutricionista})
                .HasPrincipalKey(n => new { n.cedula})
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Nutricionista>()
                .Ignore(n => n.TipoCobros);

            modelBuilder.Entity<Nutricionista>()
                .Ignore(n => n.Cobros);

            modelBuilder.Entity<Nutricionista>()
                .Ignore(n => n.NutricionistasAsignados);

            modelBuilder.Entity<Cliente>()
                .Ignore(n => n.Consumos);

            modelBuilder.Entity<Cliente>()
                .Ignore(n => n.NutricionistasAsignados);

            modelBuilder.Entity<Producto>()
                .Ignore(n => n.EstadosProducto);

            // Resto de configuraciones y definiciones de entidades

            base.OnModelCreating(modelBuilder);

            
        }
    }
}
