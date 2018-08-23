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

        public void seed(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioConfig());
        }
    }
}
