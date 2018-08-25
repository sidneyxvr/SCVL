using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfig
{
    class AnuncioConfig : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.ToTable("Anuncio");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.Titulo)
                   .HasColumnType("varchar(100)")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.Autores)
                   .HasColumnType("varchar(100)")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.Editora)
                   .HasColumnType("varchar(30)")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(a => a.Categoria)
                   .HasColumnType("varchar(100)")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.Descricao)
                   .HasColumnType("varchar(200)")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(a => a.Preco)
                    .HasColumnType("decimal(6,2)")
                    .IsRequired();

            builder.HasOne(a => a.Usuario)
                   .WithMany(u => u.Anuncios)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
