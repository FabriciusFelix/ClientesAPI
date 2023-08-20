using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetAllClientes
{
    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, List<Cliente>>
    {
        private readonly IClienteRepository _repository;


        public GetAllClientesQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }
        public Task<List<Cliente>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            
            var clientes = _repository.GetAllClientesAsync();

            return clientes;
        }
    }
}
