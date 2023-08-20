using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetByIdClientes
{
    internal class GetByIdClientesQueryHandler : IRequestHandler<GetByIdClientesQuery, Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetByIdClientesQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public Task<Cliente> Handle(GetByIdClientesQuery request, CancellationToken cancellationToken)
        {
            var cliente = _clienteRepository.GetByIdClienteAsync(request.Id); 
            return cliente;

        }
    }
}
