using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfig
{
    class ImagemConfig : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.ToTable("Imagem");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(i => i.Caminho)
                   .HasColumnType("varchar(200)")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasOne(i => i.Anuncio)
                   .WithMany(a => a.Imagens)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
