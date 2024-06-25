using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TiendaAPI.Data;
using TiendaAPI.Servicios;
using TiendaAPI.Servicios.Aplicacion;
using TiendaAPI.Servicios.Aplicacion.BaseDatos;
using TiendaAPI.Servicios.Aplicacion.Factory;
using TiendaAPI.Servicios.Aplicacion.Logs;
using TiendaAPI.Servicios.Negocios;
using TiendaAPI.Servicios.Negocios.AreaAlmacen;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.Almacen;
using TiendaAPI.Servicios.Negocios.AreaAlmacen.AreaCompras;
using TiendaAPI.Servicios.Negocios.AreaElaboracion;
using TiendaAPI.Servicios.Negocios.AreaElaboracion.AdaptadoresDeElaboracion;
using TiendaAPI.Servicios.Negocios.AreaElaboracion.StockDeElaboracion;
using TiendaAPI.Servicios.Negocios.AreaVentas;
using TiendaAPI.Servicios.Negocios.AreaVentas.GeneracionDeReportes;
using TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeOfertas;
using TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeProdcutosVendidos;
using TiendaAPI.Servicios.Negocios.AreaVentas.ZonaDeVentas;
using TiendaAPI.Servicios.Negocios.ServicioDeTraduccion.AdaptadoresDeAlmacen;
using TiendaAPI.Servicios.Negocios.ServiciosGenerales;
using TiendaAPI.Servicios.Negocios.ServiciosGenerales.Adaptadores;

var builder = WebApplication.CreateBuilder(args);

var baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "API");
var dbPath = Path.Combine(baseDir, "Datos.db");

var logPath = Path.Combine(baseDir, "Log");
var imagesPath = Path.Combine(baseDir, "Imagenes");
var categoriesPath = Path.Combine(imagesPath, "Categorias");
var productsPath = Path.Combine(imagesPath, "Productos");


// Verificar y crear la carpeta de Log si no existe
if (!Directory.Exists(logPath))
{
    Directory.CreateDirectory(logPath);
}

// Verificar y crear la carpeta base si no existe
if (!Directory.Exists(baseDir))
{
    Directory.CreateDirectory(baseDir);
}


// Verificar y crear la carpeta de Imagenes si no existe
if (!Directory.Exists(imagesPath))
{
    Directory.CreateDirectory(imagesPath);
}

// Verificar y crear la carpeta de Categorias si no existe
if (!Directory.Exists(categoriesPath))
{
    Directory.CreateDirectory(categoriesPath);
}

// Verificar y crear la carpeta de Productos si no existe
if (!Directory.Exists(productsPath))
{
    Directory.CreateDirectory(productsPath);
}

// Add services to the container.
//Configurar Inyeccion de Dependencias

//Dependencias de Aplicacion
builder.Services.AddTransient<IPorSQLite, PorSQLite>();
builder.Services.AddScoped<IGenericFactory, GenericFactory>();
builder.Services.AddScoped<IServiciosLogs, ServiciosLogs>();
builder.Services.AddScoped<IServiciosAplicacion, ServiciosAplicacion>();

//Dependencias de Negocios
builder.Services.AddScoped<IAlmacen, Almacen>();
builder.Services.AddScoped<IControladorDeVentas, ControladorDeVentas>();
builder.Services.AddScoped<IReportesDeVentas, ReporteDeVentas>();
builder.Services.AddScoped<IProductosVendidos, ProductosVendidos>();
builder.Services.AddScoped<IServiciosVentas, ServiciosVentas>();
builder.Services.AddScoped<IAdaptadorMateriasPrimas, AdaptadorMateriasPrimas>();
builder.Services.AddScoped<IServiciosAlmacen, ServiciosAlmacen>();
builder.Services.AddScoped<IServiciosElaboracion, ServiciosElaboracion>();
builder.Services.AddScoped<IServiciosVentas, ServiciosVentas>();
builder.Services.AddScoped<IElaboracion, Elaboracion>();
builder.Services.AddScoped<IServiciosNegocios, ServiciosNegocios>();
builder.Services.AddScoped<IServicios, Servicios>();
builder.Services.AddScoped<ITraduccion, Traduccion>();
builder.Services.AddScoped<IServiciosCompras, ServiciosCompras>();
builder.Services.AddScoped<IServiciosGenerales, ServicioGeneral>();
builder.Services.AddScoped<IAdaptadorIngredientes, AdaptadorIngredientes>();
builder.Services.AddScoped<IAdaptadorMateriasPrimas, AdaptadorMateriasPrimas>();
builder.Services.AddScoped<IRectorDeCategorias,RectorDeOfertas>();

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
