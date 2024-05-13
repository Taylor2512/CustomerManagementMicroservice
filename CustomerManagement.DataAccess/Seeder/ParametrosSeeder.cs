using CustomerManagement.DataAccess.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.DataAccess.Seeder
{
    internal static class ParametrosSeeder
    {
        internal static void SeedData(this EntityTypeBuilder<Parametros> builder)
        {
            // Define los datos de ejemplo para la entidad Parametros
            List<Parametros> parametros =
            [
                // Creamos un Parametros para "Estado Civil" con sus respectivos hijos
                new Parametros
            {
                Id = 1,
                Ccodigo = "ESTCIV",
                Nombre = "Estado Civil",
                Desripcion = "Lista de estados civiles",
                Valor = null,
                ParametroPadre = null,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 2,
                Ccodigo = "ESTCIV-SOLTERO",
                Nombre = "Soltero",
                Desripcion = "Estado Civil - Soltero",
                Valor = null,
                IdPadre = 1, // Establecer el IdPadre con el Id del padre
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 3,
                Ccodigo = "ESTCIV-CASADO",
                Nombre = "Casado",
                Desripcion = "Estado Civil - Casado",
                Valor = null,
                IdPadre = 1, // Establecer el IdPadre con el Id del padre
                UsuarioCreacion = "ADMIN"
            },
            // Creamos un Parametros para "Tipo de Cliente"
            new Parametros
            {
                Id = 4,
                Ccodigo = "TIPCLI",
                Nombre = "Tipo de Cliente",
                Desripcion = "Lista de tipos de cliente",
                Valor = null,
                ParametroPadre = null,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 5,
                Ccodigo = "TIPCLI-INDIVIDUAL",
                Nombre = "Individual",
                Desripcion = "Cliente Individual",
                Valor = null,
                IdPadre = 4,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 6,
                Ccodigo = "TIPCLI-CORPORATIVO",
                Nombre = "Corporativo",
                Desripcion = "Cliente Corporativo",
                Valor = null,
                IdPadre = 4,
                UsuarioCreacion = "ADMIN"
            },
            // Creamos un Parametros para "Tipo de Identificación"
            new Parametros
            {
                Id = 7,
                Ccodigo = "TIPO-ID",
                Nombre = "Tipo de Identificación",
                Desripcion = "Lista de tipos de identificación",
                Valor = null,
                ParametroPadre = null,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 8,
                Ccodigo = "TIPO-ID-CEDULA",
                Nombre = "Cédula",
                Desripcion = "Número de identificación - Cédula",
                Valor = null,
                IdPadre = 7,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 9,
                Ccodigo = "TIPO-ID-PASAPORTE",
                Nombre = "Pasaporte",
                Desripcion = "Número de identificación - Pasaporte",
                Valor = null,
                IdPadre = 7,
                UsuarioCreacion = "ADMIN"
            },
        ];

            // Insertamos los datos de ejemplo en la base de datos
            builder.HasData(parametros);
        }
    }
}