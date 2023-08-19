
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<Unit>
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string Sobrenome { get;  set; }
        public string Email { get;  set; }
        public string Endereco { get;  set; }
    }
}
