using BusinessDomain;
using BusinessDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Contracts
{
    public interface IUsuarioRepository
    {
        Task<string> CreateUserAsync(Usuario usuario);
    }
}
