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
    [Migration("20240422081109_Actualizcin del modelo Compra")]
    partial class ActualizcindelmodeloCompra
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

                    b.HasIndex("ProductoId");

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

                    b.Property<int>("MateriaPrimaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrecioDeCompra")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdquisicionId");

                    b.HasIndex("MateriaPrimaId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.ProductosListosParaVentas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ProductosListosParaVentas");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

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

                    b.Property<int?>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductosListosParaVentasId");

                    b.HasIndex("VentaId");

                    b.ToTable("Productos");
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

                    b.HasOne("TiendaAPI.Modelos.Generales.Producto", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("ProductoId");

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

                    b.HasOne("TiendaAPI.Modelos.AreaAlmacen.MateriaPrima", "MateriaPrima")
                        .WithMany()
                        .HasForeignKey("MateriaPrimaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MateriaPrima");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.Generales.Producto", b =>
                {
                    b.HasOne("TiendaAPI.Modelos.AreaVenta.ProductosListosParaVentas", null)
                        .WithMany("Productos")
                        .HasForeignKey("ProductosListosParaVentasId");

                    b.HasOne("TiendaAPI.Modelos.AreaVenta.Venta", null)
                        .WithMany("Productos")
                        .HasForeignKey("VentaId");
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

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.ProductosListosParaVentas", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.AreaVenta.Venta", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("TiendaAPI.Modelos.Generales.Producto", b =>
                {
                    b.Navigation("Ingredientes");
                });
#pragma warning restore 612, 618
        }
    }
}
