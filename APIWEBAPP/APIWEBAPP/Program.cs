using APIWEBAPP.Data;
using APIWEBAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Documentation", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<NutriTecDB>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation");
        c.RoutePrefix = string.Empty; // Para que SwaggerUI se muestre en la raíz del sitio
    });
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapPost("/Nutricionistas/", async (Nutricionista n, NutriTecDB db) =>
{
    db.Nutricionistas.Add(n);
    await db.SaveChangesAsync();

    return Results.Created($"/Nutricionistas/{n.Cedula}", n);
});

app.MapGet("/Nutricionistas/{Cedula:length(1,20)}", async (string cedula, NutriTecDB db) =>
{
    return await db.Nutricionistas.FindAsync(cedula)
        is Nutricionista n
        ? Results.Ok(n)
        : Results.NotFound();
});

app.MapGet("/Nutricionistas/", async (NutriTecDB db) => await db.Nutricionistas.ToListAsync());

app.MapPut("/Nutricionistas/{Cedula:length(1,20)}", async (string cedula, Nutricionista n, NutriTecDB db) =>
{
    if (n.Cedula != cedula)
        return Results.BadRequest();

    var nutricionista = await db.Nutricionistas.FindAsync(cedula);

    if (nutricionista is null) return Results.NotFound();

    nutricionista.Nombre = n.Nombre;
    nutricionista.Apellido1 = n.Apellido1;
    nutricionista.Apellido2 = n.Apellido2;
    nutricionista.Edad = n.Edad;
    nutricionista.FechaNacimiento = n.FechaNacimiento;
    nutricionista.Peso = n.Peso;
    nutricionista.IMC = n.IMC;
    nutricionista.Direccion = n.Direccion;
    nutricionista.Foto = n.Foto;
    nutricionista.NumTarjetaCredito = n.NumTarjetaCredito;
    nutricionista.CorreoElectronico = n.CorreoElectronico;
    nutricionista.Contrasena = n.Contrasena;
    
    
    

    await db.SaveChangesAsync();

    return Results.Ok(nutricionista);
});

app.MapDelete("/Nutricionistas/{Cedula:length(1,20)}", async (string cedula, NutriTecDB db) =>
{
    var nutricionista = await db.Nutricionistas.FindAsync(cedula);


    if (nutricionista is null) return Results.NotFound();

    db.Nutricionistas.Remove(nutricionista);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/Clientes/", async (Cliente c, NutriTecDB db) =>
{
    db.Clientes.Add(c);
    await db.SaveChangesAsync();

    return Results.Created($"/Clientes/{c.CorreoElectronico}", c);
});

app.MapGet("/Clientes/{CorreoElectronico:length(1,20)}", async (string correo, NutriTecDB db) =>
{
    return await db.Clientes.FindAsync(correo)
        is Cliente c
        ? Results.Ok(c)
        : Results.NotFound();
});

app.MapGet("/Clientes/", async (NutriTecDB db) => await db.Clientes.ToListAsync());

app.MapPut("/Clientes/{CorreoElectronico:length(1,20)}", async (string correo, Cliente c, NutriTecDB db) =>
{
    if (c.CorreoElectronico != correo)
        return Results.BadRequest();

    var cliente = await db.Clientes.FindAsync(correo);

    if (cliente is null) return Results.NotFound();

    cliente.Nombre = c.Nombre;
    cliente.Apellido1 = c.Apellido1;
    cliente.Apellido2 = c.Apellido2;
    cliente.Edad = c.Edad;
    cliente.FechaNacimiento = c.FechaNacimiento;
    cliente.Peso = c.Peso;
    cliente.IMC = c.IMC;
    cliente.PaisResidencia = c.PaisResidencia;
    cliente.PesoActual = c.PesoActual;
    cliente.Cintura = c.Cintura;
    cliente.PorcentajeMusculos = c.PorcentajeMusculos;
    cliente.Cuello = c.Cuello;
    cliente.Caderas = c.Caderas;
    cliente.PorcentajeGrasa = c.PorcentajeGrasa;
    cliente.ConsumoDiarioCalorias = c.ConsumoDiarioCalorias;
    cliente.CorreoElectronico = c.CorreoElectronico;
    cliente.Contrasena = c.Contrasena;
    
    
    
    
    
    
    

    await db.SaveChangesAsync();

    return Results.Ok(cliente);
});

app.MapDelete("/Clientes/{CorreoElectronico:length(1,20)}", async (string correo, NutriTecDB db) =>
{
    var cliente = await db.Clientes.FindAsync(correo);


    if (cliente is null) return Results.NotFound();

    db.Clientes.Remove(cliente);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/Administradores/", async (Administrador a, NutriTecDB db) =>
{
    db.Administradores.Add(a);
    await db.SaveChangesAsync();

    return Results.Created($"/Administradores/{a.CorreoElectronico}", a);
});

app.MapGet("/Administradores/{CorreoElectronico:length(1,20)}", async (string correo, NutriTecDB db) =>
{
    return await db.Administradores.FindAsync(correo)
        is Administrador a
        ? Results.Ok(a)
        : Results.NotFound();
});

app.MapGet("/Administradores/", async (NutriTecDB db) => await db.Administradores.ToListAsync());

app.MapPut("/Administradores/{CorreoElectronico:length(1,20)}", async (string correo, Administrador a, NutriTecDB db) =>
{
    if (a.CorreoElectronico != correo)
        return Results.BadRequest();

    var administrador = await db.Administradores.FindAsync(correo);

    if (administrador is null) return Results.NotFound();

    administrador.CorreoElectronico = a.CorreoElectronico;
    administrador.Contrasena = a.Contrasena;


    await db.SaveChangesAsync();

    return Results.Ok(administrador);
});

app.MapDelete("/Administradores/{CorreoElectronico:length(1,20)}", async (string correo, NutriTecDB db) =>
{
    var administrador = await db.Administradores.FindAsync(correo);


    if (administrador is null) return Results.NotFound();

    db.Administradores.Remove(administrador);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

