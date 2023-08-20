using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.DeleteCliente
{
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteCommand, int>
    {
        private readonly IClienteRepository _repository;
        public DeleteClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }


        public Task<int> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _repository.InativaClienteAsync(request.Id);
            return cliente;
        }
    }
}
