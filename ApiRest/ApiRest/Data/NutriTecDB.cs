using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Data
{
    public class NutriTecDB : DbContext
    {


        public NutriTecDB(DbContextOptions<NutriTecDB> options) : base(options) 
        { 
            

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
    }
}
