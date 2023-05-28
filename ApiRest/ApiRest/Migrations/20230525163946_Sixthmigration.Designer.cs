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
    [Migration("20230525163946_Sixthmigration")]
    partial class Sixthmigration
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
                        .HasColumnType("text");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("correo");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("ApiRest.Models.Cliente", b =>
                {
                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<string>("apellido1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("apellido2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("caderas")
                        .HasColumnType("integer");

                    b.Property<int>("cintura")
                        .HasColumnType("integer");

                    b.Property<int>("consumo_diario_c")
                        .HasColumnType("integer");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("text");

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
                        .HasColumnType("text");

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

                    b.Property<int>("cod_barras_nutri")
                        .HasColumnType("integer");

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

            modelBuilder.Entity("ApiRest.Models.Nutricionista", b =>
                {
                    b.Property<string>("cedula")
                        .HasColumnType("text");

                    b.Property<string>("apellido1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("apellido2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("cod_barras")
                        .HasColumnType("integer");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("text");

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
                        .HasColumnType("text");

                    b.Property<int>("num_tarj_credi")
                        .HasColumnType("integer");

                    b.Property<int>("peso")
                        .HasColumnType("integer");

                    b.HasKey("cedula");

                    b.ToTable("Nutricionistas");
                });
#pragma warning restore 612, 618
        }
    }
}
