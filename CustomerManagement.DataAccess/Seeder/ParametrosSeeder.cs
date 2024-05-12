using System.Collections.Generic;
using System.Linq;

using CustomerManagement.DataAccess.Context;
using CustomerManagement.DataAccess.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.DataAccess.Seeder
{
    internal static class ParametrosSeeder
    {
        internal static void SeedData(this EntityTypeBuilder<Parametros> builder, CustomerDbContext context)
        {
            // Define los datos de ejemplo para la entidad Parametros

            // Lista de Parametros a insertar
            List<Parametros> parametros = new List<Parametros>();

            // Creamos un Parametros para "Estado Civil" con sus respectivos hijos
            Parametros estadoCivil = new Parametros
            {
                Ccodigo = "ESTCIV",
                Nombre = "Estado Civil",
                Desripcion = "Lista de estados civiles",
                Valor = null,
                ParametroPadre = null,
                UsuarioCreacion = "ADMIN"
            };

            // Añadimos los hijos del Parametros "Estado Civil"
            estadoCivil.ParametrosHijo = new List<Parametros>
            {
                new Parametros
                {
                    Ccodigo = "ESTCIV-SOLTERO",
                    Nombre = "Soltero",
                    Desripcion = "Estado Civil - Soltero",
                    Valor = null,
                    ParametroPadre = estadoCivil,
                    UsuarioCreacion = "ADMIN"
                },
                new Parametros
                {
                    Ccodigo = "ESTCIV-CASADO",
                    Nombre = "Casado",
                    Desripcion = "Estado Civil - Casado",
                    Valor = null,
                    ParametroPadre = estadoCivil,
                    UsuarioCreacion = "ADMIN"
                }
            };

            // Agregamos el Parametros "Estado Civil" y sus hijos a la lista
            AddParametrosAndChildrenToList(estadoCivil, parametros);

            // Creamos un Parametros para "Tipo de Cliente"
            Parametros tipoCliente = new Parametros
            {
                Ccodigo = "TIPCLI",
                Nombre = "Tipo de Cliente",
                Desripcion = "Lista de tipos de cliente",
                Valor = null,
                ParametroPadre = null,
                UsuarioCreacion = "ADMIN"
            };

            // Agregamos el Parametros "Tipo de Cliente" a la lista
            parametros.Add(tipoCliente);

            // Verificamos y eliminamos registros existentes con los mismos Ccodigo
            foreach (var parametro in parametros)
            {
                RemoveExistingParametrosByCcodigo(context, parametro.Ccodigo);
            }

            // Insertamos los nuevos datos de ejemplo en la base de datos
            builder.HasData(parametros);
        }

        private static void AddParametrosAndChildrenToList(Parametros parametro, List<Parametros> parametrosList)
        {
            if (parametro != null)
            {
                parametrosList.Add(parametro); // Agrega el Parametros actual a la lista

                // Recursivamente agrega todos los hijos del Parametros actual a la lista
                if (parametro.ParametrosHijo != null && parametro.ParametrosHijo.Any())
                {
                    foreach (var childParametro in parametro.ParametrosHijo)
                    {
                        AddParametrosAndChildrenToList(childParametro, parametrosList);
                    }
                }
            }
        }

        private static void RemoveExistingParametrosByCcodigo(CustomerDbContext context, string ccodigo)
        {
            // Busca todos los registros con el mismo Ccodigo y elimínalos
            var existingParametros = context.Parametros.Where(p => p.Ccodigo == ccodigo).ToList();
            foreach (var existingParametro in existingParametros)
            {
                context.Parametros.Remove(existingParametro);
            }
        }
    }
}
