using ApiRest.Data;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<NutriTecDB>(opcions =>
    opcions.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Nutricionistas/", async (Nutricionista n, NutriTecDB db) =>
{
    db.Nutricionistas.Add(n);
    await db.SaveChangesAsync();

    return Results.Created($"/Nutricionistas/{n.cedula}", n);
});

app.MapGet("/Nutricionistas/{cedula:length(1,20)}", async (string cedula, NutriTecDB db) =>
{
    return await db.Nutricionistas.FindAsync(cedula)
        is Nutricionista n
        ? Results.Ok(n)
        : Results.NotFound();
});

app.MapGet("/Nutricionistas/", async (NutriTecDB db) => await db.Nutricionistas.ToListAsync());

app.MapPut("/Nutricionistas/{cedula:length(1,20)}", async (string cedula, Nutricionista n, NutriTecDB db) =>
{
    if (n.cedula != cedula)
        return Results.BadRequest();

    var nutricionista = await db.Nutricionistas.FindAsync(cedula);

    if(nutricionista is null) return Results.NotFound();

    nutricionista.nombre = n.nombre;   
    nutricionista.apellido1 = n.apellido1;
    nutricionista.apellido2 = n.apellido2;
    nutricionista.foto = n.foto;
    nutricionista.num_tarj_credi = n.num_tarj_credi;
    nutricionista.edad = n.edad;
    nutricionista.fecha_nacimiento = n.fecha_nacimiento;
    nutricionista.contrasena = n.contrasena;
    nutricionista.imc = n.imc;
    nutricionista.peso = n.peso;

    await db.SaveChangesAsync();

    return Results.Ok(nutricionista);
});

app.MapDelete("/Nutricionistas/{cedula:length(1,20)}", async(string cedula, NutriTecDB db) =>
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

    return Results.Created($"/Clientes/{c.correo}", c);
});

app.MapGet("/Clientes/{correo:length(1,20)}", async (string correo, NutriTecDB db) =>
{
    return await db.Clientes.FindAsync(correo)
        is Cliente c
        ? Results.Ok(c)
        : Results.NotFound();
});

app.MapGet("/Clientes/", async (NutriTecDB db) => await db.Clientes.ToListAsync());

app.MapPut("/Clientes/{correo:length(1,20)}", async (string correo, Cliente c, NutriTecDB db) =>
{
    if (c.correo != correo)
        return Results.BadRequest();

    var cliente = await db.Clientes.FindAsync(correo);

    if (cliente is null) return Results.NotFound();

    cliente.correo = c.correo;
    cliente.nombre = c.nombre;
    cliente.apellido1 = c.apellido1;
    cliente.apellido2 = c.apellido2;
    cliente.contrasena = c.contrasena;
    cliente.fecha_nacimiento = c.fecha_nacimiento;
    cliente.edad = c.edad;
    cliente.peso = c.peso;
    cliente.imc = c.imc;
    cliente.cintura = c.cintura;
    cliente.pmuslos = c.pmuslos;
    cliente.cuello = c.cuello;
    cliente.caderas = c.caderas;
    cliente.pgrasa = c.pgrasa;
    cliente.consumo_diario_c = c.consumo_diario_c;
    cliente.fecha_medicion = c.fecha_medicion;

    await db.SaveChangesAsync();

    return Results.Ok(cliente);
});

app.MapDelete("/Clientes/{correo:length(1,20)}", async (string correo, NutriTecDB db) =>
{
    var cliente = await db.Clientes.FindAsync(correo);


    if (cliente is null) return Results.NotFound();

    db.Clientes.Remove(cliente);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}