using Clientes.Core.Entities;
using Clientes.Core.Services;
using Clientes.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Commands.CreateUsuario
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly ClientesDbContext _context;
        private readonly IAuthService _authService;
        public CreateUsuarioHandler(ClientesDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var passordHash = _authService.ComputeSha256Hash(request.Senha);
            var usuario = new Usuario(request.Id, request.Nome,request.Email, passordHash, request.Role);

            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario.Id;
           
        }
    }
}
