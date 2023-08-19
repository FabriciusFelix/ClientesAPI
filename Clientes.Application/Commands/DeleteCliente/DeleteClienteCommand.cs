using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest<int>
    {
        public DeleteClienteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
