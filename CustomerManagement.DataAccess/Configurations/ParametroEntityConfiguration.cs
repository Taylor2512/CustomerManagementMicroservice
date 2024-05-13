using CustomerManagement.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.DataAccess.Configurations
{
    internal class ParametroEntityConfiguration : IEntityTypeConfiguration<Parametros>
    {
        public void Configure(EntityTypeBuilder<Parametros> builder)
        {
            // Configuración para la entidad Parametros

            // Configuración de la propiedad Id como long y auto-generada


            // Configuración de propiedades específicas de Parametros
            builder.HasKey(x => x.Id).HasName("PK_PARAMETRO");
            builder.HasIndex(x => x.Id).IsUnique();


            builder.Property(p => p.Ccodigo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CodigoParametro");

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NombreParametro");

            builder.Property(p => p.Desripcion)
                .HasMaxLength(500)
                .HasColumnName("DescripcionParametro");

            builder.Property(p => p.Valor)
                .HasMaxLength(100)
                .HasColumnName("ValorParametro");

            // Configuración de la relación con la tabla Parametros (relación padre-hijo)

            builder.HasOne(p => p.ParametroPadre)
                .WithMany(p => p.ParametrosHijo)
                .HasForeignKey(p => p.IdPadre)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de propiedades heredadas de BaseEntity

            builder.Property(p => p.Activo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(p => p.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.FechaActualizacion)
                .IsRequired(false);

            builder.Property(p => p.UsuarioCreacion)
                .IsRequired();

            builder.Property(p => p.UsuarioActualizacion)
                .IsRequired(false);
            builder.HasQueryFilter(p => p.Activo);
            builder.SeedData();

        }
    }
}
