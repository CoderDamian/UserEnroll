using ApplicationService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Contracts
{
    public interface IUnitOfWork
    {
        public IUsuarioRepository UsuarioRepository { get; }

        Task SaveAsync();
    }
}
