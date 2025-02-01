using ApplicationService.Contracts;
using BusinessDomain.Entities;

namespace DataPersistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<string> CreateUserAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
