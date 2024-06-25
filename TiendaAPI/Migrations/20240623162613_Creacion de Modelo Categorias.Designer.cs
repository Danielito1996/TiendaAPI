﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaAPI.Data;

#nullable disable

namespace TiendaAPI.Migrations
{
    [DbContext(typeof(TiendaDbContext))]
    [Migration("20240623162613_Creacion de Modelo Categorias")]
    partial class CreaciondeModeloCategorias
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("TiendaAPI.Modelos.AreaAlmacen.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaAlmacen.MateriaPrima", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("InventarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UnidadMedida")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InventarioId");

                    b.ToTable("MateriasPrimas");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MateriaPrimaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NormasTecnicasId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StockDeIngredientesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UnidadMedida")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormasTecnicasId");

                    b.HasIndex("StockDeIngredientesId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.NormasTecnicas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("PrecioDeCosto")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("CartasDeNormasTecnicas");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.PlanGeneral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PlanesGenerales");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.PlanIndividual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<int>("PlanGeneralId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlanGeneralId");

                    b.HasIndex("ProductoId");

                    b.ToTable("PlanesIndividuales");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.StockDeIngredientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StocksDeIngredientes");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaFinanzas.Adquisicion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("MontoTotal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Adquisiciones");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaFinanzas.Compras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdquisicionId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<string>("MateriaPrima")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("PrecioDeCompra")
                        .HasColumnType("REAL");

                    b.Property<string>("UnidadDeMedida")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdquisicionId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.ProductosListosParaVentas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ProductosListosParaVentas");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.ReporteVentasGenerales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalPrecioDeCosto")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalPrecioDeVentas")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("ReportesDeVentas");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FacturaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.Generales.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int?>("ProductosListosParaVentasId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductosListosParaVentasId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.Generales.ProductoVendido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<int?>("ReporteVentasGeneralesId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VentaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("productoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReporteVentasGeneralesId");

                    b.HasIndex("VentaId");

                    b.HasIndex("productoId");

                    b.ToTable("ProductosVendidos");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaAlmacen.MateriaPrima", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.AreaAlmacen.Inventario", null)
                        .WithMany("MateriaPrima")
                        .HasForeignKey("InventarioId");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.Ingrediente", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.AreaElaboracion.NormasTecnicas", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("NormasTecnicasId");

                    b.HasOne("TiendaAPI.Modelos.AreaElaboracion.StockDeIngredientes", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("StockDeIngredientesId");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.NormasTecnicas", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.Generales.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.PlanIndividual", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.AreaElaboracion.PlanGeneral", "PlanGeneral")
                        .WithMany("PlanesIndividuales")
                        .HasForeignKey("PlanGeneralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TiendaAPI.Modelos.Generales.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanGeneral");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaFinanzas.Compras", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.AreaFinanzas.Adquisicion", null)
                        .WithMany("Compras")
                        .HasForeignKey("AdquisicionId");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.Venta", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.AreaVenta.Factura", null)
                        .WithMany("Ventas")
                        .HasForeignKey("FacturaId");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.Generales.Producto", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.AreaVenta.ProductosListosParaVentas", null)
                        .WithMany("Productos")
                        .HasForeignKey("ProductosListosParaVentasId");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.Generales.ProductoVendido", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.AreaVenta.ReporteVentasGenerales", null)
                        .WithMany("ProductosVendidos")
                        .HasForeignKey("ReporteVentasGeneralesId");

                    b.HasOne("TiendaAPI.Modelos.AreaVenta.Venta", null)
                        .WithMany("Productos")
                        .HasForeignKey("VentaId");

                    b.HasOne("TiendaAPI.Modelos.Generales.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaAlmacen.Inventario", b =>
                {
                    b.Navigation("MateriaPrima");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.NormasTecnicas", b =>
                {
                    b.Navigation("Ingredientes");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.PlanGeneral", b =>
                {
                    b.Navigation("PlanesIndividuales");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaElaboracion.StockDeIngredientes", b =>
                {
                    b.Navigation("Ingredientes");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaFinanzas.Adquisicion", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.Factura", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.ProductosListosParaVentas", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.ReporteVentasGenerales", b =>
                {
                    b.Navigation("ProductosVendidos");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.Venta", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
