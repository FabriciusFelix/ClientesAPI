using Clientes.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<int?>
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string Sobrenome { get;  set; }
        public string CodigoCpf { get;  set; }
        public string Email { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Endereco { get;  set; }
        public bool Ativo { get;  set; }
        public DateTime CriadoEm { get;  set; }

        
    }
}
