using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClientesDbContext _context;
        public UsuarioRepository(ClientesDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario?> GetByIdAsync(int id)
        {
           return await _context.Usuarios.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario?> GetUsuarioEmailESenhaAsync(string email, string passwordHash)
        {
            return await _context.Usuarios
                .SingleOrDefaultAsync(u => u.Email == email && u.Senha == passwordHash);
        }
    }
}
