using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Entities
{
    public class UpdateCliente
    {
            public int Id { get; private set; }
            public string Nome { get; private set; }
            public string Sobrenome { get; private set; }
            public string Email { get; private set; }
            public string Endereco { get; private set; }
    }
}
