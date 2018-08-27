using Infrastructure.Entities;
using Infrastructure.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class SistemaDbContext : IdentityDbContext<Usuario, ApplicationRole, Guid>
    {
        public SistemaDbContext(DbContextOptions<SistemaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioConfig());
            builder.ApplyConfiguration(new AnuncioConfig());
            builder.ApplyConfiguration(new ImagemConfig());
            builder.ApplyConfiguration(new VendaConfig());

            base.OnModelCreating(builder);
        }

        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
    }
}
