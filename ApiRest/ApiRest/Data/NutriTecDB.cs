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
    }
}
