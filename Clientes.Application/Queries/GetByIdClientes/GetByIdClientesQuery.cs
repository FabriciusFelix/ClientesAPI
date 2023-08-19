using Clientes.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetByIdClientes
{
    public class GetByIdClientesQuery : IRequest<Cliente>
    {
        public GetByIdClientesQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
