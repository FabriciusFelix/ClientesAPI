using Clientes.Application.Commands.CreateCliente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Validators
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        { 
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email não Válido!");
            RuleFor(x => x.CodigoCpf).Must(ValidaCpf).NotEmpty().WithMessage("CPF Inválido!");
            RuleFor(x => x.Nome).MinimumLength(4).MaximumLength(20).NotEmpty().NotNull().WithMessage("Nome inválido!");
            RuleFor(x => x.Nome).MinimumLength(6).MaximumLength(20).NotEmpty().NotNull().WithMessage("Sobrenome inválido!");
        }


        public static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();


            return cpf.EndsWith(digito);


        }


    }
}
