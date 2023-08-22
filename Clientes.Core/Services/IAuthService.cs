using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Core.Services
{
    public interface IAuthService
    {
        string GerarJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}
