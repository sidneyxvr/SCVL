using Infrastructure.Entities;
using Infrastructure.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SistemaDbContext : IdentityDbContext<Usuario>
    {
        public SistemaDbContext(DbContextOptions<SistemaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioConfig());

            base.OnModelCreating(builder);
        }

        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
    }
}
