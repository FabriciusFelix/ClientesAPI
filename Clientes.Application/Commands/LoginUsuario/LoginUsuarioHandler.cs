using Clientes.Application.ViewModels;
using Clientes.Core.Repositories;
using Clientes.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUsuarioHandler : IRequestHandler<LoginUsuarioCommand, LoginUsuarioViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _userRepository;
        public LoginUsuarioHandler(IAuthService authService, IUsuarioRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUsuarioViewModel> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

           
            var user = await _userRepository.GetUsuarioEmailESenhaAsync(request.Email, passwordHash);

           
            if (user == null)
            {
                return null;
            }

            // Se existir, gero o token usando os dados do usuário
            var token = _authService.GerarJwtToken(user.Email, user.Role);

            return new LoginUsuarioViewModel(user.Email, token);
        }
    }
}
