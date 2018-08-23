using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfig
{
    class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(u => u.Nome)
                   .HasColumnType("varchar(100)")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Ativo)
                   .HasDefaultValue(true);
        }
    }
}
