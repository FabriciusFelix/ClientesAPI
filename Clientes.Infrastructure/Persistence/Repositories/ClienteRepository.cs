﻿using Clientes.Core.Entities;
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

        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {   

            var clienteNovo =await _db.Clientes.AddAsync(cliente);
            await _db.SaveChangesAsync();
            return clienteNovo.Entity; 
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
                throw new Exception("Não encontrado");

            }

            return existe;
        }

        public async Task<int> InativaClienteAsync(int id)
        {
            var existe = await _db.Clientes.SingleOrDefaultAsync(x => x.Id == id);
            if (existe == null)
            {
                throw new Exception("Não encontrado");

            }
            existe.InativaCliente();
            await _db.SaveChangesAsync();

            return existe.Id;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
           var existe = await _db.Clientes.SingleOrDefaultAsync(x => x.Id == cliente.Id);
            if (existe == null)
            {
                throw new EntryPointNotFoundException("Não encontrado");

            }
            _db.Clientes.Update(existe);
            await _db.SaveChangesAsync();
            return existe;
        }

    }
}
