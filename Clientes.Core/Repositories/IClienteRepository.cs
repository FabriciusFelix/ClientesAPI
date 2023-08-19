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
        List<Cliente> GetAllClientes();

        Cliente GetByIdCliente(int id);

        Cliente AddCliente(Cliente cliente);

        Cliente UpdateCliente(Cliente cliente);
        int InativaCliente(int id);
    }
}
