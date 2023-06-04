using APIWEBAPP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace APIWEBAPP.Data
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
        public DbSet<Administrador> Administradores => Set<Administrador>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<EstadoProducto> EstadoProductos => Set<EstadoProducto>();
        public DbSet<Nutricionista> Nutricionistas => Set<Nutricionista>();
        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<PlanAlimentacion> PlanesAlimentacion => Set<PlanAlimentacion>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<ProductoPlan> ProductosPlan => Set<ProductoPlan>();
        public DbSet<Receta> Recetas => Set<Receta>();
        public DbSet<RegistroDiario> RegistrosDiarios => Set<RegistroDiario>();
        public DbSet<ReporteCobro> ReportesCobro => Set<ReporteCobro>();
        public DbSet<Retroalimentacion> Retroalimentaciones => Set<Retroalimentacion>();
        public DbSet<TiempoComida> TiempoComidas => Set<TiempoComida>();
        public DbSet<TipoCobro> TipoCobros => Set<TipoCobro>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoProducto>()
            .HasOne(ep => ep.Producto)
            .WithMany()
            .HasForeignKey(ep => ep.ProductoID)
            .HasPrincipalKey(p => p.CodigoBarra);

            modelBuilder.Entity<Nutricionista>()
                .HasOne(n => n.TipoCobro)
                .WithMany()
                .HasForeignKey(n => n.TipoCobroID)
                .HasPrincipalKey(tp => tp.ID);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteID)
                .HasPrincipalKey(c => c.ID);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Nutricionista)
                .WithMany()
                .HasForeignKey(p => p.NutricionistaID)
                .HasPrincipalKey(n => n.Cedula);

            modelBuilder.Entity<PlanAlimentacion>()
                .HasOne(pa => pa.Nutricionista)
                .WithMany()
                .HasForeignKey(pa => pa.NutricionistaID)
                .HasPrincipalKey(n => n.Cedula);

            modelBuilder.Entity<ProductoPlan>()
                .HasOne(pp => pp.Producto)
                .WithMany()
                .HasForeignKey(pp => pp.ProductoID)
                .HasPrincipalKey(p => p.CodigoBarra);

            modelBuilder.Entity<ProductoPlan>()
                .HasOne(pp => pp.TiempoComida)
                .WithMany()
                .HasForeignKey(pp => pp.TiempoComidaID)
                .HasPrincipalKey(tc => tc.ID);

            modelBuilder.Entity<Receta>()
                .HasOne(r => r.Producto)
                .WithMany()
                .HasForeignKey(r => r.ProductoID)
                .HasPrincipalKey(p => p.CodigoBarra);

            modelBuilder.Entity<RegistroDiario>()
                .HasOne(rd => rd.Cliente)
                .WithMany()
                .HasForeignKey(rd => rd.ClienteID)
                .HasPrincipalKey(c => c.ID);

            modelBuilder.Entity<RegistroDiario>()
                .HasOne(rd => rd.TiempoComida)
                .WithMany()
                .HasForeignKey(rd => rd.TiempoComidaID)
                .HasPrincipalKey(tc => tc.ID);

            modelBuilder.Entity<ReporteCobro>()
                .HasOne(rc => rc.Nutricionista)
                .WithMany()
                .HasForeignKey(rc => rc.NutricionistaID)
                .HasPrincipalKey(n => n.Cedula);

            modelBuilder.Entity<ReporteCobro>()
                .HasOne(rc => rc.TipoCobro)
                .WithMany()
                .HasForeignKey(rc => rc.TipoCobroID)
                .HasPrincipalKey(tc => tc.ID);

            modelBuilder.Entity<Retroalimentacion>()
                .HasOne(r => r.Nutricionista)
                .WithMany()
                .HasForeignKey(r => r.NutricionistaID)
                .HasPrincipalKey(n => n.Cedula);

            modelBuilder.Entity<Retroalimentacion>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.ClienteID)
                .HasPrincipalKey(n => n.ID);

            modelBuilder.Entity<TiempoComida>()
                .HasOne(tc => tc.PlanAlimentacion)
                .WithMany()
                .HasForeignKey(tc => tc.PlanAlimentacionID)
                .HasPrincipalKey(pa => pa.ID);

            modelBuilder.Entity<Nutricionista>()
                .Ignore(n => n.PlanesAlimentacion);

            modelBuilder.Entity<Nutricionista>()
                .Ignore(n => n.Cobros);

            modelBuilder.Entity<Nutricionista>()
                .Ignore(n => n.Retroalimentaciones);

            modelBuilder.Entity<Nutricionista>()
                .Ignore(n => n.Pacientes);

            modelBuilder.Entity<Cliente>()
                .Ignore(n => n.RegistrosDiarios);

            modelBuilder.Entity<Cliente>()
                .Ignore(n => n.Retroalimentaciones);
            
            modelBuilder.Entity<Cliente>()
                .Ignore(n => n.Pacientes);

            modelBuilder.Entity<PlanAlimentacion>()
                .Ignore(pa => pa.TiempoComidas);

            modelBuilder.Entity<Producto>()
                .Ignore(p => p.EstadosProducto);

            modelBuilder.Entity<Producto>()
                .Ignore(p => p.ProductosPlan);

            modelBuilder.Entity<Producto>()
                .Ignore(p => p.Recetas);

            modelBuilder.Entity<TiempoComida>()
                .Ignore(tc => tc.RegistrosDiarios);

            modelBuilder.Entity<TipoCobro>()
                .Ignore(tc => tc.Nutricionistas);

            modelBuilder.Entity<TipoCobro>()
                .Ignore(tc => tc.ReporteCobros);

            // Resto de configuraciones y definiciones de entidades

            base.OnModelCreating(modelBuilder);


        }
    }
}
