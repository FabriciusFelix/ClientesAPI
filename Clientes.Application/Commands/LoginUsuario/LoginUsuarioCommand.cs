using Clientes.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUsuarioCommand : IRequest<LoginUsuarioViewModel>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
