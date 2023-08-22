using Clientes.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infrastructure
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(x =>  x.Id);
            modelBuilder.Entity<Usuario>()
                .HasKey(s => s.Id);
        }

    }
}