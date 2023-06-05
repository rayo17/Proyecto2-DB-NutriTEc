﻿using ApiPosgreSQLDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones de entidades y relaciones
            modelBuilder.Entity<Administrador>()
                .HasKey(a => a.id);
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.id);
            modelBuilder.Entity<EstadoProducto>()
                .HasKey(e => e.id);
            modelBuilder.Entity<Nutricionista>()
                .HasKey(n => n.cedula);
            modelBuilder.Entity<Paciente>()
                .HasKey(p => p.id);
            modelBuilder.Entity < PlanAlimentacion>()
                .HasKey(p => p.id);
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.codigobarra);
            modelBuilder.Entity<ProductoPlan>()
                .HasKey(p => p.id);
            modelBuilder.Entity<Receta>()
                .HasKey(r => r.id);
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
        }
    }
}
