using ApplicationService.Contracts;
using BusinessDomain.Entities;

namespace ApplicationService.CasosDeUso
{
    /// <summary>
    /// Caso de Uso: Registro de Usuario en un Sistema Empresarial
    /// </summary>
    public class UserRegister
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRegister(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<string> RegistrarAsync(string nombres, string apellidos, string correoElectronico, string contrasena)
        {
            Usuario nuevoUsuario = new (nombres, apellidos, correoElectronico, contrasena);

            try
            {
                string codigoVerificacion = await this._unitOfWork.UsuarioRepository.CreateUserAsync(nuevoUsuario);

                await this._unitOfWork.SaveAsync();

                return codigoVerificacion;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
