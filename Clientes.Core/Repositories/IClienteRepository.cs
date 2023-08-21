using Clientes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientesAsync();

        Task<Cliente> GetByIdClienteAsync(int id);

        Task<int> AddClienteAsync(Cliente cliente);

        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task<int> InativaClienteAsync(int id);
        Task<bool> EmailJaExiste(string email);
        Task<bool> CpfJaExiste(string email);
    }
}
