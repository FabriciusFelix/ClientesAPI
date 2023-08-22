
using Clientes.Application.Commands.UpdateCliente;
using Clientes.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Validators
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        private readonly IClienteRepository _repository;
        
        public UpdateClienteCommandValidator(IClienteRepository repository)
        {
            _repository = repository;
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email não é Válido!");
            RuleFor(x => x.Nome).MinimumLength(3).MaximumLength(20).NotEmpty().NotNull().WithMessage("Nome inválido!");
            RuleFor(x => x.Sobrenome).MinimumLength(4).MaximumLength(20).NotEmpty().NotNull().WithMessage("Sobrenome inválido!");
        }

    }
}
