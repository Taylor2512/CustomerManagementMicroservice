using CustomerManagement.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.DataAccess.Configurations
{
    internal class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {


            builder.HasKey(x => x.Id).HasName("PK_CLIENTE");
            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NombreCliente");

            builder.Property(c => c.Apellido)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ApellidoCliente");

            builder.Property(c => c.NumeroCuenta)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("NumeroCuentaCliente");

            builder.Property(c => c.FechaNacimiento)
                .IsRequired()
                .HasColumnName("FechaNacimientoCliente");

            builder.Property(c => c.CorreoElectronico)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("CorreoElectronicoCliente");

            builder.Property(c => c.NumeroIdentificacion)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NumeroIdentificacionCliente");

            builder.Property(c => c.ProfesionOcupacion)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ProfesionOcupacionCliente");

            builder.Property(c => c.Nacionalidad)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NacionalidadCliente");


            builder.HasOne(c => c.EstadoCivil)
                .WithMany()
                .HasForeignKey(c => c.EstadoCivilId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.TipoCliente)
                .WithMany()
                .HasForeignKey(c => c.TipoClienteId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Genero)
                .WithMany()
                .HasForeignKey(c => c.GeneroId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Activo)
                .IsRequired()
                .HasDefaultValue(true);
            builder.HasQueryFilter(c => c.Activo);
            builder.Property(c => c.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.FechaActualizacion)
                .IsRequired(false);

            builder.Property(c => c.UsuarioCreacion)
                .IsRequired();

            builder.Property(c => c.UsuarioActualizacion)
                .IsRequired(false);

        }
    }
}
