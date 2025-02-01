using ApplicationService;
using ApplicationService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsuarioRepository UsuarioRepository => throw new NotImplementedException();

        public UnitOfWork()
        {

        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
