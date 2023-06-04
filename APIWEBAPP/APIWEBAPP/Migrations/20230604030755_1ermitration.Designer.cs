﻿// <auto-generated />
using System;
using APIWEBAPP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIWEBAPP.Migrations
{
    [DbContext(typeof(NutriTecDB))]
    [Migration("20230604030755_1ermitration")]
    partial class _1ermitration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("APIWEBAPP.Models.Administrador", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("varchar");

                    b.HasKey("ID");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<int>("Caderas")
                        .HasColumnType("integer");

                    b.Property<int>("Cintura")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumoDiarioCalorias")
                        .HasColumnType("integer");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("Cuello")
                        .HasColumnType("integer");

                    b.Property<int>("Edad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IMC")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("PaisResidencia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.Property<int>("PesoActual")
                        .HasColumnType("integer");

                    b.Property<int>("PorcentajeGrasa")
                        .HasColumnType("integer");

                    b.Property<int>("PorcentajeMusculos")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("APIWEBAPP.Models.EstadoProducto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<bool>("Estado")
                        .HasColumnType("boolean");

                    b.Property<string>("FechaAprobacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("ProductoID")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.HasKey("ID");

                    b.HasIndex("ProductoID");

                    b.ToTable("EstadoProductos");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Nutricionista", b =>
                {
                    b.Property<string>("Cedula")
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("CododigoBarras")
                        .IsRequired()
                        .HasMaxLength(127)
                        .HasColumnType("varchar");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("varchar");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<int>("Edad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("bytea");

                    b.Property<int>("IMC")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("NumTarjetaCredito")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.Property<int>("TipoCobroID")
                        .HasColumnType("integer");

                    b.HasKey("Cedula");

                    b.HasIndex("TipoCobroID");

                    b.ToTable("Nutricionistas");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Paciente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<int>("Caderas")
                        .HasColumnType("integer");

                    b.Property<int>("Cintura")
                        .HasColumnType("integer");

                    b.Property<int>("ClienteID")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumoDiarioCalorias")
                        .HasColumnType("integer");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("Cuello")
                        .HasColumnType("integer");

                    b.Property<int>("Edad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IMC")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaisResidencia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.Property<int>("PesoActual")
                        .HasColumnType("integer");

                    b.Property<int>("PorcentajeGrasa")
                        .HasColumnType("integer");

                    b.Property<int>("PorcentajeMusculos")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("APIWEBAPP.Models.PlanAlimentacion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CaloriasTotalPlan")
                        .HasColumnType("integer");

                    b.Property<string>("NombrePlan")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("NutricionistaID")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.HasKey("ID");

                    b.HasIndex("NutricionistaID");

                    b.ToTable("PlanesAlimentacion");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Producto", b =>
                {
                    b.Property<string>("CodigoBarra")
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<bool>("EstadoProducto")
                        .HasColumnType("boolean");

                    b.Property<int>("calcio")
                        .HasColumnType("integer");

                    b.Property<int>("carbohidratos")
                        .HasColumnType("integer");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<int>("energia")
                        .HasColumnType("integer");

                    b.Property<int>("grasa")
                        .HasColumnType("integer");

                    b.Property<int>("hierro")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<int>("proteina")
                        .HasColumnType("integer");

                    b.Property<int>("sodio")
                        .HasColumnType("integer");

                    b.Property<int>("taman_porcion")
                        .HasColumnType("integer");

                    b.Property<string>("vitaminas")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.HasKey("CodigoBarra");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("APIWEBAPP.Models.ProductoPlan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ProductoID")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<int>("TiempoComidaID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("TiempoComidaID");

                    b.ToTable("ProductosPlan");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Receta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CaloriasTotalesReceta")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<string>("ProductoID")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.HasKey("ID");

                    b.HasIndex("ProductoID");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("APIWEBAPP.Models.RegistroDiario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("CantidadComsumida")
                        .HasColumnType("integer");

                    b.Property<int>("ClienteID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TiempoComidaID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("TiempoComidaID");

                    b.ToTable("RegistrosDiarios");
                });

            modelBuilder.Entity("APIWEBAPP.Models.ReporteCobro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("Descuento")
                        .HasColumnType("integer");

                    b.Property<int>("MontoCobrar")
                        .HasColumnType("integer");

                    b.Property<int>("MontoTotal")
                        .HasColumnType("integer");

                    b.Property<string>("NutricionistaID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("TipoCobroID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("NutricionistaID");

                    b.HasIndex("TipoCobroID");

                    b.ToTable("ReportesCobro");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Retroalimentacion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("ClienteID")
                        .HasColumnType("integer");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NutricionistaID")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("NutricionistaID");

                    b.ToTable("Retroalimentaciones");
                });

            modelBuilder.Entity("APIWEBAPP.Models.TiempoComida", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar");

                    b.Property<int>("PlanAlimentacionID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("PlanAlimentacionID");

                    b.ToTable("TiempoComidas");
                });

            modelBuilder.Entity("APIWEBAPP.Models.TipoCobro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("NombreTipoCobro")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.HasKey("ID");

                    b.ToTable("TipoCobros");
                });

            modelBuilder.Entity("APIWEBAPP.Models.EstadoProducto", b =>
                {
                    b.HasOne("APIWEBAPP.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Nutricionista", b =>
                {
                    b.HasOne("APIWEBAPP.Models.TipoCobro", "TipoCobro")
                        .WithMany()
                        .HasForeignKey("TipoCobroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoCobro");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Paciente", b =>
                {
                    b.HasOne("APIWEBAPP.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("APIWEBAPP.Models.PlanAlimentacion", b =>
                {
                    b.HasOne("APIWEBAPP.Models.Nutricionista", "Nutricionista")
                        .WithMany()
                        .HasForeignKey("NutricionistaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutricionista");
                });

            modelBuilder.Entity("APIWEBAPP.Models.ProductoPlan", b =>
                {
                    b.HasOne("APIWEBAPP.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIWEBAPP.Models.TiempoComida", "TiempoComida")
                        .WithMany()
                        .HasForeignKey("TiempoComidaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("TiempoComida");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Receta", b =>
                {
                    b.HasOne("APIWEBAPP.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("APIWEBAPP.Models.RegistroDiario", b =>
                {
                    b.HasOne("APIWEBAPP.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIWEBAPP.Models.TiempoComida", "TiempoComida")
                        .WithMany()
                        .HasForeignKey("TiempoComidaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TiempoComida");
                });

            modelBuilder.Entity("APIWEBAPP.Models.ReporteCobro", b =>
                {
                    b.HasOne("APIWEBAPP.Models.Nutricionista", "Nutricionista")
                        .WithMany()
                        .HasForeignKey("NutricionistaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIWEBAPP.Models.TipoCobro", "TipoCobro")
                        .WithMany()
                        .HasForeignKey("TipoCobroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutricionista");

                    b.Navigation("TipoCobro");
                });

            modelBuilder.Entity("APIWEBAPP.Models.Retroalimentacion", b =>
                {
                    b.HasOne("APIWEBAPP.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIWEBAPP.Models.Nutricionista", "Nutricionista")
                        .WithMany()
                        .HasForeignKey("NutricionistaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Nutricionista");
                });

            modelBuilder.Entity("APIWEBAPP.Models.TiempoComida", b =>
                {
                    b.HasOne("APIWEBAPP.Models.PlanAlimentacion", "PlanAlimentacion")
                        .WithMany()
                        .HasForeignKey("PlanAlimentacionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanAlimentacion");
                });
#pragma warning restore 612, 618
        }
    }
}
