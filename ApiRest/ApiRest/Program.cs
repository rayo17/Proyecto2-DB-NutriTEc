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

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}