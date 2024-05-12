using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class segundo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parametros",
                columns: new[] { "Id", "CodigoParametro", "DescripcionParametro", "FechaActualizacion", "IdPadre", "NombreParametro", "UsuarioActualizacion", "UsuarioCreacion", "ValorParametro" },
                values: new object[,]
                {
                    { 1L, "ESTCIV", "Lista de estados civiles", null, null, "Estado Civil", null, "ADMIN", null },
                    { 2L, "TIPCLI", "Lista de tipos de cliente", null, null, "Tipo de Cliente", null, "ADMIN", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Parametros",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
