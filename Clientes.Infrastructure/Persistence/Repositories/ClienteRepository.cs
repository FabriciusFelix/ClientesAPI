using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clientes.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesDbContext _db;

        public ClienteRepository(ClientesDbContext context)
        {
            _db = context;
        }

        public async Task<int> AddClienteAsync(Cliente cliente)
        {
            var validaCpf = await _db.Clientes.SingleOrDefaultAsync(x => x.CodigoCpf.Contains(cliente.CodigoCpf));
            if (validaCpf != null) { return 0; }

            var clienteNovo = await _db.Clientes.AddAsync(cliente);
            await _db.SaveChangesAsync();
            return clienteNovo.Entity.Id; 
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _db.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdClienteAsync(int id)
        {
            var existe =  await _db.Clientes.SingleOrDefaultAsync(x => x.Id == id);
            if (existe == null)
            {
               return null;
            }

            return existe;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            try
            {
                var update = _db.Clientes.Update(cliente);
                await _db.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ;
            }
        }

        public async Task<int> InativaClienteAsync(int id)
        {
            var existe = await _db.Clientes.SingleOrDefaultAsync(x => x.Id == id);
            if (existe == null)
            {
                return 0;
            }
            existe.InativaCliente();
            await _db.SaveChangesAsync();

            return existe.Id;
        }
        public async Task<bool> EmailJaExiste(string email)
        {
            var existe = await _db.Clientes.FirstOrDefaultAsync(x => x.Email == email) != null ? false : true;

            return existe;
        }
        public async Task<bool> CpfJaExiste(string cpf)
        {
            var existe = await _db.Clientes.FirstOrDefaultAsync(x => x.CodigoCpf == cpf) != null ? false : true;

            return existe;
        }
    }
}
