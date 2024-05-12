﻿// <auto-generated />
using System;
using CustomerManagement.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CustomerManagement.DataAccess.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    partial class CustomerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CustomerManagement.DataAccess.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ApellidoCliente");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("CorreoElectronicoCliente");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<long>("EstadoCivilId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("FechaNacimientoCliente");

                    b.Property<long>("GeneroId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NacionalidadCliente");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NombreCliente");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("NumeroCuentaCliente");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NumeroIdentificacionCliente");

                    b.Property<string>("ProfesionOcupacion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ProfesionOcupacionCliente");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("numeric");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.Property<long>("TipoClienteId")
                        .HasColumnType("bigint");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCreacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_CLIENTE");

                    b.HasIndex("EstadoCivilId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TipoClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("CustomerManagement.DataAccess.Models.Parametros", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Ccodigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CodigoParametro");

                    b.Property<string>("Desripcion")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("DescripcionParametro");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<long?>("IdPadre")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("NombreParametro");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCreacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Valor")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ValorParametro");

                    b.HasKey("Id")
                        .HasName("PK_PARAMETRO");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdPadre");

                    b.ToTable("Parametros");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Activo = false,
                            Ccodigo = "ESTCIV",
                            Desripcion = "Lista de estados civiles",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Estado Civil",
                            UsuarioCreacion = "ADMIN"
                        },
                        new
                        {
                            Id = 2L,
                            Activo = false,
                            Ccodigo = "ESTCIV-SOLTERO",
                            Desripcion = "Estado Civil - Soltero",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPadre = 1L,
                            Nombre = "Soltero",
                            UsuarioCreacion = "ADMIN"
                        },
                        new
                        {
                            Id = 3L,
                            Activo = false,
                            Ccodigo = "ESTCIV-CASADO",
                            Desripcion = "Estado Civil - Casado",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPadre = 1L,
                            Nombre = "Casado",
                            UsuarioCreacion = "ADMIN"
                        },
                        new
                        {
                            Id = 4L,
                            Activo = false,
                            Ccodigo = "TIPCLI",
                            Desripcion = "Lista de tipos de cliente",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Tipo de Cliente",
                            UsuarioCreacion = "ADMIN"
                        },
                        new
                        {
                            Id = 5L,
                            Activo = false,
                            Ccodigo = "TIPCLI-INDIVIDUAL",
                            Desripcion = "Cliente Individual",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPadre = 4L,
                            Nombre = "Individual",
                            UsuarioCreacion = "ADMIN"
                        },
                        new
                        {
                            Id = 6L,
                            Activo = false,
                            Ccodigo = "TIPCLI-CORPORATIVO",
                            Desripcion = "Cliente Corporativo",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPadre = 4L,
                            Nombre = "Corporativo",
                            UsuarioCreacion = "ADMIN"
                        },
                        new
                        {
                            Id = 7L,
                            Activo = false,
                            Ccodigo = "TIPO-ID",
                            Desripcion = "Lista de tipos de identificación",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Tipo de Identificación",
                            UsuarioCreacion = "ADMIN"
                        },
                        new
                        {
                            Id = 8L,
                            Activo = false,
                            Ccodigo = "TIPO-ID-CEDULA",
                            Desripcion = "Número de identificación - Cédula",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPadre = 7L,
                            Nombre = "Cédula",
                            UsuarioCreacion = "ADMIN"
                        },
                        new
                        {
                            Id = 9L,
                            Activo = false,
                            Ccodigo = "TIPO-ID-PASAPORTE",
                            Desripcion = "Número de identificación - Pasaporte",
                            FechaCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPadre = 7L,
                            Nombre = "Pasaporte",
                            UsuarioCreacion = "ADMIN"
                        });
                });

            modelBuilder.Entity("CustomerManagement.DataAccess.Models.Cliente", b =>
                {
                    b.HasOne("CustomerManagement.DataAccess.Models.Parametros", "EstadoCivil")
                        .WithMany()
                        .HasForeignKey("EstadoCivilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CustomerManagement.DataAccess.Models.Parametros", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CustomerManagement.DataAccess.Models.Parametros", "TipoCliente")
                        .WithMany()
                        .HasForeignKey("TipoClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EstadoCivil");

                    b.Navigation("Genero");

                    b.Navigation("TipoCliente");
                });

            modelBuilder.Entity("CustomerManagement.DataAccess.Models.Parametros", b =>
                {
                    b.HasOne("CustomerManagement.DataAccess.Models.Parametros", "ParametroPadre")
                        .WithMany("ParametrosHijo")
                        .HasForeignKey("IdPadre")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParametroPadre");
                });

            modelBuilder.Entity("CustomerManagement.DataAccess.Models.Parametros", b =>
                {
                    b.Navigation("ParametrosHijo");
                });
#pragma warning restore 612, 618
        }
    }
}
