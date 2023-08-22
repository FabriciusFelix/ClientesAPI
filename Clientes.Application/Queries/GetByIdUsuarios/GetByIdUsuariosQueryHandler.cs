using Clientes.Core.Entities;
using Clientes.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Application.Queries.GetByIdUsuarios
{
    public class GetByIdUsuariosQueryHandler : IRequestHandler<GetByIdUsuariosQuery, Usuario>
    {
        private readonly IUsuarioRepository _userRepository;
        public GetByIdUsuariosQueryHandler(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<Usuario> Handle(GetByIdUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _userRepository.GetByIdAsync(request.Id);

            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }
    }
}
