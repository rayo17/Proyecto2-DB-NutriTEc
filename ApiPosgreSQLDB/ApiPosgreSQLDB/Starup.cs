using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApiPosgreSQLDB.Models;
using ApiPosgreSQLDB.Data;
using ApiPosgreSQLDB.Controllers; // Importar los controladores

namespace ApiPosgreSQLDB
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar la conexión a la base de datos
            var ConnectionString = Configuration.GetConnectionString("PostgreSQLConnection");
            services.AddDbContext<NutriTecDBContext>(options =>
                options.UseNpgsql(ConnectionString));

            // Agregar servicios al contenedor
            services.AddControllers(); // Agregar soporte para controladores API

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Documentation", Version = "v1" });
            });

            // Otros servicios y configuraciones...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation");
                    c.RoutePrefix = string.Empty; // Para que SwaggerUI se muestre en la raíz del sitio
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Mapear los endpoints de los controladores API
                // Otros endpoints...
            });
        }
    }
}

