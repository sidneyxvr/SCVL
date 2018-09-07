using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.EntityConfig
{
    public class VendaConfig : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Cliente)
                   .WithMany(v => v.VendasCliente)
                   .HasForeignKey(f => f.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Vendedor)
                   .WithMany(u => u.VendasVendedor)
                   .HasForeignKey(f => f.VendedorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Anuncio)
                   .WithMany(v => v.Vendas)
                   .HasForeignKey(f => f.AnuncioId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
