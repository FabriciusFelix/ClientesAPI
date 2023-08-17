using Clientes.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infrastructure
{
    public class ClientesDbContext : DbContext
    {

        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options) { }


        public DbSet<Cliente> Clientes { get; set; }
    }
}