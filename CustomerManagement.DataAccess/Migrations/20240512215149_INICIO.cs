using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class INICIO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoParametro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NombreParametro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DescripcionParametro = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ValorParametro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdPadre = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioCreacion = table.Column<string>(type: "text", nullable: false),
                    UsuarioActualizacion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETRO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parametros_Parametros_IdPadre",
                        column: x => x.IdPadre,
                        principalTable: "Parametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreCliente = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ApellidoCliente = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NumeroCuentaCliente = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Saldo = table.Column<decimal>(type: "numeric", nullable: false),
                    FechaNacimientoCliente = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    CorreoElectronicoCliente = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EstadoCivilId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroIdentificacionCliente = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TipoClienteId = table.Column<long>(type: "bigint", nullable: false),
                    ProfesionOcupacionCliente = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GeneroId = table.Column<long>(type: "bigint", nullable: false),
                    NacionalidadCliente = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioCreacion = table.Column<string>(type: "text", nullable: false),
                    UsuarioActualizacion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Parametros_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "Parametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Parametros_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Parametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Parametros_TipoClienteId",
                        column: x => x.TipoClienteId,
                        principalTable: "Parametros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "CodigoParametro", "DescripcionParametro", "FechaActualizacion", "IdPadre", "NombreParametro", "UsuarioActualizacion", "UsuarioCreacion", "ValorParametro" },
                values: new object[,]
                {
                    { 1L, "ESTCIV", "Lista de estados civiles", null, null, "Estado Civil", null, "ADMIN", null },
                    { 4L, "TIPCLI", "Lista de tipos de cliente", null, null, "Tipo de Cliente", null, "ADMIN", null },
                    { 7L, "TIPO-ID", "Lista de tipos de identificación", null, null, "Tipo de Identificación", null, "ADMIN", null },
                    { 2L, "ESTCIV-SOLTERO", "Estado Civil - Soltero", null, 1L, "Soltero", null, "ADMIN", null },
                    { 3L, "ESTCIV-CASADO", "Estado Civil - Casado", null, 1L, "Casado", null, "ADMIN", null },
                    { 5L, "TIPCLI-INDIVIDUAL", "Cliente Individual", null, 4L, "Individual", null, "ADMIN", null },
                    { 6L, "TIPCLI-CORPORATIVO", "Cliente Corporativo", null, 4L, "Corporativo", null, "ADMIN", null },
                    { 8L, "TIPO-ID-CEDULA", "Número de identificación - Cédula", null, 7L, "Cédula", null, "ADMIN", null },
                    { 9L, "TIPO-ID-PASAPORTE", "Número de identificación - Pasaporte", null, 7L, "Pasaporte", null, "ADMIN", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EstadoCivilId",
                table: "Cliente",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_GeneroId",
                table: "Cliente",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Id",
                table: "Cliente",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TipoClienteId",
                table: "Cliente",
                column: "TipoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_Id",
                table: "Parametros",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_IdPadre",
                table: "Parametros",
                column: "IdPadre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Parametros");
        }
    }
}
