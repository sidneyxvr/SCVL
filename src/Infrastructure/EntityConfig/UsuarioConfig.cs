using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.EntityConfig
{
    class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Nome)
                   .HasColumnType("varchar(100)")
                   .HasMaxLength(100)
                   .IsRequired();
            
        }
    }
}
