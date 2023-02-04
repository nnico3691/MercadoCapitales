﻿// <auto-generated />
using System;
using MercadoCapitales.API.Clientes.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MercadoCapitales.API.Clientes.Migrations
{
    [DbContext(typeof(ContextCliente))]
    partial class ContextClienteModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MercadoCapitales.API.Clientes.Modelo.Cliente", b =>
                {
                    b.Property<Guid?>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenRecovery")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MercadoCapitales.API.Clientes.Modelo.ClienteEncuestas", b =>
                {
                    b.Property<Guid?>("ClienteEncuestasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClieKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EncuestaRespuesta")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClienteEncuestasId");

                    b.ToTable("ClienteEncuestas");
                });

            modelBuilder.Entity("MercadoCapitales.API.Clientes.Modelo.ClientePerfilInversor", b =>
                {
                    b.Property<Guid?>("ClientePerfilInversorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EncuestaRespuestaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClientePerfilInversorId");

                    b.ToTable("ClientePerfilInversor");
                });

            modelBuilder.Entity("MercadoCapitales.API.Clientes.Modelo.EncuestaPregunta", b =>
                {
                    b.Property<Guid?>("EncuestaPreguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Pregunta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EncuestaPreguntaId");

                    b.ToTable("EncuestaPregunta");
                });

            modelBuilder.Entity("MercadoCapitales.API.Clientes.Modelo.EncuestaRespuesta", b =>
                {
                    b.Property<Guid?>("EncuestaRespuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EncuestaPreguntaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameInput")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.Property<string>("Respuesta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoInput")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EncuestaRespuestaId");

                    b.HasIndex("EncuestaPreguntaId");

                    b.ToTable("EncuestaRespuesta");
                });

            modelBuilder.Entity("MercadoCapitales.API.Clientes.Modelo.Login", b =>
                {
                    b.Property<Guid?>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Cliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("MercadoCapitales.API.Clientes.Modelo.EncuestaRespuesta", b =>
                {
                    b.HasOne("MercadoCapitales.API.Clientes.Modelo.EncuestaPregunta", null)
                        .WithMany("encuestaRespuestas")
                        .HasForeignKey("EncuestaPreguntaId");
                });
#pragma warning restore 612, 618
        }
    }
}
