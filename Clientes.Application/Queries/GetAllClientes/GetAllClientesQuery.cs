using Clientes.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetAllClientes
{
    public class GetAllClientesQuery : IRequest<List<Cliente>>
    {
    }
}
