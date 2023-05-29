using ApiRest.Data;
using ApiRest.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
    nutricionista.direccion = n.direccion;

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
    cliente.paisresidencia = c.paisresidencia;
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

app.MapPost("/Administradores/", async (Administrador a, NutriTecDB db) =>
{
    db.Administradores.Add(a);
    await db.SaveChangesAsync();

    return Results.Created($"/Administradores/{a.correo}", a);
});

app.MapGet("/Administradores/{correo:length(1,20)}", async (string correo, NutriTecDB db) =>
{
    return await db.Administradores.FindAsync(correo)
        is Administrador a
        ? Results.Ok(a)
        : Results.NotFound();
});

app.MapGet("/Administradores/", async (NutriTecDB db) => await db.Administradores.ToListAsync());

app.MapPut("/Administradores/{correo:length(1,20)}", async (string correo, Administrador a, NutriTecDB db) =>
{
    if (a.correo != correo)
        return Results.BadRequest();

    var administrador = await db.Administradores.FindAsync(correo);

    if (administrador is null) return Results.NotFound();

    administrador.correo = a.correo;
    administrador.contrasena = a.contrasena;
    

    await db.SaveChangesAsync();

    return Results.Ok(administrador);
});

app.MapDelete("/Administradores/{correo:length(1,20)}", async (string correo, NutriTecDB db) =>
{
    var administrador = await db.Administradores.FindAsync(correo);


    if (administrador is null) return Results.NotFound();

    db.Administradores.Remove(administrador);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/Cobros/", async (Cobro c, NutriTecDB db) =>
{
    db.Cobros.Add(c);
    await db.SaveChangesAsync();

    return Results.Created($"/Cobros/{c.id_nutri}", c);
});

app.MapGet("/Cobros/{id_nutri:length(1,20)}", async (string id_nutri, NutriTecDB db) =>
{
    return await db.Cobros.FindAsync(id_nutri)
        is Cobro c
        ? Results.Ok(c)
        : Results.NotFound();
});

app.MapGet("/Cobros/", async (NutriTecDB db) => await db.Cobros.ToListAsync());

app.MapPut("/Cobros/{id_nutri:length(1,20)}", async (string id_nutri, Cobro c, NutriTecDB db) =>
{
    if (c.id_nutri != id_nutri)
        return Results.BadRequest();

    var cobro = await db.Cobros.FindAsync(id_nutri);

    if (cobro is null) return Results.NotFound();

    cobro.plan = c.plan;
    cobro.monto_t = c.monto_t;
    cobro.descuento = c.descuento;

    await db.SaveChangesAsync();

    return Results.Ok(cobro);
});

app.MapDelete("/Cobros/{id_nutri:length(1,20)}", async (string id_nutri, NutriTecDB db) =>
{
    var cobro = await db.Cobros.FindAsync(id_nutri);


    if (cobro is null) return Results.NotFound();

    db.Cobros.Remove(cobro);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/Consumos/", async (Consumo c, NutriTecDB db) =>
{
    db.Consumos.Add(c);
    await db.SaveChangesAsync();

    return Results.Created($"/Consumos/{c.correo_cliente}", c);
});

app.MapGet("/Consumos/{correo_cliente:length(1,20)}", async (string correo_cliente, NutriTecDB db) =>
{
    return await db.Consumos.FindAsync(correo_cliente)
        is Consumo c
        ? Results.Ok(c)
        : Results.NotFound();
});

app.MapGet("/Consumos/", async (NutriTecDB db) => await db.Consumos.ToListAsync());

app.MapPut("/Consumos/{correo_cliente:length(1,20)}", async (string correo_cliente, Consumo c, NutriTecDB db) =>
{
    if (c.correo_cliente != correo_cliente)
        return Results.BadRequest();

    var consumo = await db.Consumos.FindAsync(correo_cliente);

    if (consumo is null) return Results.NotFound();

    consumo.fecha = c.fecha;
    consumo.desayuno = c.desayuno;
    consumo.merienda_m = c.merienda_m;
    consumo.almuerzo = c.almuerzo;
    consumo.merienda_t = c.merienda_t;
    consumo.cena = c.cena;

    await db.SaveChangesAsync();

    return Results.Ok(consumo);
});

app.MapDelete("/Consumos/{correo_cliente:length(1,20)}", async (string correo_cliente, NutriTecDB db) =>
{
    var consumo = await db.Consumos.FindAsync(correo_cliente);


    if (consumo is null) return Results.NotFound();

    db.Consumos.Remove(consumo);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/EstadoProductos/", async (EstadoProducto ep, NutriTecDB db) =>
{
    db.EstadoProductos.Add(ep);
    await db.SaveChangesAsync();

    return Results.Created($"/EstadoProductos/{ep.codigo_barra}", ep);
});

app.MapGet("/EstadoProductos/{codigo_barra:int}", async (int codigo_barra, NutriTecDB db) =>
{
    return await db.EstadoProductos.FindAsync(codigo_barra)
        is EstadoProducto ep
        ? Results.Ok(ep)
        : Results.NotFound();
});

app.MapGet("/EstadoProductos/", async (NutriTecDB db) => await db.EstadoProductos.ToListAsync());

app.MapPut("/EstadoProductos/{codigo_barra:int}", async (int codigo_barra, EstadoProducto ep, NutriTecDB db) =>
{
    if (ep.codigo_barra != codigo_barra)
        return Results.BadRequest();

    var estadoproducto = await db.EstadoProductos.FindAsync(codigo_barra);

    if (estadoproducto is null) return Results.NotFound();

    estadoproducto.estado = ep.estado;
    

    await db.SaveChangesAsync();

    return Results.Ok(estadoproducto);
});

app.MapDelete("/EstadoProductos/{codigo_barra:int}", async (int codigo_barra, NutriTecDB db) =>
{
    var estadoproducto = await db.EstadoProductos.FindAsync(codigo_barra);


    if (estadoproducto is null) return Results.NotFound();

    db.EstadoProductos.Remove(estadoproducto);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/nutricionista_asigna_clientes/", async (nutricionista_asigna_cliente nac, NutriTecDB db) =>
{
    db.nutricionista_asigna_clientes.Add(nac);
    await db.SaveChangesAsync();

    return Results.Created($"/nutricionista_asigna_clientes/{nac.correo_cliente}", nac);
});

app.MapGet("/nutricionista_asigna_clientes/{correo_cliente:length(1,20)}", async (string correo_cliente, NutriTecDB db) =>
{
    return await db.nutricionista_asigna_clientes.FindAsync(correo_cliente)
        is nutricionista_asigna_cliente nac
        ? Results.Ok(nac)
        : Results.NotFound();
});

app.MapGet("/nutricionista_asigna_clientes/", async (NutriTecDB db) => await db.nutricionista_asigna_clientes.ToListAsync());

app.MapPut("/nutricionista_asigna_clientes/{correo_cliente:length(1,20)}", async (string correo_cliente, nutricionista_asigna_cliente nac, NutriTecDB db) =>
{
    if (nac.correo_cliente != correo_cliente)
        return Results.BadRequest();

    var nutricionista_asigna_cliente = await db.nutricionista_asigna_clientes.FindAsync(correo_cliente);

    if (nutricionista_asigna_cliente is null) return Results.NotFound();

    nutricionista_asigna_cliente.fecha_i = nac.fecha_i;
    nutricionista_asigna_cliente.fecha_f = nac.fecha_f;


    await db.SaveChangesAsync();

    return Results.Ok(nutricionista_asigna_cliente);
});

app.MapDelete("/nutricionista_asigna_clientes/{correo_cliente:length(1,20)}", async (string correo_cliente, NutriTecDB db) =>
{
    var nutricionista_asigna_cliente = await db.nutricionista_asigna_clientes.FindAsync(correo_cliente);


    if (nutricionista_asigna_cliente is null) return Results.NotFound();

    db.nutricionista_asigna_clientes.Remove(nutricionista_asigna_cliente);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapPost("/Planes/", async (Plan p, NutriTecDB db) =>
{
    db.Planes.Add(p);
    await db.SaveChangesAsync();

    return Results.Created($"/Planes/{p.nombre_plan}", p);
});

app.MapGet("/Planes/{nombre_plan:length(1,20)}", async (string nombre_plan, NutriTecDB db) =>
{
    return await db.Planes.FindAsync(nombre_plan)
        is Plan p
        ? Results.Ok(p)
        : Results.NotFound();
});

app.MapGet("/Planes/", async (NutriTecDB db) => await db.Planes.ToListAsync());

app.MapPut("/Planes/{nombre_plan:length(1,20)}", async (string nombre_plan, Plan p, NutriTecDB db) =>
{
    if (p.nombre_plan != nombre_plan)
        return Results.BadRequest();

    var plan = await db.Planes.FindAsync(nombre_plan);

    if (plan is null) return Results.NotFound();

    plan.desayuno = p.desayuno;
    plan.merienda_m = p.merienda_m;
    plan.almuerzo = p.almuerzo;
    plan.merienda_t = p.merienda_t;
    plan.cena = p.cena;


    await db.SaveChangesAsync();

    return Results.Ok(plan);
});

app.MapDelete("/Planes/{nombre_plan:length(1,20)}", async (string nombre_plan, NutriTecDB db) =>
{
    var plan = await db.Planes.FindAsync(nombre_plan);


    if (plan is null) return Results.NotFound();

    db.Planes.Remove(plan);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/Productos/", async (Producto p, NutriTecDB db) =>
{
    db.Productos.Add(p);
    await db.SaveChangesAsync();

    return Results.Created($"/Productos/{p.codigo_barra}", p);
});

app.MapGet("/Productos/{codigo_barra:int}", async (int codigo_barra, NutriTecDB db) =>
{
    return await db.Productos.FindAsync(codigo_barra)
        is Producto p
        ? Results.Ok(p)
        : Results.NotFound();
});

app.MapGet("/Productos/", async (NutriTecDB db) => await db.Productos.ToListAsync());

app.MapPut("/Productos/{codigo_barra:int}", async (int codigo_barra, Producto p, NutriTecDB db) =>
{
    if (p.codigo_barra != codigo_barra)
        return Results.BadRequest();

    var producto = await db.Productos.FindAsync(codigo_barra);

    if (producto is null) return Results.NotFound();

    producto.nombre = p.nombre;
    producto.grasa = p.grasa;
    producto.taman_porcion = p.taman_porcion;
    producto.energia = p.energia;
    producto.descripcion = p.descripcion;
    producto.proteina = p.proteina;
    producto.sodio = p.sodio;
    producto.hierro = p.hierro;
    producto.calcio = p.calcio;
    producto.vitaminas = p.vitaminas;
    producto.carbohidratos = p.carbohidratos;

    await db.SaveChangesAsync();

    return Results.Ok(producto);
});

app.MapDelete("/Productos/{codigo_barra:int}", async (int codigo_barra, NutriTecDB db) =>
{
    var producto = await db.Productos.FindAsync(codigo_barra);


    if (producto is null) return Results.NotFound();

    db.Productos.Remove(producto);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.MapPost("/TipoCobros/", async (TipoCobro tp, NutriTecDB db) =>
{
    db.TipoCobros.Add(tp);
    await db.SaveChangesAsync();

    return Results.Created($"/TipoCobros/{tp.cedula}", tp);
});

app.MapGet("/TipoCobros/{cedula:length(1,20)}", async (string cedula, NutriTecDB db) =>
{
    return await db.TipoCobros.FindAsync(cedula)
        is TipoCobro tp
        ? Results.Ok(tp)
        : Results.NotFound();
});

app.MapGet("/TipoCobros/", async (NutriTecDB db) => await db.TipoCobros.ToListAsync());

app.MapPut("/TipoCobros/{cedula:length(1,20)}", async (string cedula, TipoCobro tp, NutriTecDB db) =>
{
    if (tp.cedula != cedula)
        return Results.BadRequest();

    var tipocobro = await db.TipoCobros.FindAsync(cedula);

    if (tipocobro is null) return Results.NotFound();

    tipocobro.tipo_cobro = tp.tipo_cobro;
    

    await db.SaveChangesAsync();

    return Results.Ok(tipocobro);
});

app.MapDelete("/TipoCobros/{cedula:length(1,20)}", async (string cedula, NutriTecDB db) =>
{
    var tipocobro = await db.TipoCobros.FindAsync(cedula);


    if (tipocobro is null) return Results.NotFound();

    db.TipoCobros.Remove(tipocobro);
    await db.SaveChangesAsync();

    return Results.NoContent();

});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}