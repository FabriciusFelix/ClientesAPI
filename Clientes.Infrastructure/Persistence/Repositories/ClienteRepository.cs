using Clientes.Core.Entities;
using Clientes.Core.Repositories;
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

        public Cliente AddCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente GetAllClientes()
        {
            throw new NotImplementedException();
        }

        public Cliente GetByIdCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente GetClienteById(int id)
        {
            throw new NotImplementedException();
        }

        public int InativaCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
