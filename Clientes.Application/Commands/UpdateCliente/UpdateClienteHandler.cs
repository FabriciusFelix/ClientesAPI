using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.UpdateCliente
{
    public class UpdateClienteHandler : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IClienteRepository _repository;

        public UpdateClienteHandler(IClienteRepository clienteRepository)
        {
            _repository = clienteRepository;
        }

        Task<Unit> IRequestHandler<UpdateClienteCommand, Unit>.Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _repository.GetByIdCliente(request.Id);
            cliente.UpdateCliente(request.Nome, request.Sobrenome,request.Email, request.Endereco);

            _repository.UpdateCliente(cliente);
            return Task.FromResult(Unit.Value);

        }
    }
}
