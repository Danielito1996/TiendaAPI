using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios.AreaAlmacen;
using TiendaAPI.Servicios.Negocios.AreaElaboracion;
using TiendaAPI.Servicios.Negocios.AreaVentas;
using TiendaAPI.Servicios.Negocios;
using TiendaAPI.Servicios;
using TiendaAPI.Servicios.Aplicacion;

var builder = WebApplication.CreateBuilder(args);

var baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "API");
var dbPath = Path.Combine(baseDir, "Datos.db");

// Verificar si la carpeta no existe y crearla si es necesario
if (!Directory.Exists(baseDir))
{
    Directory.CreateDirectory(baseDir);
}

// Verificar si el archivo no existe y crearlo si es necesario
if (!File.Exists(dbPath))
{
    File.Create(dbPath).Close();
}

// Add services to the container.
//Configurar Inyeccion de Dependencias

//Dependencias de Aplicacion
builder.Services.AddTransient<IPorSQLite, PorSQLite>();
builder.Services.AddScoped<IGenericFactory, GenericFactory>();
builder.Services.AddScoped<IServiciosLogs, ServiciosLogs>();
builder.Services.AddScoped<IServiciosAplicacion,ServiciosAplicacion>();

//Dependencias de Negocios
builder.Services.AddScoped<IAlmacen, Almacen>();
builder.Services.AddScoped<IAdaptadorMateriasPrimas,AdaptadorMateriasPrimas>();
builder.Services.AddScoped<IServiciosAlmacen, ServiciosAlmacen>();
builder.Services.AddScoped<IServiciosElaboracion, ServiciosElaboracion>();
builder.Services.AddScoped<IServiciosVentas, ServiciosVentas>();
builder.Services.AddScoped<IServiciosNegocios, ServiciosNegocios>();
builder.Services.AddScoped<IServicios, Servicios>();
builder.Services.AddScoped<ITraduccion,Traduccion>();
builder.Services.AddScoped<IAdaptadorIngredientes,AdaptadorIngredientes>();
builder.Services.AddScoped<IAdaptadorMateriasPrimas, AdaptadorMateriasPrimas>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Agrega los servicios de EF Core.
builder.Services.AddDbContext<TiendaDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
