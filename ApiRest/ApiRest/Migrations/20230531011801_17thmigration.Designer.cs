﻿// <auto-generated />
using System;
using ApiRest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiRest.Migrations
{
    [DbContext(typeof(NutriTecDB))]
    [Migration("20230531011801_17thmigration")]
    partial class _17thmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiRest.Models.Administrador", b =>
                {
                    b.Property<string>("correo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("correo");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("ApiRest.Models.Cliente", b =>
                {
                    b.Property<string>("correo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("apellido1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("apellido2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("caderas")
                        .HasColumnType("integer");

                    b.Property<int>("cintura")
                        .HasColumnType("integer");

                    b.Property<int>("consumo_diario_c")
                        .HasColumnType("integer");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("cuello")
                        .HasColumnType("integer");

                    b.Property<int>("edad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("fecha_medicion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fecha_nacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("imc")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("paisresidencia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("peso")
                        .HasColumnType("integer");

                    b.Property<int>("pgrasa")
                        .HasColumnType("integer");

                    b.Property<int>("pmuslos")
                        .HasColumnType("integer");

                    b.HasKey("correo");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ApiRest.Models.Cobro", b =>
                {
                    b.Property<string>("id_nutri")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("descuento")
                        .HasColumnType("integer");

                    b.Property<int>("monto_t")
                        .HasColumnType("integer");

                    b.Property<string>("plan")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.HasKey("id_nutri");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("ApiRest.Models.Consumo", b =>
                {
                    b.Property<string>("correo_cliente")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("almuerzo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("cena")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("desayuno")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("merienda_m")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("merienda_t")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("correo_cliente");

                    b.ToTable("Consumos");
                });

            modelBuilder.Entity("ApiRest.Models.EstadoProducto", b =>
                {
                    b.Property<int>("codigo_barra")
                        .HasColumnType("integer");

                    b.Property<int?>("Productocodigo_barra")
                        .HasColumnType("integer");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("codigo_barra");

                    b.HasIndex("Productocodigo_barra");

                    b.ToTable("EstadoProductos");
                });

            modelBuilder.Entity("ApiRest.Models.Nutricionista", b =>
                {
                    b.Property<string>("cedula")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("apellido1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("apellido2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("cod_barras")
                        .HasColumnType("integer");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("edad")
                        .HasColumnType("integer");

                    b.Property<DateTime>("fecha_nacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("foto")
                        .HasColumnType("bytea");

                    b.Property<int>("imc")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("num_tarj_credi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("peso")
                        .HasColumnType("integer");

                    b.HasKey("cedula");

                    b.ToTable("Nutricionistas");
                });

            modelBuilder.Entity("ApiRest.Models.Plan", b =>
                {
                    b.Property<string>("nombre_plan")
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("almuerzo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("cena")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("desayuno")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("merienda_m")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("merienda_t")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("nombre_plan");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("ApiRest.Models.Producto", b =>
                {
                    b.Property<int>("codigo_barra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("codigo_barra"));

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
                        .HasMaxLength(20)
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

                    b.HasKey("codigo_barra");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ApiRest.Models.TipoCobro", b =>
                {
                    b.Property<string>("cedula")
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("Nutricionistacedula")
                        .HasColumnType("varchar");

                    b.Property<string>("tipo_cobro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.HasKey("cedula");

                    b.HasIndex("Nutricionistacedula");

                    b.ToTable("TipoCobros");
                });

            modelBuilder.Entity("ApiRest.Models.nutricionista_asigna_cliente", b =>
                {
                    b.Property<string>("id_nutricionista")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("correo_cliente")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Clientecorreo")
                        .HasColumnType("varchar");

                    b.Property<string>("Nutricionistacedula")
                        .HasColumnType("varchar");

                    b.Property<DateTime>("fecha_f")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("fecha_i")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id_nutricionista", "correo_cliente");

                    b.HasIndex("Clientecorreo");

                    b.HasIndex("Nutricionistacedula");

                    b.HasIndex("correo_cliente");

                    b.ToTable("nutricionista_asigna_clientes");
                });

            modelBuilder.Entity("ApiRest.Models.Cobro", b =>
                {
                    b.HasOne("ApiRest.Models.Nutricionista", "Nutricionista")
                        .WithMany("Cobros")
                        .HasForeignKey("id_nutri")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Nutricionista");
                });

            modelBuilder.Entity("ApiRest.Models.Consumo", b =>
                {
                    b.HasOne("ApiRest.Models.Cliente", "Cliente")
                        .WithMany("Consumos")
                        .HasForeignKey("correo_cliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ApiRest.Models.EstadoProducto", b =>
                {
                    b.HasOne("ApiRest.Models.Producto", null)
                        .WithMany("EstadosProducto")
                        .HasForeignKey("Productocodigo_barra");

                    b.HasOne("ApiRest.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("codigo_barra")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("ApiRest.Models.TipoCobro", b =>
                {
                    b.HasOne("ApiRest.Models.Nutricionista", null)
                        .WithMany("TipoCobros")
                        .HasForeignKey("Nutricionistacedula");

                    b.HasOne("ApiRest.Models.Nutricionista", "Nutricionista")
                        .WithMany()
                        .HasForeignKey("cedula")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Nutricionista");
                });

            modelBuilder.Entity("ApiRest.Models.nutricionista_asigna_cliente", b =>
                {
                    b.HasOne("ApiRest.Models.Cliente", null)
                        .WithMany("NutricionistasAsignados")
                        .HasForeignKey("Clientecorreo");

                    b.HasOne("ApiRest.Models.Nutricionista", null)
                        .WithMany("NutricionistasAsignados")
                        .HasForeignKey("Nutricionistacedula");

                    b.HasOne("ApiRest.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("correo_cliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiRest.Models.Nutricionista", "Nutricionista")
                        .WithMany()
                        .HasForeignKey("id_nutricionista")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Nutricionista");
                });

            modelBuilder.Entity("ApiRest.Models.Cliente", b =>
                {
                    b.Navigation("Consumos");

                    b.Navigation("NutricionistasAsignados");
                });

            modelBuilder.Entity("ApiRest.Models.Nutricionista", b =>
                {
                    b.Navigation("Cobros");

                    b.Navigation("NutricionistasAsignados");

                    b.Navigation("TipoCobros");
                });

            modelBuilder.Entity("ApiRest.Models.Producto", b =>
                {
                    b.Navigation("EstadosProducto");
                });
#pragma warning restore 612, 618
        }
    }
}
