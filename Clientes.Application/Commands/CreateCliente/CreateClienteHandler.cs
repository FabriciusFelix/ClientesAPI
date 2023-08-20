
using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.CreateCliente
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteRepository _repository;

        public CreateClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Id, request.Nome, request.Sobrenome, request.CodigoCpf,  request.Email, request.DataNascimento, request.Endereco, true, request.CriadoEm);

            var addCliente = await _repository.AddClienteAsync(cliente);

            return addCliente.Id;
        }
    }
}
