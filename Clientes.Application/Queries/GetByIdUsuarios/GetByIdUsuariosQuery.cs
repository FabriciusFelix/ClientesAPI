using Clientes.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetByIdUsuarios
{
    public class GetByIdUsuariosQuery : IRequest<Usuario>
    {
        public GetByIdUsuariosQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
