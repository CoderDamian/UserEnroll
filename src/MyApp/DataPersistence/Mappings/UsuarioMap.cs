using BusinessDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPersistence.Mappings
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        /// <summary>
        /// Mapear las propiedades del objeto con las columnas de la tabla en la base de datos
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS", "CTB");

            builder.Property(p => p.Nombres)
                .HasColumnName("NOMBRES");

            builder.Property(p => p.Apellidos)
                .HasColumnName("APELLIDOS");

            builder.Property(p => p.CorreoElectronico)
                .HasColumnName("CORREO_ELECTRONICO");

            builder.Property(p => p.Contrasena)
                .HasColumnName("CONTRASENA");

            builder.Property(p => p.CreatedBy)
                .HasColumnName("CREATED_BY");
        }
    }
}
