using Microsoft.EntityFrameworkCore;

namespace KcomoAPI.Models
{
    public class KcomoContext : DbContext
    {
        public KcomoContext(DbContextOptions<KcomoContext> options)
            : base(options)
        {
        }

        public DbSet<Vendedores> Vendedores { get; set; }
        public DbSet<Publicaciones> Publicaciones { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendedores>().HasKey(s => s.IdVendedor);
            modelBuilder.Entity<Usuarios>().HasKey(s => s.IdUsuario);
            modelBuilder.Entity<Publicaciones>().HasKey(s => s.IdPublicacion);
        }

    }
}