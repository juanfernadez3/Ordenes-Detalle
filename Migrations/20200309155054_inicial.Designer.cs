﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrdenesDeCompra.Dal;

namespace OrdenesDeCompra.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200309155054_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("OrdenesDeCompra.Entidades.Clientes", b =>
                {
                    b.Property<int>("CLienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("CLienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("OrdenesDeCompra.Entidades.OrdenDetalle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdenId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("OrdenId");

                    b.ToTable("OrdenDetalle");
                });

            modelBuilder.Entity("OrdenesDeCompra.Entidades.Ordenes", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientesCLienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaOrden")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("OrdenId");

                    b.HasIndex("ClientesCLienteId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("OrdenesDeCompra.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("OrdenesDeCompra.Entidades.OrdenDetalle", b =>
                {
                    b.HasOne("OrdenesDeCompra.Entidades.Ordenes", null)
                        .WithMany("Detalles")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrdenesDeCompra.Entidades.Ordenes", b =>
                {
                    b.HasOne("OrdenesDeCompra.Entidades.Clientes", null)
                        .WithMany("Ordenes")
                        .HasForeignKey("ClientesCLienteId");
                });
#pragma warning restore 612, 618
        }
    }
}
