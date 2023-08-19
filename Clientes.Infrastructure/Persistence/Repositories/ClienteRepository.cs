using Clientes.Core.Entities;
using Clientes.Core.Repositories;
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

        public Cliente AddCliente(Cliente cliente)
        {   

            var clienteNovo = _db.Clientes.Add(cliente);
            _db.SaveChanges();
            return clienteNovo.Entity;
        }

        public List<Cliente> GetAllClientes()
        {
            return _db.Clientes.ToList();
        }

        public Cliente GetByIdCliente(int id)
        {
            var existe = _db.Clientes.SingleOrDefault(x => x.Id == id);
            if (existe == null)
            {
                throw new Exception("Não encontrado");

            }

            return existe;
        }

        public int InativaCliente(int id)
        {
            var existe = _db.Clientes.SingleOrDefault(x => x.Id == id);
            if (existe == null)
            {
                throw new Exception("Não encontrado");

            }
            existe.InativaCliente();
            _db.SaveChanges();

            return existe.Id;
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
           var existe = _db.Clientes.SingleOrDefault(x => x.Id == cliente.Id);
            if (existe == null)
            {
                throw new EntryPointNotFoundException("Não encontrado");

            }
            _db.Clientes.Update(existe);
            _db.SaveChanges();
            return existe;
        }

    }
}
