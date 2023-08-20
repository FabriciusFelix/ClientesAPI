
using Clientes.Application.Commands.UpdateCliente;
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
        public UpdateClienteCommandValidator() {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email não é Válido!");
            RuleFor(x => x.Nome).MinimumLength(4).MaximumLength(20).NotEmpty().NotNull().WithMessage("Nome inválido!");
            RuleFor(x => x.Sobrenome).MinimumLength(6).MaximumLength(20).NotEmpty().NotNull().WithMessage("Sobrenome inválido!");
        }  

    }
}
