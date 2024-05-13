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
                Codigo = "ESTCIV",
                Nombre = "Estado Civil",
                Desripcion = "Lista de estados civiles",
                Valor = null,
                ParametroPadre = null,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 2,
                Codigo = "ESTCIV-SOLTERO",
                Nombre = "Soltero",
                Desripcion = "Estado Civil - Soltero",
                Valor = null,
                IdPadre = 1, // Establecer el IdPadre con el Id del padre
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 3,
                Codigo = "ESTCIV-CASADO",
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
                Codigo = "TIPCLI",
                Nombre = "Tipo de Cliente",
                Desripcion = "Lista de tipos de cliente",
                Valor = null,
                ParametroPadre = null,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 5,
                Codigo = "TIPCLI-INDIVIDUAL",
                Nombre = "Individual",
                Desripcion = "Cliente Individual",
                Valor = null,
                IdPadre = 4,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 6,
                Codigo = "TIPCLI-CORPORATIVO",
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
                Codigo = "TIPO-ID",
                Nombre = "Tipo de Identificación",
                Desripcion = "Lista de tipos de identificación",
                Valor = null,
                ParametroPadre = null,
                UsuarioCreacion = "ADMIN"
            },
            new Parametros
            {
                Id = 8,
                Codigo = "TIPO-ID-CEDULA",
                Nombre = "Cédula",
                Desripcion = "Número de identificación - Cédula",
                Valor = null,
                IdPadre = 7,
                UsuarioCreacion = "ADMIN"
            },
                new Parametros
                {
                    Id = 9,
                    Codigo = "TIPO-ID-PASAPORTE",
                    Nombre = "Pasaporte",
                    Desripcion = "Número de identificación - Pasaporte",
                    Valor = null,
                    IdPadre = 7,
                    UsuarioCreacion = "ADMIN"
                },
                new Parametros
                {
                    Id = 10,
                    Codigo = "PAR-GENERO",
                    Nombre = "Listado de genero",
                    Desripcion = "Listado de genero",
                    Valor = null,
                    IdPadre = null,
                    UsuarioCreacion = "ADMIN"
                },
                new Parametros
                {
                    Id = 11,
                    Codigo = "PAR-GENERO-FEMENINO",
                    Nombre = "Femenino",
                    Desripcion = "genero Femenino",
                    Valor = null,
                    IdPadre = 10,
                    UsuarioCreacion = "ADMIN"
                },
                new Parametros
                {
                    Id = 12,
                    Codigo = "PAR-GENERO-MASCULINO",
                    Nombre = "Masculino",
                    Desripcion = "genero Masculino",
                    Valor = null,
                    IdPadre = 10,
                    UsuarioCreacion = "ADMIN"
                },
            ];

            // Insertamos los datos de ejemplo en la base de datos
            builder.HasData(parametros);
        }
    }
}